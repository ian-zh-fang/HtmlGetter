namespace com.tiger.ian.HtmlGetter
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtInformation = new System.Windows.Forms.RichTextBox();
            this.listMessage = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGetHome = new System.Windows.Forms.Button();
            this.btnGetUserHome = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPasswordArgValue = new System.Windows.Forms.TextBox();
            this.txtPasswordArgName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserNameArgValue = new System.Windows.Forms.TextBox();
            this.txtUserHomeUrl = new System.Windows.Forms.TextBox();
            this.txtUserNameArgName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listMessage);
            this.splitContainer1.Panel2.Controls.Add(this.btnGetHome);
            this.splitContainer1.Panel2.Controls.Add(this.btnGetUserHome);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(827, 447);
            this.splitContainer1.SplitterDistance = 547;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listResult);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtInformation);
            this.splitContainer2.Size = new System.Drawing.Size(547, 447);
            this.splitContainer2.SplitterDistance = 386;
            this.splitContainer2.TabIndex = 0;
            // 
            // listResult
            // 
            this.listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listResult.FullRowSelect = true;
            this.listResult.GridLines = true;
            this.listResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listResult.Location = new System.Drawing.Point(0, 0);
            this.listResult.MultiSelect = false;
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(547, 386);
            this.listResult.TabIndex = 1;
            this.listResult.UseCompatibleStateImageBehavior = false;
            this.listResult.View = System.Windows.Forms.View.Details;
            this.listResult.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listResult_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 32;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 491;
            // 
            // txtInformation
            // 
            this.txtInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInformation.Location = new System.Drawing.Point(0, 0);
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.Size = new System.Drawing.Size(547, 57);
            this.txtInformation.TabIndex = 0;
            this.txtInformation.Text = "";
            // 
            // listMessage
            // 
            this.listMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader4});
            this.listMessage.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listMessage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listMessage.Location = new System.Drawing.Point(3, 394);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(270, 53);
            this.listMessage.TabIndex = 2;
            this.listMessage.UseCompatibleStateImageBehavior = false;
            this.listMessage.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = ">>";
            this.columnHeader5.Width = 26;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = " 信息提示";
            this.columnHeader4.Width = 235;
            // 
            // btnGetHome
            // 
            this.btnGetHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetHome.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetHome.Location = new System.Drawing.Point(3, 54);
            this.btnGetHome.Name = "btnGetHome";
            this.btnGetHome.Size = new System.Drawing.Size(270, 53);
            this.btnGetHome.TabIndex = 1;
            this.btnGetHome.Text = "Getting ...";
            this.btnGetHome.UseVisualStyleBackColor = true;
            this.btnGetHome.Click += new System.EventHandler(this.btnGetHome_Click);
            // 
            // btnGetUserHome
            // 
            this.btnGetUserHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetUserHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetUserHome.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetUserHome.Location = new System.Drawing.Point(3, 340);
            this.btnGetUserHome.Name = "btnGetUserHome";
            this.btnGetUserHome.Size = new System.Drawing.Size(270, 53);
            this.btnGetUserHome.TabIndex = 1;
            this.btnGetUserHome.Text = "Getting ...";
            this.btnGetUserHome.UseVisualStyleBackColor = true;
            this.btnGetUserHome.Click += new System.EventHandler(this.btnGetUserHome_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPasswordArgValue);
            this.groupBox2.Controls.Add(this.txtPasswordArgName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtUserNameArgValue);
            this.groupBox2.Controls.Add(this.txtUserHomeUrl);
            this.groupBox2.Controls.Add(this.txtUserNameArgName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 221);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户首页参数设定";
            // 
            // txtPasswordArgValue
            // 
            this.txtPasswordArgValue.Location = new System.Drawing.Point(54, 185);
            this.txtPasswordArgValue.Name = "txtPasswordArgValue";
            this.txtPasswordArgValue.PasswordChar = '*';
            this.txtPasswordArgValue.Size = new System.Drawing.Size(210, 21);
            this.txtPasswordArgValue.TabIndex = 1;
            this.txtPasswordArgValue.Text = "fangzhen6409251";
            // 
            // txtPasswordArgName
            // 
            this.txtPasswordArgName.Location = new System.Drawing.Point(54, 147);
            this.txtPasswordArgName.Name = "txtPasswordArgName";
            this.txtPasswordArgName.Size = new System.Drawing.Size(210, 21);
            this.txtPasswordArgName.TabIndex = 2;
            this.txtPasswordArgName.Text = "LoginForm[password]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "值：";
            // 
            // txtUserNameArgValue
            // 
            this.txtUserNameArgValue.Location = new System.Drawing.Point(54, 108);
            this.txtUserNameArgValue.Name = "txtUserNameArgValue";
            this.txtUserNameArgValue.Size = new System.Drawing.Size(210, 21);
            this.txtUserNameArgValue.TabIndex = 0;
            this.txtUserNameArgValue.Text = "18013511191";
            // 
            // txtUserHomeUrl
            // 
            this.txtUserHomeUrl.Location = new System.Drawing.Point(54, 33);
            this.txtUserHomeUrl.Name = "txtUserHomeUrl";
            this.txtUserHomeUrl.Size = new System.Drawing.Size(210, 21);
            this.txtUserHomeUrl.TabIndex = 0;
            this.txtUserHomeUrl.Text = "https://www.cgtz.com/login.html";
            // 
            // txtUserNameArgName
            // 
            this.txtUserNameArgName.Location = new System.Drawing.Point(54, 70);
            this.txtUserNameArgName.Name = "txtUserNameArgName";
            this.txtUserNameArgName.Size = new System.Drawing.Size(210, 21);
            this.txtUserNameArgName.TabIndex = 0;
            this.txtUserNameArgName.Text = "LoginForm[username]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "URL：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "值：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "域名";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(7, 22);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(257, 21);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "https://www.cgtz.com/projects.html";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 447);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HtmlGetter                                                                       " +
    "                                                                                " +
    "  ";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetUserHome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtUserNameArgValue;
        private System.Windows.Forms.TextBox txtUserNameArgName;
        private System.Windows.Forms.ListView listMessage;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnGetHome;
        private System.Windows.Forms.TextBox txtPasswordArgValue;
        private System.Windows.Forms.TextBox txtPasswordArgName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserHomeUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.RichTextBox txtInformation;
    }
}

