using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBackApp
{
    public partial class mainForm : Form
    {
        int timesCopied = 0;
        public mainForm()
        {
            InitializeComponent();
            cb_Units.SelectedIndex = 0;
        }

        private void btn_SearchFrom_Click(object sender, EventArgs e)
        {
            tb_From.Text = Search();
        }

        private string Search()
        {
            return folderBrowserDialog.ShowDialog() == DialogResult.OK ? folderBrowserDialog.SelectedPath : null;
        }

        private void btn_SearchTo_Click(object sender, EventArgs e)
        {
            tb_To.Text = Search();
        }

        private void cb_Always_CheckedChanged(object sender, EventArgs e)
        {
            nud_Frequency.Enabled = !cb_Always.Checked;
            value_Changed(sender, e);
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                timer.Interval = (int)nud_Time.Value * (cb_Units.SelectedIndex == 0 ? 1000 : cb_Units.SelectedIndex == 1 ? 60000 : 3600000);
                timer.Start();
                btn_Start.Text = "Stop loop";
                Text = cb_Units.Text;
            }
            else
            {
                Stop();
            }
        }

        private void Stop()
        {
            timer.Stop();
            timesCopied = 0;
            pb_CopyTime.Value = 0;
            btn_Start.Text = "Start loop";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timesCopied++;
            var directoryInfo = new DirectoryInfo(tb_From.Text);
            var path = $"{tb_To.Text}\\{directoryInfo.Name}-" +
                $"{DateTime.Now.ToString().Replace(":", ".")}";
            FileSystem.CreateDirectory($"{tb_To.Text}\\{directoryInfo.Name}-" +
                $"{DateTime.Now.ToString().Replace(":", ".")}");
            FileSystem.CopyDirectory(tb_From.Text, path, true);
            pb_CopyTime.Value = cb_Always.Checked ? 100 : (timesCopied * 100) / (int)nud_Frequency.Value;
            if (timesCopied >= nud_Frequency.Value && !cb_Always.Checked)
            {
                Stop();
            }
        }

        private void value_Changed(object sender, EventArgs e)
        {
            btn_Start.Enabled = !string.IsNullOrWhiteSpace(tb_From.Text) && !string.IsNullOrWhiteSpace(tb_To.Text) && nud_Time.Value > 0 &&
                (cb_Always.Checked || nud_Frequency.Value > 0) && !string.IsNullOrEmpty(cb_Units.Text);
        }
    }
}
