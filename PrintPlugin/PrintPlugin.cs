using System;

namespace PrintPlugin
{
    public class PrintPlugin : PluginInterface.IPlugin
    {
        public string Name => "PrintPlugin";

        public string Description => "Spire.PDF Print pdf";

        public string Execute(object inPars)
        {
            Spire.Pdf.PdfDocument pdfDocument = new Spire.Pdf.PdfDocument(inPars?.ToString());
            pdfDocument.Print();
            return "打印完成";
        }
    }
}
