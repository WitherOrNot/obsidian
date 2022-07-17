using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows;
using System.IO;

namespace obsidian
{
    public class DownloadItem
    {
        public string path { get; set; }
        public string url { get; set; }
        public long size { get; set; }
        public string sha1 { get; set; }
        public bool isNative = false;
    }
}
