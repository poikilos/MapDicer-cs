﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MapDicer
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class EditorSettingsWindow : Window
    {
        public EditorSettingsWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.readSettings();
        }

        private void readSettings()
        {
            this.LastConnectionStringTB.Text = Properties.Settings.Default.LastConnectionString;
        }

        private void writeSettings()
        {
            Properties.Settings.Default.LastConnectionString = this.LastConnectionStringTB.Text.Trim();
            Properties.Settings.Default.Save();
            // MessageBox.Show(String.Format("Saved {0}", Properties.Settings.Default.LastConnectionString));
            // Properties.Settings.Default.Reload();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            this.writeSettings();
            this.DialogResult = true;
            this.Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.readSettings();
            this.DialogResult = false;
            this.Close();
        }
    }
}