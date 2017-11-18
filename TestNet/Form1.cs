using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Net;

namespace TestNet
{
    public partial class frmTestnet : Form
    {
        public frmTestnet()
        {
            InitializeComponent();
        }

        //KHAI BAO
        // Khai báo play sound
        SoundPlayer Ringtone = new SoundPlayer(Properties.Resources.ring);

        // Ham check ping internet
        public bool PingTest()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();

            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("8.8.4.4"), 1000);

            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khai bao Timer
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1500;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PingTest() == true)
            {
                label1.Text = "ĐÃ CÓ MẠNG";
                label1.ForeColor = Color.Red;
                pictureBox2.Image = Properties.Resources.onl;
                Ringtone.Play();
            }
            else
            {
                label1.Text = "RỚT MẠNG";
                label1.ForeColor = Color.DarkGray;
                pictureBox2.Image = Properties.Resources.off;
                Ringtone.Stop();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần Mềm Báo Có Mạng.\nTác giả: Hoàng Nam", "TÁC GIẢ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
