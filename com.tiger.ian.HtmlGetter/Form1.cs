using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.tiger.ian.HtmlClient;
using System.Xml;
using System.Text.RegularExpressions;

namespace com.tiger.ian.HtmlGetter
{
    public partial class Form1 : Form
    {
        private static readonly string TOKENNAME = "cgtz_token";
        private SimpleHttpClient mClient;
        private FormLoading mFormLoading;
        private static int mOffset = 0;

        public Form1()
        {
            InitializeComponent();

            SimpleHttpClient.onReadingConfig += SimpleHttpClient_onReadingConfig;
            SimpleHttpClient.onReadedConfig += SimpleHttpClient_onReadedConfig;

            mClient = new SimpleHttpClient();
            mClient.onDoError += mClient_onDoError;
            mClient.onDoing += mClient_onDoing;
            mClient.onDone += mClient_onDone;
        }

        void mClient_onDone(System.Net.HttpWebResponse obj)
        {
            DisplayMessage("get done, seccess.");
        }

        void mClient_onDoing(System.Net.HttpWebRequest obj)
        {
            DisplayMessage("do getting.");
        }

        void mClient_onDoError(Exception obj)
        {
            DisplayMessage("get done, but error.");
            DisposeFormLoading();
        }

        void SimpleHttpClient_onReadedConfig(HttpClientSectionConfig obj)
        {
            DisplayMessage("read httpclient's configuration completed.");
        }

        void SimpleHttpClient_onReadingConfig()
        {
            DisplayMessage("do reading httpclient's configuration.");
        }

        private void btnGetHome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                MessageBox.Show("error home url, please enter.", "system:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearResult();
            DisposeFormLoading();
            mFormLoading = new FormLoading();
            mFormLoading.mCallback = new Action(CallBackHandler);
            mFormLoading.ShowDialog();
        }

        //此处解析 HTML 代码
        private void ExecuteCore(string context)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(context);

            HtmlAgilityPack.HtmlNode cgtzDataUl = doc.DocumentNode.SelectSingleNode("//ul[@class=\"cgtzDataUl\"]");
            AnalyzeDataUI(cgtzDataUl);

            HtmlAgilityPack.HtmlNodeCollection prods = doc.DocumentNode.SelectNodes("//div[@class=\"liA\"]");
            string text = null;
            foreach (HtmlAgilityPack.HtmlNode nd in prods)
            {
                text = nd.InnerText.Trim()
                    .Replace(" ", "")
                    .Replace("\r", "")
                    .Replace("\n", ";");
                DisplayInfoAt(string.Join("；", text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)));
            }

            context = doc.DocumentNode.InnerHtml;
        }

        private void AnalyzeDataUI(HtmlAgilityPack.HtmlNode cgtzDataUl)
        {
            IEnumerable<HtmlAgilityPack.HtmlNode> items = cgtzDataUl.Descendants("li");
            foreach (HtmlAgilityPack.HtmlNode node in items)
            {
                DisplayInfoAt(node.InnerText);
            }
        }

        private void DisplayInfoAt(string value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(DisplayInfoAt), value);
                return;
            }

            listResult.Items.Add(new ListViewItem(new string[] { (++mOffset).ToString(), value }));
            listResult.Items[mOffset - 1].BackColor = 0 == (mOffset % 2) ? System.Drawing.Color.LightGray : System.Drawing.Color.White;
        }

        private void ClearResult()
        {
            listResult.Items.Clear();
            txtInformation.Clear();
            mOffset = 0;
        }

        private void CallBackHandler()
        {
            System.Threading.Thread.Sleep(1000);

            string context = mClient.Request(txtUrl.Text, MethodType.Get, null);
            ExecuteCore(context);

            DisposeFormLoading();
        }

        private void DisposeFormLoading()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(DisposeFormLoading));
                return;
            }

            if (mFormLoading != null && !mFormLoading.IsDisposed)
            {
                mFormLoading.Close();
                mFormLoading.Dispose();
            }
        }

        private void DisplayMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(DisplayMessage), message);
                return;
            }

            int count = listMessage.Items.Count;
            if (count == 0)
            {
                listMessage.Items.Add(new ListViewItem(new string[] { ">>", message }));
                return;
            }

            listMessage.Items[0].SubItems[1].Text = message;
        }

        private void btnGetUserHome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserHomeUrl.Text))
            {
                MessageBox.Show("error user home url, please enter.", "system:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtUserNameArgName.Text))
            {
                MessageBox.Show("error username-arg name , please enter.", "system:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtUserNameArgValue.Text))
            {
                MessageBox.Show("error username-arg value, please enter.", "system:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtPasswordArgName.Text))
            {
                MessageBox.Show("error password-arg name, please enter.", "system:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtPasswordArgValue.Text))
            {
                MessageBox.Show("error password-arg value, please enter.", "system:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearResult();

            DisposeFormLoading();
            mFormLoading = new FormLoading();
            mFormLoading.mCallback = new Action(UserInfoCallback);
            mFormLoading.ShowDialog();
        }

        private void UserInfoCallback()
        {
            System.Threading.Thread.Sleep(1000);
            
            //string context = mClient.Request(txtUserHomeUrl.Text, MethodType.Get, null, true);
            //ExecuteUserInfo(context);
            string context = mClient.Request();

            DisposeFormLoading();
        }

        private void ExecuteUserInfo(string context)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(context);

            //获取token值
            HtmlAgilityPack.HtmlNode ndToken = doc.DocumentNode.SelectSingleNode(string.Format("//input[@name=\"{0}\"]", TOKENNAME));
            string token = ndToken.Attributes["value"].Value;

            ParamCollection paramerates = new ParamCollection();
            paramerates.Add(txtUserNameArgName.Text, txtUserNameArgValue.Text);
            paramerates.Add(txtPasswordArgName.Text, txtPasswordArgValue.Text);
            paramerates.Add(TOKENNAME, token);
            context = mClient.Request("https://www.cgtz.com/login.html", MethodType.Post, paramerates);            
        }

        private void listResult_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                txtInformation.Text = e.Item.SubItems[1].Text;
            }
        }
    }
}
