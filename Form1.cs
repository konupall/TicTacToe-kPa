using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool xPlayerTurn = true;
        int turnCount = 0;
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeCells();
        }

        private void InitializeGrid()
        {
            Grid.BackColor = Color.LightCoral;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
        }

        private void RestartGame()
        {
            InitializeCells();
            turnCount = 0;
        }


        private void InitializeCells()
        {
            string labelName;
            for (int i = 1; i <= 9; i++)
            {
                labelName = "label" + i;
                Grid.Controls[labelName].Text = String.Empty;
                Grid.Controls[labelName].BackColor = Color.LightGreen;
            }
        }

        private void Player_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if (label.Text != String.Empty)
            {
                return;
            }

            if (xPlayerTurn)
            {
                label.Text = "X";
                play_sound("whatareudoin");
            }
            else
            {
                label.Text = "O";
                play_sound("whatareudoin2");
            }


            turnCount++;
            CheckForWin();
            CheckForDraw();
            xPlayerTurn = !xPlayerTurn;
        }

        // Trying to get this to work
        //private void RandSound()
        //{
        //    string[] files = Directory.GetFiles("path");
        //    Random rnd = new Random(Guid.NewGuid().GetHashCode());
        //    int choice = rnd.Next(0, files.Length - 1);
        //    string soundFile = files[choice];
        //    System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundFile);
        //    player.Play();
        //}

        private void CheckForWin()
        {
            if (
                    (label1.Text == label2.Text && label2.Text == label3.Text && label1.Text != String.Empty) ||
                    (label4.Text == label5.Text && label5.Text == label6.Text && label4.Text != String.Empty) ||
                    (label7.Text == label8.Text && label8.Text == label9.Text && label7.Text != String.Empty) ||
                    (label1.Text == label4.Text && label4.Text == label7.Text && label1.Text != String.Empty) ||
                    (label2.Text == label5.Text && label5.Text == label8.Text && label2.Text != String.Empty) ||
                    (label3.Text == label6.Text && label6.Text == label9.Text && label3.Text != String.Empty) ||
                    (label1.Text == label5.Text && label5.Text == label9.Text && label1.Text != String.Empty) ||
                    (label3.Text == label5.Text && label5.Text == label7.Text && label3.Text != String.Empty)
                )
            {
                GameOver();
            }
        }

        private void WinnerCellsChangeColor()
        {
            if (label1.Text == label2.Text && label1.Text == label3.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label2, label3, Color.Blue);
            }
            else if (label4.Text == label5.Text && label4.Text == label6.Text && label4.Text != "")
            {
                ChangeCellColors(label4, label5, label6, Color.Blue);
            }
            else if (label7.Text == label8.Text && label7.Text == label9.Text && label7.Text != "")
            {
                ChangeCellColors(label7, label8, label9, Color.Blue);
            }
            else if (label1.Text == label4.Text && label1.Text == label7.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label4, label7, Color.DarkBlue);
            }
            else if (label2.Text == label5.Text && label2.Text == label8.Text && label2.Text != "")
            {
                ChangeCellColors(label2, label5, label8, Color.DarkBlue);
            }
            else if (label3.Text == label6.Text && label3.Text == label9.Text && label3.Text != "")
            {
                ChangeCellColors(label3, label6, label9, Color.DarkBlue);
            }
            else if (label1.Text == label5.Text && label1.Text == label9.Text && label1.Text != "")
            {
                ChangeCellColors(label1, label5, label9, Color.LightBlue);
            }
            else if (label3.Text == label5.Text && label3.Text == label7.Text && label3.Text != "")
            {
                ChangeCellColors(label3, label5, label7, Color.LightBlue);
            }
        }

        private void ChangeCellColors(Label firstLabel, Label secondLabel, Label thirdLabel, Color color)
        {
            firstLabel.BackColor = color;
            secondLabel.BackColor = color;
            thirdLabel.BackColor = color;
        }

        private void play_sound(string soundName)
        {
            System.IO.Stream str = (System.IO.Stream)Properties.Resources.ResourceManager.GetObject(soundName);
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }

        private void CheckForDraw()
        {
            if (turnCount == 9)
            {
                play_sound("draw_sound");
                MessageBox.Show("Draw!");
                RestartGame();
            }
        }

        private void GameOver()
        {
            string winner;
            if (xPlayerTurn)
            {
                winner = "X";
            }
            else
            {
                winner = "O";
            }
            WinnerCellsChangeColor();
            play_sound("win_sound");
            MessageBox.Show(winner  + " wins!");
            RestartGame();
        }
    }
}