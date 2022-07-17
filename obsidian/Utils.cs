using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace obsidian
{
    public class Utils
    {
        public static T RunTaskSync<T>(Task<T> task)
        {
            task.Wait();
            return task.Result;
        }

        public static string CreateTempDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }

        public static void CreateDirTree(string path)
        {
            string subfolder = ".";
            string[] pathParts = path.Split(new char[] { '/' });

            foreach (string folder in pathParts)
            {
                if (folder != pathParts.Last())
                {
                    subfolder = Path.Combine(subfolder, folder);

                    if (!Directory.Exists(subfolder))
                    {
                        Directory.CreateDirectory(subfolder);
                    }
                }
            }
        }
    }
}
