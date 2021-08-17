using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form2 : Form
    {
        Rectangle racket;//our racket sprite
        Rectangle ball;//our ball sprite
        int dx, dy;
        int hitCount;
        public Form2()
        {
            InitializeComponent();
            racket = new Rectangle(120, 400, 60, 10);//sprite initialization
            ball = new Rectangle(140, 10, 20, 20);
            dx = 5;//initial speeds
            dy = 5;
            hitCount = 0;
        }
        private void DrawBall(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(new SolidBrush(Color.Red), ball);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//for smoother graphics/shapes
            e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), racket);
            e.Graphics.DrawString("score: " + hitCount, DefaultFont, new SolidBrush(Color.Black), new Point(1, 1));

            DrawBall(e);//draws the ball
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            racket.X = e.X;
            if (racket.Right > pictureBox1.Right) { racket.X = pictureBox1.Right - racket.Width; }
            Refresh();//refresh the control to display the new position of the racket
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 5; //sets the frequency of elapsed events in milliseconds, important to set it 1 ms for smooth animation
            MoveBall();//call move ball to update location
            Refresh();//refresh the environment
        }

        private void MoveBall()//this method handles ball movement within the screen
        {
            if (ball.X + dx < 0)
            {
                dx += 10;
            }
            if (ball.X + dx >= pictureBox1.Width)
            {
                dx -= 10;
            }
            if (ball.Y + dy < 0)
            {
                dy += 5;
                if (dy == 0) { dy += 5; }
            }
            if (ball.Y + dy >= pictureBox1.Height)//game over handling if the ball goes past the racket & collides with the bottom of the screen
            {
                dx = 0;//set the speeds to zero
                dy = 0;

                var gameOver = MessageBox.Show("GAME OVER, YOUR SCORE : "+ hitCount, "Message", MessageBoxButtons.OK);//show a message displaying game over
                if (gameOver == System.Windows.Forms.DialogResult.OK)
                {
                    Close();//close the program
                }
            }
            if (ball.IntersectsWith(racket))//COLLISION DETECTED!
            {
                dy -= 10;
                hitCount += 1;//increment after every hit
            }
            ball.X = ball.X + dx;//update the ball x position
            ball.Y = ball.Y + dy;//update the ball y position
        }
    }
}
