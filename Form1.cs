using Parser.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;
        public Form1()
        {
            InitializeComponent();
            string header = "Номер\tПріоритет\tБал\tПІБ";
            ListTitles.Items.Add(header);
            ListTitles.Items.Add("");
            AddUniversity();
            parser = new ParserWorker<string[]>(new AbitParser());
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
            
        }

        private void AddUniversity()
        {
            ComboBoxUniversity.Items.Add("КНУ");
            ComboBoxUniversity.Items.Add("КНЕУ");
            ComboBoxUniversity.Items.Add("КНТЕУ");
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            ListTitles.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Completed successfully!");
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            string numberOfUniversity = "";
            switch (ComboBoxUniversity.Text)
            {
                case "КНУ":
                    numberOfUniversity = "538076";
                    break;
                case "КНЕУ":
                    numberOfUniversity = "574403";
                    break;
                case "КНТЕУ":
                    numberOfUniversity = "543543";
                    break;
                default:
                    numberOfUniversity = "538076";
                    break;
            }
            parser.Settings = new AbitSettings(numberOfUniversity, 1, 20);



            ListTitles.Items.Clear();
            string header = "Номер\tПріоритет\tБал\tПІБ";
            ListTitles.Items.Add(header);
            ListTitles.Items.Add("");
            AbitParser.amountOfStudentsFirst = 0;
            parser.Start();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }

        private void Summary_Click(object sender, EventArgs e)
        {
            ListTitles.Items.Add("");
            string footer = "Загальна кількість людей з більшим балом: " + Convert.ToString(AbitParser.amountOfStudentsFirst);
            ListTitles.Items.Add(footer);
            ListTitles.Items.Add("");
        }
    }
}
