using FileBackApp.Lib;
using FileBackAppGUI.Properties;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBackAppGUI
{
    public partial class MainForm : Form
    {
        string lastItemSelected;
        List<string> logs = new List<string>();
        BackupService backupService = new BackupService();

        public MainForm()
        {
            InitializeComponent();
            cb_Units.SelectedIndex = 1;
            rtb_Logs.AppendText($"Backapp launched at {DateTime.Now:HH:mm:ss}\nFound a bug? Write here: " +
                $"https://github.com/CatNuton/Backapp/issues\n");
            LoadItemsFromMemory(cb_Source, Settings.Default.SourcePath);
            LoadItemsFromMemory(cb_Directory, Settings.Default.DirectoryPath);
            backupService.OnStart += (ea) =>
            {
                btn_Start.Text = "Stop loop";
            };
            backupService.OnStop += (ea) =>
            {
                btn_Start.Text = "Start loop";
            };
            backupService.OnLog += (ea) =>
            {
                logs.Add(ea.Message);
                ColorText(ea.Message, Color.FromName(ea.Color.ToString()));
            };
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
            if (!backupService.Enabled)
            {
                var unitChar = cb_Units.Text.ToLower().ToCharArray()[0].ToString();
                backupService.Source = cb_Source.Text;
                backupService.Dir = cb_Directory.Text;
                backupService.Time = (int)nud_Time.Value;
                backupService.Units = unitChar;
                backupService.Overwrite = cb_Overwrite.Checked;
                backupService.Archive = cb_Archive.Checked;
                backupService.Start();
                Settings.Default.SourcePath = AddItemsToMemory(cb_Source);
                Settings.Default.DirectoryPath = AddItemsToMemory(cb_Directory);
                Settings.Default.Save();
            }
            else
            {
                Stop();
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
            backupService.Stop();
            CheckToStart();
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
                            && nud_Time.Value > 0 && !string.IsNullOrEmpty(cb_Units.Text) || backupService != null);
            if (!cb_Units.Items.Contains(cb_Units.Text))
            {
                cb_Units.Text = lastItemSelected;
            }
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
            if (logs.Count > 0)
            {
                var path = $"{Environment.CurrentDirectory}\\Logs";
                if (!FileSystem.DirectoryExists(path))
                {
                    FileSystem.CreateDirectory(path);
                }
                using (var logFile = File.CreateText($"{path}\\log-{DateTime.Now:yyyy.MM.dd.HH.mm.ss}.txt"))
                {
                    for (int i = 0; i < logs.Count; i++)
                    {
                        logFile.WriteLine(logs[i]);
                    }
                }
            }
        }
    }
}
