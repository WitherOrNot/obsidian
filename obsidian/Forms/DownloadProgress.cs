using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace obsidian
{
    public partial class DownloadProgress : Form
    {
        DownloadManager downloadManager;

        public DownloadProgress(DownloadManager downloadManager)
        {
            InitializeComponent();
            this.downloadManager = downloadManager;
        }

        public void IncrementProgress()
        {
            progressBar.PerformStep();
        }

        private void DownloadProgress_Activated(object sender, EventArgs e)
        {
            progressBar.Minimum = 1;
            progressBar.Maximum = downloadManager.items.Count;
            progressBar.Value = 1;
            progressBar.Step = 1;

            Action step = delegate { progressBar.PerformStep(); };

            Task.Run(() => downloadManager.Download(this));
        }

        private void DownloadProgress_Load(object sender, EventArgs e)
        {

        }
    }
}
