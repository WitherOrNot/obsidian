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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            McApi.DownloadVersion((McVersion)((ComboBoxValueItem)verBox.SelectedItem).Value);
        }

        public void UpdateLogin(string code)
        {
            launchButton.Text = code;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (McVersion version in McApi.GetVersions())
                {
                    if (version.type == "release")
                        verBox.Items.Add(
                            new ComboBoxValueItem
                            {
                                Text = $"Minecraft {version.id}",
                                Value = version
                            }
                        );
                }
            }
            catch
            {
                MessageBox.Show("Error occurred when accessing online launcher data. Please check your internet connection and restart the launcher.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            try
            {
                verBox.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void acctButton_Click(object sender, EventArgs e)
        {
            MsLogin msl = new MsLogin();
            msl.Show();
        }
    }
}
