using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client
{
    public partial class Client_Form : Form
    {
        private const string LOCALHOST = "127.0.0.1";
        private IPAddress server_ip;
        private int port = 13000;
        private TcpClient client;
        private List<ChatMsg> chat_msgs;
        private string client_name;

        public Client_Form()
        {
            InitializeComponent();
            server_ip = GetIpAddress(ip_textbox.Text);
            connect_disconnect_button.Text = "CONNECT";
            send_button.Enabled = false;
            chat_msgs = new List<ChatMsg>();
            Random rnd = new Random();
            client_name = "Client" + rnd.Next(1000, 9999).ToString();
            client_name_textbot.Text = client_name;
        }

        private void Client_Form_Load(object sender, EventArgs e)
        {

        }

        private void connect_disconnect_button_Click(object sender, EventArgs e)
        {
            //CLICKING CONNECT BUTTON
            if (connect_disconnect_button.Text == "CONNECT")
            {
                try
                {
                    server_ip = GetIpAddress(ip_textbox.Text);
                    client = new TcpClient(server_ip.ToString(), port);
                    Thread t = new Thread(ProcessClientTransactions);
                    t.IsBackground = true;
                    t.Start(client);

                    connect_disconnect_button.Text = "DISCONNECT";
                    send_button.Enabled = true;
                    client_name = client_name_textbot.Text;
                    client_name_textbot.Enabled = false;
                    ip_textbox.Enabled = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting to server");
                    Console.WriteLine(ex.ToString());
                }
            }
            //CLICKING DISCONNECT BUTTON
            else if (connect_disconnect_button.Text == "DISCONNECT")
            {
                DisconnectFromServer();
            }
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (client.Connected && send_textbox.Text!= String.Empty)
                {
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(client_name+"~"+send_textbox.Text);
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                    ChatMsg msg = new ChatMsg()
                    {
                        Name = client_name,
                        Body = send_textbox.Text,
                        Timestamp = DateTime.Now
                    };
                    chat_msgs.Add(msg);
                    updateChatbox(msg);
                    send_textbox.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while sending message to server");
                Console.WriteLine(ex.ToString());
            }
        }

        private IPAddress GetIpAddress(string ip)
        {
            IPAddress address = IPAddress.Parse(LOCALHOST);
            try
            {
                if(!IPAddress.TryParse(ip, out address))
                {
                    address = IPAddress.Parse(LOCALHOST);
                    ip_textbox.Text = LOCALHOST;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error parsing server IP address");
                Console.WriteLine(ex.ToString());
            }
            return address;
        }

        private void ProcessClientTransactions(object Tcpclient)
        {
            TcpClient c = (TcpClient)Tcpclient;
            try
            {
                Byte[] bytes = new Byte[256];
                String data = null;
                while (true)
                {
                    data = null;
                    NetworkStream stream = c.GetStream();
                    int i;
                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        if (data == null)
                        {
                            DisconnectFromServer();
                        }
                        else
                        {
                            String[] datas = data.Split('~');
                            ChatMsg msg = new ChatMsg()
                            {
                                Name = datas[0],
                                Body = datas[1],
                                Timestamp = DateTime.Now
                            };
                            if(msg.Name != client_name)
                            {
                                chat_msgs.Add(msg);
                                updateChatbox(msg);
                            }
                        }
                    }
                    // Detect if client disconnected
                    if (c.Client.Poll(0, SelectMode.SelectRead))
                    {
                        byte[] buff = new byte[1];
                        if (c.Client.Receive(buff, SocketFlags.Peek) == 0)
                        {
                            break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error communicating with server");
                Console.WriteLine(ex.ToString());
            }
            BeginInvoke(new Action(() =>
            {
                connect_disconnect_button.Text = "CONNECT";
                send_button.Enabled = false;
                client_name_textbot.Enabled = true;
                ip_textbox.Enabled = true;
            }));
        }

        private void DisconnectFromServer()
        {
            try
            {
                client.Close();
                BeginInvoke(new Action(() =>
                {
                    connect_disconnect_button.Text = "CONNECT";
                    send_button.Enabled = false;
                    client_name_textbot.Enabled = true;
                    ip_textbox.Enabled = true;
                }));
                Console.WriteLine("Disconnected from server");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error disconnecting from server");
                Console.WriteLine(ex.ToString());
            }
        }

        public void updateChatbox(ChatMsg m)
        {
            chatbox.BeginInvoke(new Action(() => {
                // DISPLAY SENDER NAME
                chatbox.SelectionStart = chatbox.TextLength;
                chatbox.SelectionLength = 0;
                chatbox.SelectionBackColor = Color.Gainsboro;
                if (m.Name != client_name)
                {
                    chatbox.SelectionColor = Color.Teal;
                    chatbox.SelectionAlignment = HorizontalAlignment.Left;
                    chatbox.AppendText(m.getName() + "\r\n");
                }
                else
                {
                    chatbox.SelectionColor = Color.DarkGreen;
                    chatbox.SelectionAlignment = HorizontalAlignment.Right;
                    chatbox.AppendText(m.getName() + "\r\n");
                }
                // DISPLAY CHAT MESSAGE
                chatbox.SelectionStart = chatbox.TextLength;
                chatbox.SelectionLength = 0;
                chatbox.SelectionColor = Color.Black;
                if (m.Name == client_name)
                {
                    chatbox.SelectionAlignment = HorizontalAlignment.Right;
                    chatbox.SelectionBackColor = Color.PaleGreen;
                    chatbox.AppendText(m.getMessage());
                    chatbox.SelectionBackColor = Color.Gainsboro;
                    chatbox.AppendText(m.WS + "\r\n" + "\r\n");

                }
                else
                {
                    chatbox.SelectionAlignment = HorizontalAlignment.Left;
                    chatbox.SelectionBackColor = Color.Gainsboro;
                    chatbox.AppendText(m.WS);
                    chatbox.SelectionBackColor = Color.PaleTurquoise;
                    chatbox.AppendText(m.getMessage() + "\r\n" + "\r\n");
                }
                chatbox.ScrollToCaret();

            }));
        }

        private void send_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                send_button.PerformClick();
            }
        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void export_button_Click(object sender, EventArgs e)
        {
            export_dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            export_dialog.FileName = "client_chat_logs";
            string s = "";
            foreach (ChatMsg msg in chat_msgs)
            {
                s = s + msg.exportMessage();
            }
            if (export_dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(export_dialog.FileName, s);
            }
        }
    }
}
