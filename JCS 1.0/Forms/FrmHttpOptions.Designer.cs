namespace JCS_1._0.Forms
{
    partial class FrmHttpOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHttpOptions));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbxAuth = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAuthPass = new System.Windows.Forms.TextBox();
            this.txtAuthUser = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chbAuth = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chbProxyAuth = new System.Windows.Forms.CheckBox();
            this.txtProxyPass = new System.Windows.Forms.TextBox();
            this.txtProxyUser = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtUserAgent = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chbProxy = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddHeader = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwHeaders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCrawlerBlacklist = new System.Windows.Forms.TextBox();
            this.txtCrawlerPattern = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 425);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(287, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(368, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.cbxAuth);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txtAuthPass);
            this.tabPage2.Controls.Add(this.txtAuthUser);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.chbAuth);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(441, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Authentication Options";
            // 
            // cbxAuth
            // 
            this.cbxAuth.Enabled = false;
            this.cbxAuth.FormattingEnabled = true;
            this.cbxAuth.Items.AddRange(new object[] {
            "Basic",
            "Digest"});
            this.cbxAuth.Location = new System.Drawing.Point(135, 79);
            this.cbxAuth.Name = "cbxAuth";
            this.cbxAuth.Size = new System.Drawing.Size(89, 21);
            this.cbxAuth.TabIndex = 6;
            this.cbxAuth.Text = "Basic";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Authentication Type";
            // 
            // txtAuthPass
            // 
            this.txtAuthPass.Enabled = false;
            this.txtAuthPass.Location = new System.Drawing.Point(69, 47);
            this.txtAuthPass.Name = "txtAuthPass";
            this.txtAuthPass.Size = new System.Drawing.Size(155, 20);
            this.txtAuthPass.TabIndex = 4;
            // 
            // txtAuthUser
            // 
            this.txtAuthUser.Enabled = false;
            this.txtAuthUser.Location = new System.Drawing.Point(69, 20);
            this.txtAuthUser.Name = "txtAuthUser";
            this.txtAuthUser.Size = new System.Drawing.Size(155, 20);
            this.txtAuthUser.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Username";
            // 
            // chbAuth
            // 
            this.chbAuth.AutoSize = true;
            this.chbAuth.Location = new System.Drawing.Point(3, 3);
            this.chbAuth.Name = "chbAuth";
            this.chbAuth.Size = new System.Drawing.Size(140, 17);
            this.chbAuth.TabIndex = 0;
            this.chbAuth.Text = "HTTP Authentication";
            this.chbAuth.UseVisualStyleBackColor = true;
            this.chbAuth.CheckedChanged += new System.EventHandler(this.chbAuth_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.chbProxyAuth);
            this.tabPage1.Controls.Add(this.txtProxyPass);
            this.tabPage1.Controls.Add(this.txtProxyUser);
            this.tabPage1.Controls.Add(this.txtPort);
            this.tabPage1.Controls.Add(this.txtHost);
            this.tabPage1.Controls.Add(this.txtUserAgent);
            this.tabPage1.Controls.Add(this.txtValue);
            this.tabPage1.Controls.Add(this.txtHeader);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.chbProxy);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btnAddHeader);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lvwHeaders);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(441, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Http Options";
            // 
            // chbProxyAuth
            // 
            this.chbProxyAuth.AutoSize = true;
            this.chbProxyAuth.Enabled = false;
            this.chbProxyAuth.Location = new System.Drawing.Point(6, 330);
            this.chbProxyAuth.Name = "chbProxyAuth";
            this.chbProxyAuth.Size = new System.Drawing.Size(146, 17);
            this.chbProxyAuth.TabIndex = 22;
            this.chbProxyAuth.Text = "Proxy Authentication";
            this.chbProxyAuth.UseVisualStyleBackColor = true;
            this.chbProxyAuth.CheckedChanged += new System.EventHandler(this.chbProxyAuth_CheckedChanged);
            // 
            // txtProxyPass
            // 
            this.txtProxyPass.Enabled = false;
            this.txtProxyPass.Location = new System.Drawing.Point(157, 366);
            this.txtProxyPass.Name = "txtProxyPass";
            this.txtProxyPass.Size = new System.Drawing.Size(140, 20);
            this.txtProxyPass.TabIndex = 21;
            // 
            // txtProxyUser
            // 
            this.txtProxyUser.Enabled = false;
            this.txtProxyUser.Location = new System.Drawing.Point(11, 366);
            this.txtProxyUser.Name = "txtProxyUser";
            this.txtProxyUser.Size = new System.Drawing.Size(140, 20);
            this.txtProxyUser.TabIndex = 20;
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(157, 304);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(60, 20);
            this.txtPort.TabIndex = 17;
            // 
            // txtHost
            // 
            this.txtHost.Enabled = false;
            this.txtHost.Location = new System.Drawing.Point(11, 304);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(140, 20);
            this.txtHost.TabIndex = 16;
            // 
            // txtUserAgent
            // 
            this.txtUserAgent.Location = new System.Drawing.Point(11, 231);
            this.txtUserAgent.Name = "txtUserAgent";
            this.txtUserAgent.Size = new System.Drawing.Size(428, 20);
            this.txtUserAgent.TabIndex = 12;
            this.txtUserAgent.Text = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(185, 157);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(254, 20);
            this.txtValue.TabIndex = 8;
            // 
            // txtHeader
            // 
            this.txtHeader.Location = new System.Drawing.Point(11, 157);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(149, 20);
            this.txtHeader.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(154, 350);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Username";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(154, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Host";
            // 
            // chbProxy
            // 
            this.chbProxy.AutoSize = true;
            this.chbProxy.Location = new System.Drawing.Point(6, 269);
            this.chbProxy.Name = "chbProxy";
            this.chbProxy.Size = new System.Drawing.Size(140, 17);
            this.chbProxy.TabIndex = 13;
            this.chbProxy.Text = "Run Through a Proxy";
            this.chbProxy.UseVisualStyleBackColor = true;
            this.chbProxy.CheckedChanged += new System.EventHandler(this.chbProxy_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "HTTP User-Agent";
            // 
            // btnAddHeader
            // 
            this.btnAddHeader.Location = new System.Drawing.Point(364, 183);
            this.btnAddHeader.Name = "btnAddHeader";
            this.btnAddHeader.Size = new System.Drawing.Size(75, 23);
            this.btnAddHeader.TabIndex = 10;
            this.btnAddHeader.Text = "Add";
            this.btnAddHeader.UseVisualStyleBackColor = true;
            this.btnAddHeader.Click += new System.EventHandler(this.btnAddHeader_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(166, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Header";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Add New Custom HTTP Header";
            // 
            // lvwHeaders
            // 
            this.lvwHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwHeaders.Location = new System.Drawing.Point(12, 19);
            this.lvwHeaders.Name = "lvwHeaders";
            this.lvwHeaders.Size = new System.Drawing.Size(427, 97);
            this.lvwHeaders.TabIndex = 3;
            this.lvwHeaders.UseCompatibleStateImageBehavior = false;
            this.lvwHeaders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Header";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 270;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Custom HTTP Headers";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(449, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.txtCrawlerBlacklist);
            this.tabPage3.Controls.Add(this.txtCrawlerPattern);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(441, 399);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Crawler Options";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Green;
            this.label19.Location = new System.Drawing.Point(14, 140);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(265, 26);
            this.label19.TabIndex = 14;
            this.label19.Text = "Example:\r\n/modules/mod_swmenufree/transmenu_Packed.js";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label18.Location = new System.Drawing.Point(122, 127);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(115, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Links won\'t follow";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Green;
            this.label17.Location = new System.Drawing.Point(14, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(367, 26);
            this.label17.TabIndex = 12;
            this.label17.Text = "Example:\r\n/index.php?option=com_ccnewsletter&view=ccnewsletter&Itemid=84";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(122, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(157, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Crawl component from link";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Black-List";
            // 
            // txtCrawlerBlacklist
            // 
            this.txtCrawlerBlacklist.Location = new System.Drawing.Point(17, 104);
            this.txtCrawlerBlacklist.Name = "txtCrawlerBlacklist";
            this.txtCrawlerBlacklist.Size = new System.Drawing.Size(409, 20);
            this.txtCrawlerBlacklist.TabIndex = 9;
            this.txtCrawlerBlacklist.Text = resources.GetString("txtCrawlerBlacklist.Text");
            // 
            // txtCrawlerPattern
            // 
            this.txtCrawlerPattern.Location = new System.Drawing.Point(17, 16);
            this.txtCrawlerPattern.Name = "txtCrawlerPattern";
            this.txtCrawlerPattern.Size = new System.Drawing.Size(409, 20);
            this.txtCrawlerPattern.TabIndex = 6;
            this.txtCrawlerPattern.Text = "(com_)\\w*[A-Za-z0-9\\-]\\w+";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Component Pattern";
            // 
            // FrmHttpOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 474);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmHttpOptions";
            this.Text = "Http Options";
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbxAuth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAuthPass;
        private System.Windows.Forms.TextBox txtAuthUser;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chbAuth;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chbProxyAuth;
        private System.Windows.Forms.TextBox txtProxyPass;
        private System.Windows.Forms.TextBox txtProxyUser;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtUserAgent;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbProxy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddHeader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvwHeaders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtCrawlerBlacklist;
        private System.Windows.Forms.TextBox txtCrawlerPattern;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
    }
}