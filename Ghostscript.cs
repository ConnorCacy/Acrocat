using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acrocat
{
    public static class Ghostscript
    {
        public static string[] ConvertToJpgs(string pdfFile)
        {
            var tempFolder = Path.GetTempPath();
            var gsExe = GetGhostScriptPath();
            var guid = Guid.NewGuid().ToString();
            var startInfo = new ProcessStartInfo(gsExe, "-sDEVICE=png16m " +
                $"-sOutputFile=Acrocat-{guid}-%02d.png " +
                "-r100x100 " +
                "-dNOPAUSE " +
                "-dBATCH " +
                $"-f \"{pdfFile}\"")
            { WorkingDirectory = tempFolder };
            
            var p = Process.Start(startInfo);
            p.WaitForExit();
            return Directory.GetFiles(tempFolder, $"Acrocat-{guid}-*.png");
        }

        private static string GetGhostScriptPath()
        {
            var dirs = Directory.GetFiles(@"C:\Program Files (x86)\gs", "gswin32c.exe", SearchOption.AllDirectories);
            return dirs.FirstOrDefault();
        }
    }
}
