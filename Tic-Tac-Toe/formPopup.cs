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
    public partial class formPopup : Form
    {
        List<Button> buttons;
        //lista koja se sastoji iz 9 dugmica
        int Player1Wins = 0, Player2Wins = 0; //brojaci pobeda
        Boolean checker;//checker koji provera ko je na potezu
        public formPopup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 oldForm = new Form1();
            oldForm.Show();
            this.Hide(); //Vraca nas u Main menu
        }

        private void button2_Click(object sender, EventArgs e) //restart
        {
            buttons = new List<Button> { button3, button4, button5, button6, button7, button8,
                button9, button10, button11 };//lista dugmica
            foreach (Button x in buttons) //prolazi kroz svako dugme i restartuje ga na pocetni polozaj
            {
                x.Text = "?";
                x.ForeColor = Color.White;
                x.BackColor = Color.DimGray;
                x.Enabled = true;
                checker = false;
            }
        }
        private void button_lockdown()
        {
            buttons = new List<Button> { button3, button4, button5, button6, button7, button8,
                button9, button10, button11 };
            foreach (Button lockdown in buttons)
            {
                lockdown.Enabled = false;
            }
        }

        private void whenClicked(object sender, EventArgs e) //vazi za 9 dugmica
        {
            var button = (Button)sender; // varijabla button prosledjuje listi Button
            if (checker == false) //prvi igrac
            {
                button.Text = "X";
                button.BackColor = Color.Red;
                checker = true;
            }
            else//drugi igrac
            {
                button.Text = "O";
                button.BackColor = Color.Blue;
                checker = false;
            }
            if (checker == false) //ispis na ekranu ko je trenutno na potezu
                label3.Text = "CurrentTurn:X";
            else
                label3.Text = "CurrentTurn:O";
            WinEvent();
        }

        private void WinEvent() //metoda kojom proveravamo ko je pobedio i povecava score
        {
            if(button3.Text== "X" && button6.Text == "X" && button9.Text == "X"||
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
                label1.Text = "Player1 Wins:" + Player1Wins;
                System.Windows.Forms.MessageBox.Show("Player1 Won");
                button_lockdown(); //metoda kojom zakljucavamo dugmice nakon pobednika
                
            }
            else if(
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
                Player2Wins++;
                label2.Text = "Player2 Wins:" + Player2Wins;
                System.Windows.Forms.MessageBox.Show("Player2 Won");
                button_lockdown();
            }
           
        }

        

    }
    }
    

