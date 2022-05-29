using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {

        private int speed_vertical = 2;
        private int speed_hor = 2;
        private int score = 0;


        public Form1()
        {
            InitializeComponent();

            timer.Enabled = true;

            Cursor.Hide(); // прячет курсор
            this.FormBorderStyle = FormBorderStyle.None; // Для того, чтобы исчезла обводка
            this.TopMost = true; //Показывалась поверх других программ

            this.Bounds = Screen.PrimaryScreen.Bounds; //Установка экрана, подборка ширины и высоты самого экрана.

            gamePanel.Top = background.Bottom - (background.Bottom / 10); //Красная панелька всегда будет прижата к низу с отступом

            lose.Visible = false;
            lose.Left = (background.Width / 2) - (lose.Width / 2);
            lose.Top = (background.Height / 2) - (lose.Height / 2);

        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e) // Вызывает кнопку, на которой закрывается игра
        {
            if (e.KeyCode == Keys.Escape)
                this.Close(); // сам код указывает на Esc, чтобы закрыть

            if(e.KeyCode == Keys.R)
            {
                gameBall.Top = 50;
                gameBall.Left = 70;
                Result.Text = "Score: 0";
                timer.Enabled = true;
                score = 0;
                speed_hor = 2;
                speed_vertical = 2;
                lose.Visible = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gamePanel.Left = Cursor.Position.X - (gamePanel.Width / 2);

            gameBall.Left += speed_hor;
            gameBall.Top += speed_vertical;

            if (gameBall.Left <= background.Left)
                speed_hor *= -1;

            if (gameBall.Right >= background.Right)
                speed_hor *= -1;

            if (gameBall.Top <= background.Top)
                speed_vertical *= -1;

            if (gameBall.Bottom >= background.Bottom)
            {
                timer.Enabled = false;
                lose.Visible = true;
            }
                


            if (gameBall.Bottom >= gamePanel.Top && gameBall.Bottom <= gamePanel.Bottom && gameBall.Left >= gamePanel.Left && gameBall.Right <= gamePanel.Right)
            {
                speed_hor += 3;
                speed_vertical += 3;
                speed_vertical *= -1;
                score += 1;
                Result.Text = "Score: " + score.ToString();

                Random randColor = new Random();
                background.BackColor = Color.FromArgb(randColor.Next(150, 255), randColor.Next(150, 255), randColor.Next(150, 255));

            }
        }
    }
}
