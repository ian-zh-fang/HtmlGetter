using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.tiger.ian.HtmlGetter
{
    public partial class FormLoading : Form
    {
        public Action mCallback;

        public FormLoading()
        {
            InitializeComponent();
            mCallback = new Action(ActionCallback);
        }

        private void ActionCallback() { }

        private void FormLoading_Load(object sender, EventArgs e)
        {
            ExecuteAsync();
        }

        private async void ExecuteAsync()
        {
            try
            {
                Action action = new Action(ExecureCoreAsync);
                await Task.Factory.StartNew(action);
            }
            catch (Exception) { }
        }

        private void ExecureCoreAsync()
        {
            try
            {
                Task t = Task.Factory.StartNew(mCallback);
            }
            catch (AggregateException e)
            {
                e.Flatten().Handle(t => true);
            }
            catch (Exception)
            {
                //在此记录日志信息
            }
            finally
            {

            }
        }
    }
}
