using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileDecrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Decrypting...");
            List<string> pathsToEncrypt = new List<string>();
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            foreach (string currentPath in pathsToEncrypt)
            {
                GetFilesAndDecrypt(currentPath);
            }
            Console.Clear();
            Console.WriteLine("Decrypting Complete");
            Console.Beep();
            Console.ReadKey();
        }
        static void GetFilesAndDecrypt(string Ps)
        {
            try
            {
                var validExtensions = new[]
                {
                    ".AGENOIS"
                };
                string[] files = Directory.GetFiles(Ps);
                foreach (string currentFile in files)
                {
                    string extension = Path.GetExtension(currentFile);
                    if (validExtensions.Contains(extension))
                    {
                        Utils.FileDecrypt(currentFile, currentFile.Replace(".AGENOIS", ""), "k9I3vNp87xFJ6f1IlaX5");
                        File.Delete(currentFile);
                    }
                }
                string[] subDirs = Directory.GetDirectories(Ps);
                foreach (string currentPath in subDirs)
                {
                    GetFilesAndDecrypt(currentPath);
                }
            }
            catch { }
        }
    }
}
