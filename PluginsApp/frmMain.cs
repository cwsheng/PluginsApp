using PluginInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginsApp
{
    public partial class frmMain : Form
    {


        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<PluginInfo> plugins = new List<PluginInfo>();
            plugins.Add(new PluginInfo() { Name = "HelloPlugin", Path = @"HelloPlugin\bin\Debug\net5.0\HelloPlugin.dll", inPars = "Pluins" });
            plugins.Add(new PluginInfo() { Name = "JsonPlugin", Path = @"JsonPlugin\bin\Debug\net5.0\JsonPlugin.dll", inPars = null });
            plugins.Add(new PluginInfo() { Name = "PrintPlugin", Path = @"PrintPlugin\bin\Debug\net5.0\PrintPlugin.dll", inPars = @"1.pdf" });

            lstboxPlugins.DataSource = plugins;
            lstboxPlugins.DisplayMember = "Name";
            lstboxPlugins.ValueMember = "Path";
        }

        Dictionary<string, PluginAssemblyLoadContext> plugins = new Dictionary<string, PluginAssemblyLoadContext>();
        Dictionary<string, IEnumerable<IPlugin>> pluginComs = new Dictionary<string, IEnumerable<IPlugin>>();

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string pluginPath = lstboxPlugins.SelectedValue?.ToString();
            string key = lstboxPlugins.Text;
            Assembly pluginAssembly = LoadPlugin(key, pluginPath);
            pluginComs[key] = CreatePlugins(pluginAssembly);
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            string key = lstboxPlugins.Text;
            if (plugins.TryGetValue(key, out PluginAssemblyLoadContext loadContext))
            {
                loadContext.Unload();
                plugins.Remove(key);
                pluginComs.Remove(key);
            }
            else
            {
                MessageBox.Show("插件已卸载");
            }
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            string key = lstboxPlugins.Text;
            PluginInfo pinfo = lstboxPlugins.SelectedItem as PluginInfo;
            if (pluginComs.TryGetValue(key, out IEnumerable<IPlugin> pList))
            {
                foreach (var plugin in pList)
                {
                    result = plugin.Execute(pinfo.inPars);
                }
            }
            else
            {
                string root = Path.GetFullPath(Path.Combine(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            Path.GetDirectoryName(
                                Path.GetDirectoryName(
                                    Path.GetDirectoryName(typeof(Program).Assembly.Location)))))));

                string pluginLocation = Path.GetFullPath(Path.Combine(root, pinfo.Path.Replace('\\', Path.DirectorySeparatorChar)));
                WeakReference hostAlcWeakRef;
                result = ExecuteAndUnload(pluginLocation, pinfo.inPars, out hostAlcWeakRef);
                //检查
                for (int i = 0; hostAlcWeakRef.IsAlive && (i < 10); i++)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
            txtOut.AppendText($"{DateTime.Now} 执行完成-{result} \r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var arr = AppDomain.CurrentDomain.GetAssemblies();
            stringBuilder.AppendLine($"{DateTime.Now} 当前程序集列表：{arr.Length}个");
            if (ckbName.Checked)
                foreach (var item in arr)
                {
                    stringBuilder.AppendLine($"\t{item.FullName} ");
                }
            txtOut.AppendText(stringBuilder.ToString());
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }


        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private Assembly LoadPlugin(string key, string relativePath)
        {
            string root = Path.GetFullPath(Path.Combine(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            Path.GetDirectoryName(
                                Path.GetDirectoryName(
                                    Path.GetDirectoryName(typeof(Program).Assembly.Location)))))));

            string pluginLocation = Path.GetFullPath(Path.Combine(root, relativePath.Replace('\\', Path.DirectorySeparatorChar)));


            if (!plugins.TryGetValue(key, out PluginAssemblyLoadContext loadContext))
            {
                loadContext = new PluginAssemblyLoadContext(pluginLocation);
                plugins[key] = loadContext;
            }
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static IEnumerable<IPlugin> CreatePlugins(Assembly assembly)
        {
            int count = 0;

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IPlugin).IsAssignableFrom(type))
                {
                    IPlugin result = Activator.CreateInstance(type) as IPlugin;
                    if (result != null)
                    {
                        count++;
                        yield return result;
                    }
                }
            }

            if (count == 0)
            {
                string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
                throw new ApplicationException(
                    $"Can't find any type which implements ICommand in {assembly} from {assembly.Location}.\n" +
                    $"Available types: {availableTypes}");
            }
        }

        /// <summary>
        /// 将此方法标记为noinline很重要，否则JIT可能会决定将其内联到Main方法中。
        /// 这可能会阻止成功卸载插件，因为某些实例的生存期可能会延长到预期卸载插件的时间点之外。
        /// </summary>
        /// <param name="assemblyPath"></param>
        /// <param name="inPars"></param>
        /// <param name="alcWeakRef"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        static string ExecuteAndUnload(string assemblyPath, object inPars, out WeakReference alcWeakRef)
        {
            string resultString = string.Empty;
            // 创建 PluginLoadContext对象
            var alc = new PluginAssemblyLoadContext(assemblyPath);

            //创建一个对AssemblyLoadContext的弱引用，允许我们检测卸载何时完成
            alcWeakRef = new WeakReference(alc);

            // 加载程序到上下文
            // 注意:路径必须为绝对路径.
            Assembly assembly = alc.LoadFromAssemblyPath(assemblyPath);

            //创建插件对象并调用
            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IPlugin).IsAssignableFrom(type))
                {
                    IPlugin result = Activator.CreateInstance(type) as IPlugin;
                    if (result != null)
                    {

                        resultString = result.Execute(inPars);
                        break;
                    }
                }
            }
            //卸载程序集上下文
            alc.Unload();
            return resultString;
        }
    }

    class PluginInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public object inPars { get; set; }
    }
}
