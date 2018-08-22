﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RegularTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void RegStart()
        {
            string s = richTextBox2.Text;
            string Reg = richTextBox1.Text.Trim();

            //Reg =Reg.Replace('\\',R);
            try
            {
                Regex regex = new Regex(Reg);

                Match match = regex.Match(s);
                richTextBox3.Text = "";
                if (match.Success)
                {
                    richTextBox3.ForeColor = Color.Blue;
                    for (int i = 0; i < match.Groups.Count; i++)
                    {
                        richTextBox3.Text += match.Groups[0].Value.ToString() + "\n";
                    }
                }
                else {
                    richTextBox3.ForeColor = Color.Black;
                    richTextBox3.Text = "нет совпадений !";
                }
            }
            catch (Exception E)
            {
                richTextBox3.ForeColor = Color.Red;
                richTextBox3.Text = "Неправильное выражение:\n" + E.Message;
            }
            //-----------------
            richTextBox4.Text = "";
            try{
             Regex regex = new Regex(Reg);
             MatchCollection matchcollection = regex.Matches(s); 
             for (int i = 0; i < matchcollection.Count; i++)
             {
                 richTextBox4.ForeColor = Color.Blue;
                 richTextBox4.Text += matchcollection[i].Value + "\n";
             }
             if (matchcollection.Count < 1)
             {
                 richTextBox4.ForeColor = Color.Black;
                 richTextBox4.Text = "нет совпадений !";
             }

                    }
            catch (Exception E)
            {
                richTextBox4.ForeColor = Color.Red;
            richTextBox4.Text="Неправильное выражение:\n"+E.Message;

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            RegStart();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            RegStart();
        }


    }

    
}
