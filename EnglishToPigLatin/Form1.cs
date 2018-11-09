using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishToPigLatin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Global Variables
        string EnglishText;
        #endregion

        #region Procedures
        private static List<string> SplitEnglishText (string text)
        {
            List<string> textList = new List<string>();
            List<string> TotalList = new List<string>();


            for (int i = 0; i < text.Length; i++)
            {
                if ((text.Substring(i, 1) != " ") && (i != text.Length-1))
                {
                    textList.Add(text.Substring(i, 1));
                }
                else
                {
                    string s = "";
                    for (int x = 0; x < textList.Count; x++)
                    {
                        s += textList[x];
                    }

                    TotalList.Add(s);
                    textList.Clear();
                }
            }
            return TotalList;
        }
        private static List<string> ConvertEnglishListToPigLatin (List<string> list)
        {
            string s;
            List<string> finalList = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                s = list[i];
                s = s.ToLower();
                string firstChar = s.Substring(0, 1);
                s += firstChar;
                s = s.Substring(1, s.Length - 1);
                s += "ay";
                finalList.Add(s);
            }
            return finalList;
        }
        #endregion

        #region Event Handlers
        private void submitButton_Click(object sender, EventArgs e)
        {
            EnglishText = inputBox.Text;

            List<string> listTemp = SplitEnglishText(EnglishText);
            List<string> list = ConvertEnglishListToPigLatin(listTemp);
            string final = "";

            for (int i = 0; i < list.Count; i++)
            {
                final = final + list[i] + " ";
            }

            OutputLabel.Text = final;



        }
        #endregion
    }
}
