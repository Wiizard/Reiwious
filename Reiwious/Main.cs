using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reiwious
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblVer.Text = "v" + Application.ProductVersion;
            btnGo.Enabled = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Please select your IW4x installation folder...";
            folderBrowserDialog1.ShowDialog();
            txtPath.Text = folderBrowserDialog1.SelectedPath;
            btnGo.Enabled = true;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if(File.Exists(txtPath.Text + "\\iw4x.dll") && File.Exists(txtPath.Text + "\\iw4x.exe") && Directory.Exists(txtPath.Text + "\\iw4x") && Directory.Exists(txtPath.Text + "\\main") && Directory.Exists(txtPath.Text + "\\miles") && Directory.Exists(txtPath.Text + "\\players") && Directory.Exists(txtPath.Text + "\\zone"))
            {
                DialogResult install = MessageBox.Show("A valid IW4x installation was found.\nAre you sure you want to install Reiwious?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (install == DialogResult.Yes)
                {
                    btnGo.Enabled = false;
                    btnExit.Enabled = false;
                    btnGo.Text = "Installing Reiwious...\nPlease wait...";
                    File.WriteAllBytes(txtPath.Text + "\\Reiwious.exe", Properties.Resources.Reiwious);
                    File.WriteAllBytes(txtPath.Text + "\\Reiwious.dll", Properties.Resources.Reiwious1);
                    if (File.Exists(txtPath.Text + "\\Reiwious.exe") && File.Exists(txtPath.Text + "\\Reiwious.dll"))
                    {
                        btnGo.Text = "Installed :)";
                        btnBrowse.Enabled = false;
                        btnExit.Enabled = true;
                        DialogResult installsuccess = MessageBox.Show("Reiwious was installed successfully! :)\n\nDo you want to run it now?", "Install Successful", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if(installsuccess == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(txtPath.Text + "\\Reiwious.exe");
                            Application.Exit();
                        }
                        else if(installsuccess == DialogResult.No)
                        {
                            MessageBox.Show("Operation was aborted.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("An error occured. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else if(install == DialogResult.No)
                {
                    MessageBox.Show("Operation was aborted.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("The selected path is not a valid IW4x installation.\nPlease verify the path is correct and try again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblVer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("All information regarding version history and more can be found at: github.com/Wiizard/Reiwious.\n\nWould you like to visit the github page now?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://github.com/Wiizard/Reiwious");
            }
        }
    }
}
