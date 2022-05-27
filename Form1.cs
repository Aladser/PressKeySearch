﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PressKeySearch
{
    public partial class Form1 : Form
    {
        //String path = "D:\\EPMAgent0.log";
        String path = "C:\\Users\\User\\Documents\\ProLAN\\EPMAgent\\EPMAgent0.log";
        String[] nicks = new String[4];
        StreamReader sr;
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл " + path + " не существвует. Укажите путь к файлу");
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Логи (*.log)|*.log|Все файлы (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            selectBox.SelectedIndex = 0;
            officeBox.SelectedIndex = 0;
            nicks[0] = "псевдоним: \'1\'";
            nicks[1] = "псевдоним: \'2\'";
            nicks[2] = "псевдоним: \'3\'";
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            sr = new StreamReader(path, Encoding.Default);
            String line;
            String quality = nicks[selectBox.SelectedIndex];
            String office = officeBox.Items[officeBox.SelectedIndex].ToString();

            infoField.Text = "";
            while ((line = sr.ReadLine()) != null)
            {
                if (officeBox.SelectedIndex == 5)
                {
                    if (line.Contains(quality))
                        infoField.Text += line + "\n";
                }
                else
                {
                    if (line.Contains(quality) && line.Contains(office))
                        infoField.Text += line + "\n";
                }

            }
        }

        private void aboutImage_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(aboutImage, "(c) Aladser 2022");
        }
    }
}
