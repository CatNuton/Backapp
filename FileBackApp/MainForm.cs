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
        int tickInterval = 0;
        int timeInterval;
        string unit;
        string lastItemSelected;

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

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (!FileSystem.DirectoryExists(tb_From.Text))
            {
                MessageBox.Show("The source directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Path.IsPathRooted(tb_To.Text))
            {
                MessageBox.Show("The copy path is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!t_File.Enabled)
            {
                t_File.Interval = (int)nud_Time.Value * (cb_Units.SelectedIndex == 0 ? 1000 :
                    cb_Units.SelectedIndex == 1 ? 60000 : 3600000);
                timeInterval = (int)nud_Time.Value;
                unit = cb_Units.Text;
                t_File.Start();
                t_Progress.Start();
                btn_Start.Text = "Stop loop";
            }
            else
            {
                t_File.Stop();
                t_Progress.Stop();
                tickInterval = 0;
                timeInterval = 0;
                pb_CopyTime.Value = 0;
                btn_Start.Text = "Start loop";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                var path = "";
                var directoryInfo = new DirectoryInfo(tb_From.Text);
                if (!cb_Overwrite.Checked)
                {
                    path = $"{tb_To.Text}\\{directoryInfo.Name}-" +
                                $"{DateTime.Now.ToString().Replace(":", ".")}";
                    FileSystem.CreateDirectory($"{tb_To.Text}\\{directoryInfo.Name}-" +
                        $"{DateTime.Now.ToString().Replace(":", ".")}"); 
                }
                else
                {
                    path = $"{tb_To.Text}\\{directoryInfo.Name}";
                    if (!Directory.Exists(path))
                        FileSystem.CreateDirectory(path);
                }
                FileSystem.CopyDirectory(tb_From.Text, path, true);
                rtb_Logs.SelectionStart = rtb_Logs.TextLength;
                rtb_Logs.SelectionLength = 0;
                rtb_Logs.SelectionColor = Color.Green;
                rtb_Logs.AppendText($"\nCopied {tb_From.Text} to {path} at {DateTime.Now.TimeOfDay}");
                rtb_Logs.SelectionColor = rtb_Logs.ForeColor;
                rtb_Logs.AppendText($"\nNext copy in {timeInterval} {unit}");
            }
            catch (Exception exception)
            {
                rtb_Logs.SelectionStart = rtb_Logs.TextLength;
                rtb_Logs.SelectionLength = 0;
                rtb_Logs.SelectionColor = Color.Red;
                rtb_Logs.AppendText($"\n{exception}");
                rtb_Logs.SelectionColor = rtb_Logs.ForeColor;
            }
        }

        private void value_Changed(object sender, EventArgs e)
        {
            btn_Start.Enabled = !string.IsNullOrWhiteSpace(tb_From.Text) && !string.IsNullOrWhiteSpace(tb_To.Text) 
                && nud_Time.Value > 0 && !string.IsNullOrEmpty(cb_Units.Text);
            if (!cb_Units.Items.Contains(cb_Units.Text))
            {
                cb_Units.Text = lastItemSelected;
            }
        }

        private void t_Progress_Tick(object sender, EventArgs e)
        {
            tickInterval += t_Progress.Interval;
            int percent = (int)(((double)tickInterval / t_File.Interval) * 100);
            percent = Math.Max(0, Math.Min(100, percent));
            pb_CopyTime.Value = percent;
            if (pb_CopyTime.Value >= pb_CopyTime.Maximum)
            {
                tickInterval = 0;
                pb_CopyTime.Value = 0;
            }
        }

        private void cb_Units_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastItemSelected = cb_Units.Text;
        }
    }
}
