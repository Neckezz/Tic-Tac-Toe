using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            formPopup newForm = new formPopup(); //pravi novi objekat to jest formu
            newForm.Show();//prikazuje novu formu
            this.Hide(); //sakriva staru

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); //izlazi iz aplikacije
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formPopup2 newForm2 = new formPopup2();
            newForm2.Show();
            this.Hide();
        }
    }
}
