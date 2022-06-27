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

namespace Chat_Server
{
    public partial class Server_Form : Form
    {
        private List<TcpClient> client_list;
        private TcpListener listener;
        private int port = 13000;
        private int client_count;
        private bool keep_going;
        private List<ChatMsg> chat_msgs;
        public Server_Form()
        {
            InitializeComponent();
            client_list = new List<TcpClient>();
            client_count = 0;
            client_count_label.Text = client_count.ToString();
            start_stop_button.Text = "START SERVER";
            send_button.Enabled = false;
            chat_msgs = new List<ChatMsg>();

        }

        private void Server_Form_Load(object sender, EventArgs e)
        {

        }

        private void start_stop_button_Click(object sender, EventArgs e)
        {
            //CLICKING START SERVER BUTTON
            if (start_stop_button.Text == "START SERVER")
            {
                try
                {
                    client_count_label.Text = "0";
                    client_count = 0;
                    client_list.Clear();

                    Console.WriteLine("Starting server");
                    Thread t = new Thread(ListenForIncomingConnections);
                    t.IsBackground = true;
                    t.Start();

                    start_stop_button.Text = "STOP SERVER";
                    send_button.Enabled = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while starting server");
                    Console.WriteLine(ex.ToString());
                }
            }
            //CLICKING STOP SERVER BUTTON
            else if (start_stop_button.Text == "STOP SERVER")
            {
                Console.WriteLine("Stopping server, disconnecting all clients");
                keep_going = false;

                try
                {
                    foreach (TcpClient client in client_list)
                    {
                        client.Close();
                    }

                    client_list.Clear();
                    listener.Stop();
                    client_count = 0;
                    client_count_label.Text = "0";
                    start_stop_button.Text = "START SERVER";
                    send_button.Enabled = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while stopping server");
                    Console.WriteLine(ex.ToString());
                }

            }

        }

        private void send_button_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (TcpClient client in client_list)
                {
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes("Server" + "~" + send_textbox.Text);
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                }
                if (send_textbox.Text != String.Empty)
                {
                    ChatMsg msg = new ChatMsg()
                    {
                        Name = "Server",
                        Body = send_textbox.Text,
                        Timestamp = DateTime.Now
                    };
                    chat_msgs.Add(msg);
                    updateChatbox(msg);
                }
                send_textbox.Text = String.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while sending message to client");
                Console.WriteLine(ex.ToString());
            }
        }

        private void ListenForIncomingConnections()
        {
            try
            {
                keep_going = true;
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();

                while (keep_going)
                {
                    // wait for incoming connection (blocking call)
                    TcpClient client = listener.AcceptTcpClient();

                    Thread t = new Thread(ProcessClientRequests);
                    t.IsBackground = true;
                    t.Start(client);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while listening to client");
                Console.WriteLine(ex.ToString());
            }
        }

        private void ProcessClientRequests(object Tcpclient)
        {
            TcpClient c = (TcpClient)Tcpclient;
            client_list.Add(c);
            client_count++;
            client_count_label.BeginInvoke(new Action(() =>
            {
                client_count_label.Text = client_count.ToString();
            }));
            Byte[] bytes = new Byte[256];
            String data = null;
            try
            {
                while (true)
                {
                    data = null;
                    NetworkStream stream = c.GetStream();
                    int i;
                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        //data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        String[] datas = data.Split('~');
                        ChatMsg msg = new ChatMsg()
                        {
                            Name = datas[0],
                            Body = datas[1],
                            Timestamp = DateTime.Now
                        };
                        chat_msgs.Add(msg);
                        updateChatbox(msg);
                        resendToOtherClient(msg);
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
            catch (Exception ex)
            {
                Console.WriteLine("Error communicating with client");
                Console.WriteLine(ex.ToString());
            }

            client_list.Remove(c);
            if (keep_going)
            {
                client_count--;
            }
            client_count_label.BeginInvoke(new Action(() =>
            {
                client_count_label.Text = client_count.ToString();
            }));

            Console.WriteLine("Client disconnected.");

        }

        public void updateChatbox(ChatMsg m)
        {
            chatbox.BeginInvoke(new Action(() => {
                // DISPLAY SENDER NAME
                chatbox.SelectionStart = chatbox.TextLength;
                chatbox.SelectionLength = 0;
                chatbox.SelectionBackColor = Color.Gainsboro;
                if (m.Name != "Server")
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
                if (m.Name == "Server")
                {
                    chatbox.SelectionBackColor = Color.PaleGreen;
                    chatbox.SelectionAlignment = HorizontalAlignment.Right;
                    chatbox.AppendText(m.getMessage());
                    chatbox.SelectionFont = new Font("Segoe UI", 8, FontStyle.Regular);
                    chatbox.AppendText(m.getTime());
                    chatbox.SelectionBackColor = Color.Gainsboro;
                    chatbox.AppendText(m.WS + "\r\n" + "\r\n");
                }
                else
                {
                    chatbox.SelectionAlignment = HorizontalAlignment.Left;
                    chatbox.SelectionBackColor = Color.Gainsboro;
                    chatbox.AppendText(m.WS);
                    chatbox.SelectionBackColor = Color.PaleTurquoise;
                    chatbox.AppendText(m.getMessage());
                    chatbox.SelectionFont = new Font("Segoe UI", 8, FontStyle.Regular);
                    chatbox.AppendText(m.getTime());
                    chatbox.AppendText("\r\n" + "\r\n");
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

        public void resendToOtherClient(ChatMsg msg)
        {
            try
            {
                foreach (TcpClient client in client_list)
                {
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(msg.Name + "~" + msg.Body);
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while resending message to other client");
                Console.WriteLine(ex.ToString());
            }
        }

        private void export_button_Click(object sender, EventArgs e)
        {
            export_dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            export_dialog.FileName = "server_chat_logs";
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