
namespace PluginsApp
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lstboxPlugins = new System.Windows.Forms.ListBox();
            this.btnExec = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnUnload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGC = new System.Windows.Forms.Button();
            this.ckbName = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "插件列表：";
            // 
            // lstboxPlugins
            // 
            this.lstboxPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstboxPlugins.FormattingEnabled = true;
            this.lstboxPlugins.ItemHeight = 17;
            this.lstboxPlugins.Location = new System.Drawing.Point(94, 12);
            this.lstboxPlugins.Name = "lstboxPlugins";
            this.lstboxPlugins.Size = new System.Drawing.Size(609, 123);
            this.lstboxPlugins.TabIndex = 2;
            // 
            // btnExec
            // 
            this.btnExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExec.Location = new System.Drawing.Point(628, 141);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 3;
            this.btnExec.Text = "执行插件";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(94, 141);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "加载插件";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnUnload
            // 
            this.btnUnload.Location = new System.Drawing.Point(175, 141);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(75, 23);
            this.btnUnload.TabIndex = 4;
            this.btnUnload.Text = "卸载插件";
            this.btnUnload.UseVisualStyleBackColor = true;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "输  出：";
            // 
            // txtOut
            // 
            this.txtOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOut.Location = new System.Drawing.Point(95, 170);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOut.Size = new System.Drawing.Size(608, 268);
            this.txtOut.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "程序集输出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGC
            // 
            this.btnGC.Location = new System.Drawing.Point(461, 141);
            this.btnGC.Name = "btnGC";
            this.btnGC.Size = new System.Drawing.Size(94, 23);
            this.btnGC.TabIndex = 7;
            this.btnGC.Text = "GC回收";
            this.btnGC.UseVisualStyleBackColor = true;
            this.btnGC.Click += new System.EventHandler(this.btnGC_Click);
            // 
            // ckbName
            // 
            this.ckbName.AutoSize = true;
            this.ckbName.Location = new System.Drawing.Point(285, 143);
            this.ckbName.Name = "ckbName";
            this.ckbName.Size = new System.Drawing.Size(51, 21);
            this.ckbName.TabIndex = 8;
            this.ckbName.Text = "名称";
            this.ckbName.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 450);
            this.Controls.Add(this.ckbName);
            this.Controls.Add(this.btnGC);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUnload);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.lstboxPlugins);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "插件";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstboxPlugins;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnUnload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGC;
        private System.Windows.Forms.CheckBox ckbName;
    }
}

