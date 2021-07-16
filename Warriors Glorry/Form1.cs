using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Warriors_Glorry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Beenden_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"WoW.exe");
            Application.Exit();
           Play.FlatStyle = FlatStyle.Flat;
            Play.FlatAppearance.BorderColor = BackColor;
            Play.FlatAppearance.MouseOverBackColor = BackColor;
            Play.FlatAppearance.MouseDownBackColor = BackColor;
        }


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }



        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://frostwar.de/en/");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void stop(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"Cache");
            if (dir.Exists)
                dir.Delete(true);


            string myfile = @"data/enUS/realmlist.wtf";


            File.Delete(myfile);

            if (!File.Exists(myfile))
            {
              
                using (StreamWriter sw = File.CreateText(myfile))
                {
                    sw.WriteLine("set realmlist FrostWar.de");
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://frostwar.de/en/forum");
        }


    }
}
