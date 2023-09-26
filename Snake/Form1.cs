using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {



        private List<Circle>Snake = new List<Circle>();
        private DateTime lastMoveTime = DateTime.Now;
        private Circle food = new Circle();

        int maxWidth; 
        int maxHeight;
        int startvalue = 0;

        int Score;
        int Highscore;

        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;
        public Form1()
        {
            InitializeComponent();

            new Settings();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan moveInterval = TimeSpan.FromMilliseconds(100);
            if (currentTime - lastMoveTime >= moveInterval)
            {

                if (e.KeyCode == Keys.Left && Settings.directions != "right")
                {
                    goLeft = true;
                }


                if (e.KeyCode == Keys.Right && Settings.directions != "left")
                {
                    goRight = true;
                }

                if (e.KeyCode == Keys.Up && Settings.directions != "down")
                {
                    goUp = true;
                }

                if (e.KeyCode == Keys.Down && Settings.directions != "up")
                {
                    goDown = true;
                }
                lastMoveTime = currentTime;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }


            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            this.picCanvas.Visible = true;
            RestartGame();
        }

        private void TakeCapture(object sender, EventArgs e)
        {

            startvalue = startvalue + 1; 

            if (startvalue %2 == 0)
            {
                gameTimer.Start();
            }
            else
            {
                gameTimer.Stop();
            }

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft)
            {
                    Settings.directions = "left";
            }
            if (goRight)
            {

                Settings.directions = "right";
            }

            if (goDown)
            {
                Settings.directions = "down";
            }

            if (goUp)
            {
                Settings.directions = "up";
            }

            for (int i = Snake.Count-1; i >= 0 ; i--)
            {
                if (i == 0)
                {
                    switch(Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }

                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }

                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }

                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }

                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }

                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                        {

                        EatFood();

            }

                    for (int j=1; j < Snake.Count; j++)
                    {

                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                           // temp1.Text = "" +i + Snake[i].X +""+ Snake[j].X;
                            //temp2.Text = "" + j + Snake[i].Y +""+Snake[j].Y;
                           // temp1.Text = "Collision détectée à l'indice " + i + " (" + Snake[i].X + ", " + Snake[i].Y + ") et " + j + " (" + Snake[j].X + ", " + Snake[j].Y + ")";
                            GameOver();
                        }
                    }

        }
                else
                {
                    Snake[i].X = Snake[i-1].X;
                    Snake[i].Y = Snake[i-1].Y;
                    //temp2.Text = "" + i + Snake[i].Y + "" + Snake[i].X;
                }
            }

            picCanvas.Invalidate();
        }

      

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {

            Graphics canvas = e.Graphics;

            Brush snakeColour; 

            for (int i = 0;i < Snake.Count;i++)
            {
                if (i== 0)
                {
                    snakeColour = Brushes.Black;
                }
                else
                {
                    snakeColour = Brushes.DarkGreen;
                }
                canvas.FillEllipse(snakeColour, new Rectangle(
                Snake[i].X * Settings.Width,
                Snake[i].Y * Settings.Height,
                Settings.Width, Settings.Height));

            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                (
                 food.X * Settings.Width,
                food.Y * Settings.Height,
                Settings.Width, Settings.Height
                ));

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void RestartGame()
        {
            maxWidth = picCanvas.Width/Settings.Width - 1 ;
            maxHeight = picCanvas.Height/Settings.Height - 1 ;

            Snake.Clear();
         

            Start.Enabled = false;
            Capture.Enabled = false;
            Score = 0;
            txtScore.Text = "Score : " + Score;

            Circle head  = new Circle { X = 10, Y = 5 };
            Snake.Add(head);

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle {X= rand.Next(2,maxWidth),Y = rand.Next(2,maxHeight) };

            gameTimer.Start();
        }
        private void EatFood()
        {
            Score += 1;

            txtScore.Text = "Score " + Score;

            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };


         
            if ((this.gameTimer.Interval) > 60)
            {
                this.gameTimer.Interval = 60;

            }
            this.temp_3.Text = "" + this.gameTimer.Interval;
            

            if ((int)((this.gameTimer.Interval * 0.75))<=0)
            {
                this.gameTimer.Interval = 1;


            }else
            {
                this.gameTimer.Interval = (int)((this.gameTimer.Interval * 0.75));

            }

            this.temp_3.Text = ""+ this.gameTimer.Interval;



            if ((int)(this.gameTimer.Interval) == 0)
            {
                this.gameTimer.Interval = 1;

            }
            if ((int)(this.gameTimer.Interval) > 60)
            {
                this.gameTimer.Interval = 60;

            }

            if ((this.gameTimer.Interval )< 1){
                this.gameTimer.Interval = 1;

            }
            if ((this.gameTimer.Interval) > 60)
            {
                this.gameTimer.Interval = 60;

            }


            Snake.Add(body );
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }
        private void GameOver()
        {
            gameTimer.Stop();
            Start.Enabled = true;
            Capture.Enabled = true;
          //  this.picCanvas.Visible = false;
            //this.LoosePicture.Visible = true;

            if (Score > Highscore)
            {
                Highscore = Score;

                txtHighScore.Text = "High Score: " + Environment.NewLine + Highscore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
                
            }
        }
    }
    }
