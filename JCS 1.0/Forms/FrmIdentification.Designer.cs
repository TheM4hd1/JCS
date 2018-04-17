namespace JCS_1._0.Forms
{
    partial class FrmIdentification
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chbCode = new System.Windows.Forms.CheckBox();
            this.clbCode = new System.Windows.Forms.CheckedListBox();
            this.clbTag = new System.Windows.Forms.CheckedListBox();
            this.chbTag = new System.Windows.Forms.CheckBox();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.chbRegex = new System.Windows.Forms.CheckBox();
            this.rtxPage = new System.Windows.Forms.RichTextBox();
            this.chbPage = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chbCode);
            this.groupBox1.Controls.Add(this.clbCode);
            this.groupBox1.Controls.Add(this.clbTag);
            this.groupBox1.Controls.Add(this.chbTag);
            this.groupBox1.Controls.Add(this.txtRegex);
            this.groupBox1.Controls.Add(this.chbRegex);
            this.groupBox1.Controls.Add(this.rtxPage);
            this.groupBox1.Controls.Add(this.chbPage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 428);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identification Based On:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(209, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "Sample:\r\n<title>404 Not Found</title>\r\n<h1>Not Found</h1>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(208, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "CONTINUE if match";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(209, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "CONTINUE if match";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(209, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "CONTINUE if match";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(209, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "FAIL if match";
            // 
            // chbCode
            // 
            this.chbCode.AutoSize = true;
            this.chbCode.Location = new System.Drawing.Point(6, 301);
            this.chbCode.Name = "chbCode";
            this.chbCode.Size = new System.Drawing.Size(158, 17);
            this.chbCode.TabIndex = 7;
            this.chbCode.Text = "Check HTTP status code";
            this.chbCode.UseVisualStyleBackColor = true;
            this.chbCode.CheckedChanged += new System.EventHandler(this.chbCode_CheckedChanged);
            // 
            // clbCode
            // 
            this.clbCode.CheckOnClick = true;
            this.clbCode.Enabled = false;
            this.clbCode.FormattingEnabled = true;
            this.clbCode.Items.AddRange(new object[] {
            "Continue 100",
            "SwitchingProtocols 101",
            "OK 200",
            "Created 201",
            "Accepted 202",
            "NonAuthoritativeInformation 203",
            "NoContent 204",
            "ResetContent 205",
            "PartialContent 206",
            "MultipleChoices 300",
            "Ambiguous 300",
            "MovedPermanently 301",
            "Moved 301",
            "Found 302",
            "Redirect 302",
            "SeeOther 303",
            "RedirectMethod 303",
            "NotModified 304",
            "UseProxy 305",
            "Unused 306",
            "TemporaryRedirect 307",
            "RedirectKeepVerb 307",
            "BadRequest 400",
            "Unauthorized 401",
            "PaymentRequired 402",
            "Forbidden 403",
            "NotFound 404",
            "MethodNotAllowed 405",
            "NotAcceptable 406",
            "ProxyAuthenticationRequired 407",
            "RequestTimeout 408",
            "Conflict 409",
            "Gone 410",
            "LengthRequired 411",
            "PreconditionFailed 412",
            "RequestEntityTooLarge 413",
            "RequestUriTooLong 414",
            "UnsupportedMediaType 415",
            "RequestedRangeNotSatisfiable 416",
            "ExpectationFailed 417",
            "UpgradeRequired 426",
            "InternalServerError 500",
            "NotImplemented 501",
            "BadGateway 502",
            "ServiceUnavailable 503",
            "GatewayTimeout 504",
            "HttpVersionNotSupported 505"});
            this.clbCode.Location = new System.Drawing.Point(12, 324);
            this.clbCode.Name = "clbCode";
            this.clbCode.Size = new System.Drawing.Size(190, 79);
            this.clbCode.TabIndex = 6;
            // 
            // clbTag
            // 
            this.clbTag.CheckOnClick = true;
            this.clbTag.Enabled = false;
            this.clbTag.FormattingEnabled = true;
            this.clbTag.Items.AddRange(new object[] {
            "a",
            "abbr",
            "acronym",
            "address",
            "area",
            "b",
            "base",
            "bdo",
            "big",
            "blockquote",
            "body",
            "br",
            "button",
            "caption",
            "cite",
            "code",
            "col",
            "colgroup",
            "dd",
            "del",
            "dfn",
            "div",
            "dl",
            "DOCTYPE",
            "dt",
            "em",
            "fieldset",
            "form",
            "h1",
            "h2",
            "h3",
            "h4",
            "h5",
            "h6",
            "head",
            "html",
            "hr",
            "i",
            "img",
            "input",
            "ins",
            "kbd",
            "label",
            "legend",
            "li",
            "link",
            "map",
            "meta",
            "noscript",
            "object",
            "ol",
            "optgroup",
            "option",
            "p",
            "param",
            "pre",
            "q",
            "samp",
            "script",
            "select",
            "small",
            "span",
            "strong",
            "style",
            "sub",
            "sup",
            "table",
            "tbody",
            "td",
            "textarea",
            "tfoot",
            "th",
            "thead",
            "title",
            "tr",
            "tt",
            "ul",
            "var"});
            this.clbTag.Location = new System.Drawing.Point(12, 216);
            this.clbTag.Name = "clbTag";
            this.clbTag.Size = new System.Drawing.Size(190, 79);
            this.clbTag.TabIndex = 5;
            // 
            // chbTag
            // 
            this.chbTag.AutoSize = true;
            this.chbTag.Location = new System.Drawing.Point(6, 193);
            this.chbTag.Name = "chbTag";
            this.chbTag.Size = new System.Drawing.Size(146, 17);
            this.chbTag.TabIndex = 4;
            this.chbTag.Text = "Search for HTML tags";
            this.chbTag.UseVisualStyleBackColor = true;
            this.chbTag.CheckedChanged += new System.EventHandler(this.chbTag_CheckedChanged);
            // 
            // txtRegex
            // 
            this.txtRegex.Enabled = false;
            this.txtRegex.Location = new System.Drawing.Point(12, 167);
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(425, 20);
            this.txtRegex.TabIndex = 3;
            this.txtRegex.Text = "([A-Z])\\w+";
            // 
            // chbRegex
            // 
            this.chbRegex.AutoSize = true;
            this.chbRegex.Location = new System.Drawing.Point(6, 144);
            this.chbRegex.Name = "chbRegex";
            this.chbRegex.Size = new System.Drawing.Size(104, 17);
            this.chbRegex.TabIndex = 2;
            this.chbRegex.Text = "Regex Pattren";
            this.chbRegex.UseVisualStyleBackColor = true;
            this.chbRegex.CheckedChanged += new System.EventHandler(this.chbRegex_CheckedChanged);
            // 
            // rtxPage
            // 
            this.rtxPage.Enabled = false;
            this.rtxPage.Location = new System.Drawing.Point(12, 42);
            this.rtxPage.Name = "rtxPage";
            this.rtxPage.Size = new System.Drawing.Size(425, 96);
            this.rtxPage.TabIndex = 1;
            this.rtxPage.Text = "<!DOCTYPE html><title></title>";
            // 
            // chbPage
            // 
            this.chbPage.AutoSize = true;
            this.chbPage.Location = new System.Drawing.Point(6, 19);
            this.chbPage.Name = "chbPage";
            this.chbPage.Size = new System.Drawing.Size(116, 17);
            this.chbPage.TabIndex = 0;
            this.chbPage.Text = "Page Comparison";
            this.chbPage.UseVisualStyleBackColor = true;
            this.chbPage.CheckedChanged += new System.EventHandler(this.chbPage_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 428);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 46);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
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
            // FrmIdentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 474);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmIdentification";
            this.Text = "Identification Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbCode;
        private System.Windows.Forms.CheckedListBox clbCode;
        private System.Windows.Forms.CheckedListBox clbTag;
        private System.Windows.Forms.CheckBox chbTag;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.CheckBox chbRegex;
        private System.Windows.Forms.RichTextBox rtxPage;
        private System.Windows.Forms.CheckBox chbPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}