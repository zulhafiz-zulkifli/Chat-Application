namespace Chat_Client
{
    partial class Client_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chatbox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.connect_disconnect_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.send_button = new System.Windows.Forms.Button();
            this.send_textbox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.ip_label = new System.Windows.Forms.Label();
            this.ip_textbox = new System.Windows.Forms.TextBox();
            this.client_name_label = new System.Windows.Forms.Label();
            this.client_name_textbot = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.export_button = new System.Windows.Forms.Button();
            this.export_dialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chatbox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.13064F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.86936F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(619, 739);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // chatbox
            // 
            this.chatbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatbox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatbox.Location = new System.Drawing.Point(3, 81);
            this.chatbox.Name = "chatbox";
            this.chatbox.ReadOnly = true;
            this.chatbox.Size = new System.Drawing.Size(613, 559);
            this.chatbox.TabIndex = 0;
            this.chatbox.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 284F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.connect_disconnect_button, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(613, 72);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // connect_disconnect_button
            // 
            this.connect_disconnect_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.connect_disconnect_button.Location = new System.Drawing.Point(373, 15);
            this.connect_disconnect_button.Name = "connect_disconnect_button";
            this.connect_disconnect_button.Size = new System.Drawing.Size(195, 42);
            this.connect_disconnect_button.TabIndex = 0;
            this.connect_disconnect_button.Text = "CONNECT";
            this.connect_disconnect_button.UseVisualStyleBackColor = true;
            this.connect_disconnect_button.Click += new System.EventHandler(this.connect_disconnect_button_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.18952F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.81048F));
            this.tableLayoutPanel3.Controls.Add(this.send_textbox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 646);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(613, 90);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // send_button
            // 
            this.send_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.send_button.Location = new System.Drawing.Point(3, 3);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(153, 36);
            this.send_button.TabIndex = 0;
            this.send_button.Text = "SEND";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // send_textbox
            // 
            this.send_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.send_textbox.Location = new System.Drawing.Point(3, 3);
            this.send_textbox.Multiline = true;
            this.send_textbox.Name = "send_textbox";
            this.send_textbox.Size = new System.Drawing.Size(442, 84);
            this.send_textbox.TabIndex = 1;
            this.send_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.send_textbox_KeyDown);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel4.Controls.Add(this.ip_label, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ip_textbox, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.client_name_label, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.client_name_textbot, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(323, 66);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // ip_label
            // 
            this.ip_label.AutoSize = true;
            this.ip_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ip_label.Location = new System.Drawing.Point(3, 0);
            this.ip_label.Name = "ip_label";
            this.ip_label.Size = new System.Drawing.Size(122, 30);
            this.ip_label.TabIndex = 0;
            this.ip_label.Text = "  Enter server IP:";
            this.ip_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ip_textbox
            // 
            this.ip_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ip_textbox.Location = new System.Drawing.Point(131, 5);
            this.ip_textbox.Name = "ip_textbox";
            this.ip_textbox.Size = new System.Drawing.Size(189, 20);
            this.ip_textbox.TabIndex = 1;
            this.ip_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // client_name_label
            // 
            this.client_name_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.client_name_label.AutoSize = true;
            this.client_name_label.Location = new System.Drawing.Point(3, 30);
            this.client_name_label.Name = "client_name_label";
            this.client_name_label.Size = new System.Drawing.Size(122, 36);
            this.client_name_label.TabIndex = 2;
            this.client_name_label.Text = "Enter you name:";
            this.client_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // client_name_textbot
            // 
            this.client_name_textbot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.client_name_textbot.Location = new System.Drawing.Point(131, 38);
            this.client_name_textbot.Name = "client_name_textbot";
            this.client_name_textbot.Size = new System.Drawing.Size(189, 20);
            this.client_name_textbot.TabIndex = 3;
            this.client_name_textbot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.send_button, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.export_button, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(451, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(159, 84);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // export_button
            // 
            this.export_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.export_button.Location = new System.Drawing.Point(3, 45);
            this.export_button.Name = "export_button";
            this.export_button.Size = new System.Drawing.Size(153, 36);
            this.export_button.TabIndex = 1;
            this.export_button.Text = "EXPORT";
            this.export_button.UseVisualStyleBackColor = true;
            this.export_button.Click += new System.EventHandler(this.export_button_Click);
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 739);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Client_Form";
            this.Text = "Chat Application Client";
            this.Load += new System.EventHandler(this.Client_Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox chatbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button connect_disconnect_button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.TextBox send_textbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label ip_label;
        private System.Windows.Forms.TextBox ip_textbox;
        private System.Windows.Forms.Label client_name_label;
        private System.Windows.Forms.TextBox client_name_textbot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button export_button;
        private System.Windows.Forms.SaveFileDialog export_dialog;
    }
}

