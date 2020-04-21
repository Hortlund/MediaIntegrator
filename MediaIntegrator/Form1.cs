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

namespace MediaIntegrator
{
    public partial class MediaIntegrator : Form
    {

        FileWatch fwc = new FileWatch();
        public MediaIntegrator()
        {
            InitializeComponent();
        }

        private void MediaIntegrator_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            {
                DialogResult result = fb.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fb.SelectedPath);
                    fwc.fileWatch(fb.SelectedPath);
                    //fileWatch(fb.SelectedPath);
                    textBox1.Text = fb.SelectedPath;
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            {
                DialogResult result = fb.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fb.SelectedPath);
                    textBox2.Text = fb.SelectedPath;
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }
    }
}
