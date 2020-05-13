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
        //Skapar ett nytt objekt av filewatch
        FileWatch fwc = new FileWatch();
        public MediaIntegrator()
        {
            InitializeComponent();
        }

        private void MediaIntegrator_Load(object sender, EventArgs e)
        {
            
        }

        //Öppnar en dialog som låter användaren bläddra bland mappar som ska övervakas.
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            {
                DialogResult result = fb.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
                {
                    //Sätter texten till sökvägen
                    textBox1.Text = fb.SelectedPath;
                    //skickar med sökvägen till filewatch funktionen.
                    fwc.fileWatch(fb.SelectedPath);
                }
            }
        }

        //Öppnar en dialog som låter användaren bläddra bland mappar som den ska sparas till.
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            {
                DialogResult result = fb.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fb.SelectedPath))
                {
                    //Sätter texten till sökvägen
                    textBox2.Text = fb.SelectedPath;
                    //Skickar med sökvägen till savePath funktionen.
                    fwc.savePath(fb.SelectedPath);
                }
            }
        }
    }
}
