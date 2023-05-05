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
    public partial class formPopup2 : Form
    {
        List<Button> buttons; //lista koja se sastoji iz 9 dugmica
        Random random = new Random(); // objekat koji koristimo za nasumican broj
        int Player1Wins = 0, CPUWins = 0; //brojaci pobeda
        public formPopup2()
        {
            InitializeComponent();
            RestartGame();
        }

        private void button1_Click(object sender, EventArgs e) //vraca nas u meni
        {
            Form1 oldForm = new Form1();
            oldForm.Show();
            this.Hide();
        }
        private void button_lockdown() //zakljucava dugmice nakon utvrdjene pobede
        {
            foreach (Button lockdown in buttons)
            {
                lockdown.Enabled = false;
            }
        }
        private void RestartGame() //metoda U KOJOJ SE NALAZI LISTA DUGMICA,te se zbog toga mora pozvati u liniji 71
        {
            buttons = new List<Button> { button3, button4, button5, button6, button7, button8,
                button9, button10, button11 };
            foreach (Button reset in buttons) 
            {
                reset.Text = "?";
                reset.ForeColor = Color.White;
                reset.BackColor = Color.DimGray;
                reset.Enabled = true;
            }
        }


        private void whenClicked(object sender, EventArgs e) //sta se desava kada kliknemo
        {
            //nas potez
            var button = (Button)sender;
            button.Text = "X";
            button.BackColor = Color.Red;
            button.Enabled = false;
            buttons.Remove(button); //izbacuje dugme koje smo kliknuli da ne bi CPU preko njega kliknuo

            //cpu potez
            if (buttons.Count > 0) // proveravamo da li je preostalo slobodnih dugmica
            {
                int index = random.Next(buttons.Count); //nasumicno izabere neko dugme iz liste
                buttons[index].Enabled = false;
                buttons[index].Text = "O";
                buttons[index].BackColor = Color.Blue;
                buttons.RemoveAt(index); //izbacuje dugme koje je koristili da ne bi dva puta kliknuo na isto
            }
            WinEvent();
        }

        private void Restart(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void WinEvent() //metoda kojom proveravamo ko je pobedio i povecava score
        {
            if (button3.Text == "X" && button6.Text == "X" && button9.Text == "X" ||
               button3.Text == "X" && button4.Text == "X" && button5.Text == "X" ||
               button3.Text == "X" && button7.Text == "X" && button11.Text == "X" ||
               button9.Text == "X" && button10.Text == "X" && button11.Text == "X" ||
               button9.Text == "X" && button7.Text == "X" && button5.Text == "X" ||
               button5.Text == "X" && button8.Text == "X" && button11.Text == "X" ||
               button4.Text == "X" && button7.Text == "X" && button10.Text == "X" ||
               button6.Text == "X" && button7.Text == "X" && button8.Text == "X"
               )
            {
                Player1Wins++;
                label1.Text = "Player1 Wins" + Player1Wins;
                System.Windows.Forms.MessageBox.Show("Player1 Won");
                button_lockdown();

            }
            else if (
               button3.Text == "O" && button6.Text == "O" && button9.Text == "O" ||
               button3.Text == "O" && button4.Text == "O" && button5.Text == "O" ||
               button3.Text == "O" && button7.Text == "O" && button11.Text == "O" ||
               button9.Text == "O" && button10.Text == "O" && button11.Text == "O" ||
               button9.Text == "O" && button7.Text == "O" && button5.Text == "O" ||
               button5.Text == "O" && button8.Text == "O" && button11.Text == "O" ||
               button4.Text == "O" && button7.Text == "O" && button10.Text == "O" ||
               button6.Text == "O" && button7.Text == "O" && button8.Text == "O"
                )
            {
                CPUWins++;
                label2.Text = "CPU Wins" + CPUWins;
                System.Windows.Forms.MessageBox.Show("CPU Won");
                button_lockdown();
            }

        }
    }
}
