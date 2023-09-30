using System.Windows.Forms;

namespace Snake
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Start = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.LoosePicture = new System.Windows.Forms.PictureBox();
            this.temp1 = new System.Windows.Forms.Label();
            this.temp2 = new System.Windows.Forms.Label();
            this.temp_3 = new System.Windows.Forms.Label();
            this.timeleft = new System.Windows.Forms.Label();
            this.Chosen = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.Label();
            this.loose2 = new System.Windows.Forms.PictureBox();
            this.scorestarved = new System.Windows.Forms.Label();
            this.Victory = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoosePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loose2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Victory)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Start.Image = ((System.Drawing.Image)(resources.GetObject("Start.Image")));
            this.Start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Start.Location = new System.Drawing.Point(558, 23);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(133, 54);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.StartGame);
            // 
            // Close
            // 
            this.Close.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Close.Image = ((System.Drawing.Image)(resources.GetObject("Close.Image")));
            this.Close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Close.Location = new System.Drawing.Point(558, 83);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(133, 54);
            this.Close.TabIndex = 1;
            this.Close.Text = "Quitter";
            this.Close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.CloseForm);
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.Gainsboro;
            this.picCanvas.Image = ((System.Drawing.Image)(resources.GetObject("picCanvas.Image")));
            this.picCanvas.Location = new System.Drawing.Point(30, 23);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(505, 598);
            this.picCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCanvas.TabIndex = 2;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(577, 162);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(87, 26);
            this.txtScore.TabIndex = 3;
            this.txtScore.Text = "Score: 0\r\n";
            this.txtScore.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtHighScore
            // 
            this.txtHighScore.AutoSize = true;
            this.txtHighScore.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighScore.Location = new System.Drawing.Point(577, 202);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.Size = new System.Drawing.Size(87, 26);
            this.txtHighScore.TabIndex = 4;
            this.txtHighScore.Text = "Score: 0\r\n";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 25;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // LoosePicture
            // 
            this.LoosePicture.Image = ((System.Drawing.Image)(resources.GetObject("LoosePicture.Image")));
            this.LoosePicture.Location = new System.Drawing.Point(30, 23);
            this.LoosePicture.Name = "LoosePicture";
            this.LoosePicture.Size = new System.Drawing.Size(505, 598);
            this.LoosePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoosePicture.TabIndex = 5;
            this.LoosePicture.TabStop = false;
            this.LoosePicture.Visible = false;
            // 
            // temp1
            // 
            this.temp1.AutoSize = true;
            this.temp1.Location = new System.Drawing.Point(656, 548);
            this.temp1.Name = "temp1";
            this.temp1.Size = new System.Drawing.Size(35, 13);
            this.temp1.TabIndex = 6;
            this.temp1.Text = "label1";
            // 
            // temp2
            // 
            this.temp2.AutoSize = true;
            this.temp2.Location = new System.Drawing.Point(612, 548);
            this.temp2.Name = "temp2";
            this.temp2.Size = new System.Drawing.Size(35, 13);
            this.temp2.TabIndex = 7;
            this.temp2.Text = "label1";
            // 
            // temp_3
            // 
            this.temp_3.AutoSize = true;
            this.temp_3.Location = new System.Drawing.Point(606, 517);
            this.temp_3.Name = "temp_3";
            this.temp_3.Size = new System.Drawing.Size(35, 13);
            this.temp_3.TabIndex = 8;
            this.temp_3.Text = "label1";
            // 
            // timeleft
            // 
            this.timeleft.AutoSize = true;
            this.timeleft.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeleft.Location = new System.Drawing.Point(627, 328);
            this.timeleft.Name = "timeleft";
            this.timeleft.Size = new System.Drawing.Size(0, 22);
            this.timeleft.TabIndex = 9;
            // 
            // Chosen
            // 
            this.Chosen.AutoSize = true;
            this.Chosen.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chosen.Location = new System.Drawing.Point(599, 263);
            this.Chosen.Name = "Chosen";
            this.Chosen.Size = new System.Drawing.Size(0, 22);
            this.Chosen.TabIndex = 10;
            // 
            // width
            // 
            this.width.AutoSize = true;
            this.width.Location = new System.Drawing.Point(656, 517);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(35, 13);
            this.width.TabIndex = 11;
            this.width.Text = "label1";
            // 
            // loose2
            // 
            this.loose2.Image = ((System.Drawing.Image)(resources.GetObject("loose2.Image")));
            this.loose2.Location = new System.Drawing.Point(30, 23);
            this.loose2.Name = "loose2";
            this.loose2.Size = new System.Drawing.Size(505, 598);
            this.loose2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loose2.TabIndex = 12;
            this.loose2.TabStop = false;
            this.loose2.Tag = "";
            this.loose2.Visible = false;
            // 
            // scorestarved
            // 
            this.scorestarved.AutoSize = true;
            this.scorestarved.BackColor = System.Drawing.Color.White;
            this.scorestarved.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scorestarved.Location = new System.Drawing.Point(227, 448);
            this.scorestarved.Name = "scorestarved";
            this.scorestarved.Size = new System.Drawing.Size(87, 26);
            this.scorestarved.TabIndex = 13;
            this.scorestarved.Text = "Score: 0\r\n";
            this.scorestarved.Visible = false;
            this.scorestarved.Click += new System.EventHandler(this.scorestarved_Click);
            // 
            // Victory
            // 
            this.Victory.Image = ((System.Drawing.Image)(resources.GetObject("Victory.Image")));
            this.Victory.Location = new System.Drawing.Point(30, 23);
            this.Victory.Name = "Victory";
            this.Victory.Size = new System.Drawing.Size(505, 598);
            this.Victory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Victory.TabIndex = 14;
            this.Victory.TabStop = false;
            this.Victory.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(760, 737);
            this.Controls.Add(this.Victory);
            this.Controls.Add(this.scorestarved);
            this.Controls.Add(this.loose2);
            this.Controls.Add(this.width);
            this.Controls.Add(this.Chosen);
            this.Controls.Add(this.timeleft);
            this.Controls.Add(this.temp_3);
            this.Controls.Add(this.temp2);
            this.Controls.Add(this.temp1);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.LoosePicture);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Snake";
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoosePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loose2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Victory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtHighScore;
        private System.Windows.Forms.Timer gameTimer;
        private PictureBox LoosePicture;
        private Label temp1;
        private Label temp2;
        private Label temp_3;
        private Label timeleft;
        private Label Chosen;
        private Label width;
        private PictureBox loose2;
        private Label scorestarved;
        private PictureBox Victory;
    }
}

