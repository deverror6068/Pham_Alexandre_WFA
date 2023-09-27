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
            this.Capture = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoosePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Start.Image = ((System.Drawing.Image)(resources.GetObject("Start.Image")));
            this.Start.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.Start.Location = new System.Drawing.Point(615, 23);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(133, 54);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.StartGame);
            // 
            // Capture
            // 
            this.Capture.Enabled = false;
            this.Capture.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Capture.Location = new System.Drawing.Point(615, 83);
            this.Capture.Name = "Capture";
            this.Capture.Size = new System.Drawing.Size(133, 54);
            this.Capture.TabIndex = 1;
            this.Capture.Text = "Capture";
            this.Capture.UseVisualStyleBackColor = true;
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
            this.txtScore.Location = new System.Drawing.Point(616, 164);
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
            this.txtHighScore.Location = new System.Drawing.Point(616, 199);
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
            this.temp1.Location = new System.Drawing.Point(650, 276);
            this.temp1.Name = "temp1";
            this.temp1.Size = new System.Drawing.Size(35, 13);
            this.temp1.TabIndex = 6;
            this.temp1.Text = "label1";
            // 
            // temp2
            // 
            this.temp2.AutoSize = true;
            this.temp2.Location = new System.Drawing.Point(650, 315);
            this.temp2.Name = "temp2";
            this.temp2.Size = new System.Drawing.Size(35, 13);
            this.temp2.TabIndex = 7;
            this.temp2.Text = "label1";
            // 
            // temp_3
            // 
            this.temp_3.AutoSize = true;
            this.temp_3.Location = new System.Drawing.Point(650, 364);
            this.temp_3.Name = "temp_3";
            this.temp_3.Size = new System.Drawing.Size(35, 13);
            this.temp_3.TabIndex = 8;
            this.temp_3.Text = "label1";
            // 
            // timeleft
            // 
            this.timeleft.AutoSize = true;
            this.timeleft.Location = new System.Drawing.Point(653, 422);
            this.timeleft.Name = "timeleft";
            this.timeleft.Size = new System.Drawing.Size(35, 13);
            this.timeleft.TabIndex = 9;
            this.timeleft.Text = "label1";
            // 
            // Chosen
            // 
            this.Chosen.AutoSize = true;
            this.Chosen.Location = new System.Drawing.Point(653, 471);
            this.Chosen.Name = "Chosen";
            this.Chosen.Size = new System.Drawing.Size(24, 13);
            this.Chosen.TabIndex = 10;
            this.Chosen.Text = "text";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(760, 737);
            this.Controls.Add(this.width);
            this.Controls.Add(this.Chosen);
            this.Controls.Add(this.timeleft);
            this.Controls.Add(this.temp_3);
            this.Controls.Add(this.temp2);
            this.Controls.Add(this.temp1);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.Capture);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.LoosePicture);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoosePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Capture;
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
    }
}

