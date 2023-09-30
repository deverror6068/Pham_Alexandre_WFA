using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        private int duration = 60; // durée de du compte à rebours 
        private int duration2 = 4; // durée du timer pour les effets 
        private bool iscountdown = false;  
        private bool win = false; // booléen pour verifier si le joueur a gagné 


        int maxWidth; 
        int maxHeight;
        int startvalue = 0;

        int Score; // Score du joueur 
        int Highscore; //Meilleur score 
        private bool crash = false;  // booléen  pour vérifier si le joueur a perdu  en percutant sa tete au reste de son corps 
        private bool starved = false; // booléen  pour vérifier si le joueur n'a pas réussi a nourrir le serpent  dans le temps imparti 

        Random rand = new Random(); // valeur aléatoire pour  la génération de la nourriture et  pour la selection aléatoire des effets gagnés lors que le serpent mange 

        bool goLeft, goRight, goDown, goUp; // booléen pour les directions
        private Timer timer2; // timer pour le compte à rebours  de la nourriture
        private Timer timer3; // timer pour le compte rebours de l'affichage  des effets 

       
        public Form1()
        {
            InitializeComponent(); // initialisation des composantes du formulaire
            this.MaximizeBox = false; // empeche l'utilisateur d'agrandir la fenetre
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            this.Resize += Form1_Resize;  // Lie l'événement Resize à la méthode Form1_Resize

            new Settings();
        }


        private void CloseForm(object sender, EventArgs e) // fonction pour fermer le formulaire 
        {
            this.Close();
        }

        private void Form1_Resize(object sender, EventArgs e) // fonction pour conserver les meme proportions 
        {
           Size  Initsize = this.ClientSize = new System.Drawing.Size(760, 737);
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

        private void KeyIsDown(object sender, KeyEventArgs e) //fonction pour déterminer la direction de l'entrée récupérée 
        {
            DateTime currentTime = DateTime.Now; 
            TimeSpan moveInterval = TimeSpan.FromMilliseconds(100); // delai avant qu'une autre entrée soit prise en compte 
            if (currentTime - lastMoveTime >= moveInterval) // si l'entrée se passe apres le delai imparti
            {

                if (e.KeyCode == Keys.Left && Settings.directions != "right")
                {
                    goLeft = true; //gauche
                }


                if (e.KeyCode == Keys.Right && Settings.directions != "left")
                {
                    goRight = true; // droite 
                }

                if (e.KeyCode == Keys.Up && Settings.directions != "down")
                {
                    goUp = true; // bas 
                }

                if (e.KeyCode == Keys.Down && Settings.directions != "up")
                {
                    goDown = true; // haut 
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

        private void StartGame(object sender, EventArgs e) // réinitialisation du jeu: toutes les données (sauf le score) sont remises à zéro
        {
            this.picCanvas.Visible = true;
            this.LoosePicture.Visible = false;
            this.Victory.Visible = false;
            loose2.Visible = false;
            crash = false;
            starved = false;
            win = false;

        RestartGame(); //
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

        private void GameTimerEvent(object sender, EventArgs e) // traduction dans les mouvements du serpent de l'entrée
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

            for (int i = Snake.Count-1; i >= 0 ; i--) //parcours du serpent 
            {
                if (i == 0)
                {
                    switch(Settings.directions)
                    {
                        case "left":
                            Snake[i].X--; // modification des coordonnées  X et Y selon la direction
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
                        Snake[i].X = maxWidth; // permet au serpent de revenir  par le coté opposé de celui qu'il a pris lorsqu'il a quitté la zone de jeu 
                    }
                     
                    if (Snake[i].X > maxWidth) 
                    {
                        Snake[i].X = 0;
                    }
                     
                    if (Snake[i].Y < 0)           // permet au serpent de revenir  par le coté opposé de celui qu'il a pris lorsqu'il a quitté la zone de jeu 
                    { 
                        Snake[i].Y = maxHeight;
                    }

                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }

                    if (Snake[i].X == food.X && Snake[i].Y == food.Y) // si la tete du serpent se  trouve sur la nourriture 
                        {

                        EatFood(); // appel de la fonction gérant la taille du serpent et l'effet gagné  grace à la nourriture 

            }

                    for (int j=1; j < Snake.Count; j++) // parcours du serpent 
                    {

                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y) // si la tete est au meme emplacement qu'un emplacement du corps 
                        {
                            // temp1.Text = "" +i + Snake[i].X +""+ Snake[j].X;
                            //temp2.Text = "" + j + Snake[i].Y +""+Snake[j].Y;
                            // temp1.Text = "Collision détectée à l'indice " + i + " (" + Snake[i].X + ", " + Snake[i].Y + ") et " + j + " (" + Snake[j].X + ", " + Snake[j].Y + ")";
                            crash = true;
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

      

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e) // fonction qui permet d'afficher le serpent 
        {

            Graphics canvas = e.Graphics;

            Brush snakeColour; 

            for (int i = 0;i < Snake.Count;i++) // pour la taille du serprnt 
            {
                if (i== 0) // si c'est la tete du serpent 
                {
                    snakeColour = Brushes.Black;
                }
                else // si c'est le corps 
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

        private void RestartGame() // mise en place du jeu 
        {
            maxWidth = picCanvas.Width/Settings.Width - 1 ;
            maxHeight = picCanvas.Height/Settings.Height - 1 ;
            iscountdown = false; // neutralise le compte à rebours 
            this.gameTimer.Interval = 25; // mise en place de la vitesse de base 
            Snake.Clear(); // suppression du corps du serpent 
         

            Start.Enabled = false; // desactivation des bouttons pour pouvoir utiliser les controles correctement 
            Close.Enabled = false;
            Score = 0; // remise à zéro du score
            txtScore.Text = "Score : " + Score; 

            Circle head  = new Circle { X = 10, Y = 5 }; // création de la tete 
            Snake.Add(head); //ajout de la tete à la liste qui gere le corps du serpent 

            for (int i = 0; i < 10; i++) // création du corps initial du serpent 
            {
                Circle body = new Circle(); // creation d'un segment du corps 
                Snake.Add(body);// ajout du segment au corps
            }

            food = new Circle {X= rand.Next(2,maxWidth),Y = rand.Next(2,maxHeight) }; //généraion de la nourriture  dans un endroit aléatoire de la zone de jeu 

            gameTimer.Start();// enclenchement du timer du jeu (qui impacte la vitesse du serpent entre autre)
        }
        private void EatFood() // fonction qui gère la modifications du corps  ainsi que les effets gagnés 
        {
            Score += 1; // gain de 1 de score 

            txtScore.Text = "Score " + Score;

            Circle body = new Circle // création d'un nouveau segment du corps 
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };


         
           // if ((this.gameTimer.Interval) > 60) 
           // {
           //     this.gameTimer.Interval = 60;

           // }
           this.temp_3.Text = "" + this.gameTimer.Interval;
            

          



           // if ((int)(this.gameTimer.Interval) > 60)// limite la vitesse du jeu minimale afin que le jeu ne devienne pas injouable 
           // {
            //    this.gameTimer.Interval = 60;

           // }

            if ((this.gameTimer.Interval )< 1){ // limite la vitesse du jeu maximale pour la meme raison 
                this.gameTimer.Interval = 1;

            }
           // if ((this.gameTimer.Interval) > 60)
           // {
            //    this.gameTimer.Interval = 60;

          //  }

            Random rnd = new Random();
            string[] effectname = { "slow", "fast", "enlarge", "nothing", "shrink","doublepoint" }; // le choix va etre fait entre les différent effet de cette liste 

             

            int mIndex = rnd.Next(effectname.Length); // selection d'un indice aléatoire de la liste 
            string chosen = effectname[mIndex]; // récupération du nom 

           // Chosen.Text = chosen;

            if (chosen == "slow") // lenteur 
            {
                this.gameTimer.Interval = (int)((this.gameTimer.Interval * 1.5)); // la vitesse du jeu et ~ divisée par 0.5 

                if (gameTimer.Interval >= 30){ // limite la vitesse du jeu minimale afin que le jeu ne devienne pas injouable 
                    this.gameTimer.Interval = 30;
                }
                this.temp_3.Text = "" + this.gameTimer.Interval;
                Chosen.Visible = true; // affichage de l'effet gagné 
                Chosen.Text = "Vitesse X0.66"; 
                Chosen.ForeColor = Color.Blue;
                Effectdecay();// appel de la fonction qui va enlever le nom de l'effet au bout de quelques secondes 


            }

            if (chosen == "fast")        {          // multiplication de la vitesse par ~ 1.5    

                if ((int)((this.gameTimer.Interval * 0.95)) <= 0) // si la vitesse depasse la vitesse maximale acceptable 
                {
                    this.gameTimer.Interval = 1; // limitation a la vitesse maximale 


                }
                else
                {
                    this.gameTimer.Interval = (int)(this.gameTimer.Interval * 0.75); 
                    this.temp_3.Text = "" + this.gameTimer.Interval;
                    Chosen.Visible = true;// idem
                    Chosen.Text = "Vitesse X1.5"; 
                    Chosen.ForeColor = Color.Red;
                    Effectdecay(); // idem
                }

            }

            if (chosen == "enlarge") //agrandissement de la taille du serpent 
            {
                width.Text = "" + Snake.Count(); 


                for (int i = 0; i < 3; i++) { // augmentation de 3 de la taille du serpend (4 avec l'augmentation initiale)
                    Circle body1 = new Circle(); // création du segment 
                    Snake.Add(body1); // ajout au corps 
                }


                width.Text = "" + Snake.Count();
                Chosen.Visible = true;
                Chosen.Text = "Prise de Poid !";
                Chosen.ForeColor = Color.Red;
                Effectdecay();
            }


            if (chosen == "doublepoint")
            {
                if (Score == 10 || Score == 11) // si le score est >= à 11  grace au double de score 
                {
                    settimer(); // on enclenche le compte à rebours de la nourriture 
                }
                    Score += 1; // ajout  de 1 en  plus  du 1 initialement gagné 
                Chosen.Visible = true;
                Chosen.Text = "Score Doublé  !";
               Chosen.ForeColor = Color.Blue;
                Effectdecay();
            }

            txtScore.Text = "Score : " + Score;

            

            if (chosen == "shrink")
            {
               if (Snake.Count() > 6) { // le serpent a une taille minimale qui ne peut etre plus basse 
                    for (int i = 0; i < 3; i++) // reduction de 3 segment 
                    {

                        Snake.RemoveAt(Snake.Count() - 1);// reduction d'un segment 
                    }
                    width.Text = "" + Snake.Count();
                }
                Chosen.Visible = true;
                Chosen.Text = "Rétrécissement !";
                Chosen.ForeColor = Color.Blue;
                Effectdecay();
            }
            else
            {
                width.Text = "" + Snake.Count();
                Snake.Add(body);
                
            }


            if (chosen == "nothing") // rien , statu quo 
            {
                Chosen.Visible = true;
                Chosen.Text = "Rien !";
                Chosen.ForeColor = Color.Gray;
                Effectdecay();
            }


            if (Score >= 11  &&  iscountdown == true ) // si le serpent a déja enclenché le compte à rebours 

            {
                duration = 60; // remet le décompte à 60s 
            }

            if (Score == 11 && iscountdown == false) // si le serpent atteint un certain score on augment la difficulté avec ce compte à rebours 
            {
                settimer();
            }

            if (Score >= 25) // si le serpent fait suffisament de point il gagne 
            {

                win = true;
                GameOver(); // appel  de la fonction vérifiant les victoires / défaites 
                
            }


            
            width.Text = ""+Snake.Count();
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) }; // on renouvelle la nourriture dans un endroit aléatoire de la zone de départ 
        }

        private void settimer()     // mise en route du compte à rebours de la nourriture 
        {
            iscountdown = true;       // le compte a rebours a été enclenché 
            timer2 = new System.Windows.Forms.Timer();
            timer2.Tick += new EventHandler(count_down);    // tick gérés par count_down 
            timer2.Interval = 700;      // intervalle entre chaque tick 
            timer2.Start();         // activation du timer
            timeleft.Text = duration.ToString();
        }

        private void count_down(object sender, EventArgs e)
        {

            if (duration == 0)  // si le temps est écoulé le serpent est mort de faim et le joueur  a perdu 
            {
                timer2.Stop();
                starved = true;
        GameOver();

            }
            else if (duration > 0) // si le décompte n'est pas écoulé 
            {
                duration--; // on enlève 1 seconde 
              timeleft.Text = duration.ToString();
            }


        }

        private void scorestarved_Click(object sender, EventArgs e)
        {

        }

        private void Effectdecay() {  // initialisation d'un timer qui enlevera le nom du bonus gagné au bout de quelques secondes 
            timer3 = new System.Windows.Forms.Timer();
            timer3.Tick += new EventHandler(count_downeffect);
            timer3.Interval = 1000;
            timer3.Start();
       
  
        }


        private void count_downeffect(object sender, EventArgs e) // meme principe que le timing précèdent 
        {
            {
                if (duration2 == 0)
                {
                    timer3.Stop();
                    Chosen.Visible = false;
                    duration2 = 4;



                }
                else if (duration2 > 0)
                {
                    duration2--;

                }


            }
        }
        private void GameOver() // fonction de fin de jeu (verification victoire defaite)
        {
            duration = 60; // remise du compte à rebours de la nourriture à la valeur de base 
            gameTimer.Stop(); // arret du timer principale 
            timeleft.Text = "" ;//+iscountdown
            if (iscountdown == true ) // arret du timer des effets 
            {
                timer2.Stop();
            }
            Start.Enabled = true;// réactivation des bouttons du menu 
            Close.Enabled = true;
         

            if (crash == true) // si le serpent s'est percuté lui meme
            {
                  this.picCanvas.Visible = false; //affichage de l'image de défaite correspondante 
                this.LoosePicture.Visible = true;
            }

            if (starved == true) // si le serpent est mort de faim 
            {
                this.picCanvas.Visible = false; //affichage de l'image de défaite correspondante 
                loose2.Visible = true;
                
            }


            if (win == true) // si le serpent a obtenu tout les points nécessaires
            {
                this.picCanvas.Visible=false;
                this.Victory.Visible = true; //affichage de l'image  correspondante 
            }

            if (Score > Highscore)// si le score réalisé est plus grand que le précèdent score 
            {
               if (win == true) // si le nouveau score est un score de victoire on l' affiche  en vert 
                {
                    Highscore = Score; 

                    txtHighScore.Text = "Meilleur Score: " + Environment.NewLine + Highscore;
                    txtHighScore.ForeColor = Color.Green;
                    txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
                }
                else
                {
                    Highscore = Score;

                    txtHighScore.Text = "Meilleur Score: " + Environment.NewLine + Highscore;
                    txtHighScore.ForeColor = Color.Maroon;
                    txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
                }
                
            }
        }
    }
    }
