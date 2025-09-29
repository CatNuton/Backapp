using FileBackApp.Properties;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBackApp
{
    public partial class MainForm : Form
    {
        int tickInterval;
        int timeInterval;
        string unit;
        string lastItemSelected;

        public MainForm()
        {
            InitializeComponent();
            cb_Units.SelectedIndex = 1;
            rtb_Logs.AppendText($"Backapp launched at {DateTime.Now:HH:mm:ss}\nFound a bug? Write here: " +
                $"https://github.com/CatNuton/Backapp/issues");
            LoadItemsFromMemory(cb_Source, Settings.Default.SourcePath);
            LoadItemsFromMemory(cb_Directory, Settings.Default.DirectoryPath);
        }


        private void btn_SearchFrom_Click(object sender, EventArgs e)
        {
            cb_Source.Text = Search();
        }

        private string Search()
        {
            return folderBrowserDialog.ShowDialog() == DialogResult.OK ? folderBrowserDialog.SelectedPath : cb_Source.Text;
        }

        private void btn_SearchTo_Click(object sender, EventArgs e)
        {
            cb_Directory.Text = Search();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (!FileSystem.DirectoryExists(cb_Source.Text))
            {
                MessageBox.Show("The source directory does not exist or incorrect.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!Path.IsPathRooted(cb_Directory.Text))
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
                UpdateProgressBar();
                Settings.Default.SourcePath = AddItemsToMemory(cb_Source);
                Settings.Default.DirectoryPath = AddItemsToMemory(cb_Directory);
                Settings.Default.Save();
                btn_Start.Text = "Stop loop";
            }
            else
            {
                Stop();
                CheckToStart();
            }
        }

        private void LoadItemsFromMemory(ComboBox comboBox, StringCollection stringCollection)
        {
            if (stringCollection != null && stringCollection.Count > 0)
            {
                comboBox.Items.AddRange(stringCollection.Cast<string>().ToArray());
            }
        }

        private StringCollection AddItemsToMemory(ComboBox comboBox)
        {
            var items = new StringCollection();
            if (!comboBox.Items.Contains(comboBox.Text))
            {
                comboBox.Items.Add(comboBox.Text);
            }
            foreach (string item in comboBox.Items)
            {
                if (!items.Contains(item))
                {
                    items.Add(item);
                }
            }
            return items;
        }

        private void Stop()
        {
            t_File.Stop();
            t_Progress.Stop();
            tickInterval = 0;
            pb_CopyTime.Value = 0;
            timeInterval = 0;
            btn_Start.Text = "Start loop";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                string path;
                var directoryInfo = new DirectoryInfo(cb_Source.Text);
                if (!cb_Overwrite.Checked)
                {
                    path = $"{cb_Directory.Text}\\{directoryInfo.Name}-" +
                                $"{DateTime.Now:yyyy.MM.dd.HH.mm.ss}";
                    FileSystem.CreateDirectory($"{path}");
                }
                else
                {
                    path = $"{cb_Directory.Text}\\{directoryInfo.Name}";
                    if (!Directory.Exists(path))
                        FileSystem.CreateDirectory(path);
                }
                FileSystem.CopyDirectory(cb_Source.Text, path, true);
                pb_CopyTime.Value = 100;
                ColorText($"\nCopied {cb_Source.Text} to {path} at {DateTime.Now:HH:mm:ss}", Color.Green);
                rtb_Logs.AppendText($"\nNext copy in {timeInterval} {unit}");
            }
            catch (Exception ex)
            {
                Stop();
                ColorText(ex.Message, Color.Red);
            }
        }

        private void ColorText(string text, Color color)
        {
            rtb_Logs.SelectionStart = rtb_Logs.TextLength;
            rtb_Logs.SelectionLength = 0;
            rtb_Logs.SelectionColor = color;
            rtb_Logs.AppendText($"\n{text}");
            rtb_Logs.SelectionColor = rtb_Logs.ForeColor;
        }

        private void value_Changed(object sender, EventArgs e)
        {
            CheckToStart();
        }

        private void CheckToStart()
        {
            btn_Start.Enabled = (!string.IsNullOrWhiteSpace(cb_Source.Text) && !string.IsNullOrWhiteSpace(cb_Directory.Text)
                            && nud_Time.Value > 0 && !string.IsNullOrEmpty(cb_Units.Text) || t_File.Enabled);
            if (!cb_Units.Items.Contains(cb_Units.Text))
            {
                cb_Units.Text = lastItemSelected;
            }
        }

        private void t_Progress_Tick(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            if (tickInterval == t_File.Interval)
            {
                pb_CopyTime.Value = 100;
                tickInterval = 0;
            }
            tickInterval += t_Progress.Interval;
            var estimatedTime = t_File.Interval - tickInterval;
            int percent = (int)(((double)estimatedTime / t_File.Interval) * pb_CopyTime.Maximum);
            //percent = Math.Max(0, Math.Min(100, percent));
            pb_CopyTime.Value = percent;
        }

        private void cb_Units_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastItemSelected = cb_Units.Text;
        }

        private void rtb_Logs_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.LinkText) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening website: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var lineSkip = 3;
            var path = $"{Environment.CurrentDirectory}\\Logs";
            if (!FileSystem.DirectoryExists(path))
            {
                FileSystem.CreateDirectory(path);
            }
            if (rtb_Logs.Lines.Length > lineSkip)
            {
                using (var logFile = File.CreateText($"{path}\\log{DateTime.Now:yyyy.MM.dd.HH.mm.ss}.txt"))
                {
                    for (int i = lineSkip; i < rtb_Logs.Lines.Length; i++)
                    {
                        logFile.WriteLine(rtb_Logs.Lines[i]);
                    }
                } 
            }
        }
    }
}
