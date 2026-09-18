namespace Fighter_Jet_Shooting_Game_MOO_ICT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            enemyOne = new PictureBox();
            enemyTwo = new PictureBox();
            enemyThree = new PictureBox();
            player = new PictureBox();
            txtScore = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            txtVidas = new TextBox();
            bomb = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)enemyOne).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemyTwo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemyThree).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bomb).BeginInit();
            SuspendLayout();
            // 
            // enemyOne
            // 
            enemyOne.Image = Properties.Resources.enemy;
            enemyOne.Location = new Point(39, 101);
            enemyOne.Margin = new Padding(5, 4, 5, 4);
            enemyOne.Name = "enemyOne";
            enemyOne.Size = new Size(100, 85);
            enemyOne.SizeMode = PictureBoxSizeMode.AutoSize;
            enemyOne.TabIndex = 0;
            enemyOne.TabStop = false;
            // 
            // enemyTwo
            // 
            enemyTwo.Image = Properties.Resources.enemy;
            enemyTwo.Location = new Point(501, 101);
            enemyTwo.Margin = new Padding(5, 4, 5, 4);
            enemyTwo.Name = "enemyTwo";
            enemyTwo.Size = new Size(100, 85);
            enemyTwo.SizeMode = PictureBoxSizeMode.AutoSize;
            enemyTwo.TabIndex = 0;
            enemyTwo.TabStop = false;
            // 
            // enemyThree
            // 
            enemyThree.Image = Properties.Resources.enemy;
            enemyThree.Location = new Point(996, 101);
            enemyThree.Margin = new Padding(5, 4, 5, 4);
            enemyThree.Name = "enemyThree";
            enemyThree.Size = new Size(100, 85);
            enemyThree.SizeMode = PictureBoxSizeMode.AutoSize;
            enemyThree.TabIndex = 0;
            enemyThree.TabStop = false;
            // 
            // player
            // 
            player.Image = Properties.Resources.player;
            player.Location = new Point(501, 911);
            player.Margin = new Padding(5, 4, 5, 4);
            player.Name = "player";
            player.Size = new Size(110, 98);
            player.SizeMode = PictureBoxSizeMode.AutoSize;
            player.TabIndex = 0;
            player.TabStop = false;
            // 
            // txtScore
            // 
            txtScore.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtScore.Location = new Point(17, 364);
            txtScore.Margin = new Padding(5, 0, 5, 0);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(1197, 242);
            txtScore.TabIndex = 1;
            txtScore.Text = "0";
            txtScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 20;
            gameTimer.Tick += mainGameTimerEvent;
            // 
            // txtVidas
            // 
            txtVidas.BackColor = Color.FromArgb(128, 255, 255);
            txtVidas.BorderStyle = BorderStyle.None;
            txtVidas.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtVidas.ForeColor = SystemColors.ControlText;
            txtVidas.Location = new Point(1062, 799);
            txtVidas.Margin = new Padding(4, 4, 4, 4);
            txtVidas.Name = "txtVidas";
            txtVidas.Size = new Size(95, 19);
            txtVidas.TabIndex = 2;
            txtVidas.Text = "Vidas: 3";
            txtVidas.TextAlign = HorizontalAlignment.Center;
            // 
            // bomb
            // 
            bomb.BackColor = Color.Red;
            bomb.Location = new Point(690, 101);
            bomb.Margin = new Padding(4, 4, 4, 4);
            bomb.Name = "bomb";
            bomb.Size = new Size(122, 119);
            bomb.TabIndex = 3;
            bomb.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 255);
            ClientSize = new Size(1200, 1060);
            Controls.Add(bomb);
            Controls.Add(txtVidas);
            Controls.Add(player);
            Controls.Add(enemyThree);
            Controls.Add(enemyTwo);
            Controls.Add(enemyOne);
            Controls.Add(txtScore);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form1";
            Text = "Fighet Jet Shooting Game MOOI CT";
            KeyDown += keyisdown;
            KeyUp += keyisup;
            ((System.ComponentModel.ISupportInitialize)enemyOne).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemyTwo).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemyThree).EndInit();
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)bomb).EndInit();
            ResumeLayout(false);
            PerformLayout();


        }

        #endregion

        private System.Windows.Forms.PictureBox enemyOne;
        private System.Windows.Forms.PictureBox enemyTwo;
        private System.Windows.Forms.PictureBox enemyThree;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Timer gameTimer;
        private TextBox txtVidas;
        private PictureBox bomb;
    }
}
