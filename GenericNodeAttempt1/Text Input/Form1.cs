using Graph_Database_Access;
using Graph_Database_Access.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Input
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            List<Word> myWords = new List<Word>();
            var words = txtInput.Text.Split(' ');
            foreach(string wrd in words)
            {
                WordAccess was = new WordAccess();
                Word myWord = was.GetObject(wrd);
                if(myWord == null)
                {
                    myWord = was.InsertNewWord(wrd);
                }
                myWords.Add(myWord);

            }
        }
    }
}
