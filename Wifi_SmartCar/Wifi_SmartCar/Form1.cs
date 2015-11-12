using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using System.Net;
using System.Net.Sockets;

namespace Wifi_SmartCar
{
    public partial class Form1 : Form
    {
        private string url;
        private IPAddress ip;
        private Socket clientSocket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            InitializeComponent();
         }

        private void button5_Click(object sender, EventArgs e)
        {
            if(button5.Text=="连接")
            {
                button5.Text = "断开连接";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox4.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                button3.Enabled = true;
                button6.Enabled = true;
                ip = IPAddress.Parse(textBox1.Text);
                try
                {
                    clientSocket.Connect(ip,int.Parse(textBox4.Text));
                }
                catch { }
                url = "http://" + textBox1.Text + ":"+textBox2.Text + "/";
                MJPEGStream mjpegSource = new MJPEGStream(url + "?action=stream");
                OpenVideoSource(mjpegSource);
            }
            else
            {
                button5.Text = "连接";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox4.Enabled = true;
                videoSourcePlayer.Stop();
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button3.Enabled = false;
                button6.Enabled = false;
            }
            


        }
        private void OpenVideoSource(IVideoSource source)
        {
            this.Cursor = Cursors.WaitCursor;
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
            videoSourcePlayer.VideoSource = source;
            videoSourcePlayer.Start();
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseDown(object sender, EventArgs e)
        {
            try
            {
                string sendMessage = "lsya" ;
                clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));

            }
            catch
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
        private void button1_MouseUp(object sender, EventArgs e)
        {
            try
            {
                string sendMessage = "lsys";
                clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));

            }
            catch
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
        private void button2_MouseDown(object sender, EventArgs e)
        {
            try
            {
                string sendMessage = "lsyb";
                clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));

            }
            catch
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
        private void button2_MouseUp(object sender, EventArgs e)
        {
            try
            {
                string sendMessage = "lsys";
                clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));

            }
            catch
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }

        private void button3_MouseDown(object sender, EventArgs e)
        {
            try
            {
                string sendMessage = "lsyc";
                clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));

            }
            catch
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
        private void button3_MouseUp(object sender, EventArgs e)
        {
            try
            {
                string sendMessage = "lsys";
                clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));

            }
            catch
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }

        private void button4_MouseDown(object sender, EventArgs e)
        {
            try
            {
                string sendMessage = "lsyd";
                clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));

            }
            catch
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
        private void button4_MouseUp(object sender, EventArgs e)
        {
            try
            {
                string sendMessage = "lsys";
                clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));

            }
            catch
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "鸣笛")
            {
                try
                {
                    string sendMessage = "lsyz";
                    clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));

                }
                catch
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
                button6.Text = "关闭鸣笛";
            }
            else
            {
                try
                {
                    string sendMessage = "lsyy";
                    clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));

                }
                catch
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
                button6.Text = "鸣笛";
            }

        }
    }

}
