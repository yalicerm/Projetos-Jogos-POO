namespace Fighter_Jet_Shooting_Game_MOO_ICT
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startButton = new Button();
            direitosAutorais = new Label();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.Transparent;
            startButton.BackgroundImageLayout = ImageLayout.Zoom;
            startButton.Cursor = Cursors.Hand;
            startButton.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Location = new Point(441, 597);
            startButton.Name = "startButton";
            startButton.Size = new Size(184, 72);
            startButton.TabIndex = 0;
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // direitosAutorais
            // 
            direitosAutorais.AutoSize = true;
            direitosAutorais.BackColor = Color.Transparent;
            direitosAutorais.Font = new Font("Arial", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            direitosAutorais.ForeColor = SystemColors.Control;
            direitosAutorais.Location = new Point(324, 972);
            direitosAutorais.Name = "direitosAutorais";
            direitosAutorais.Size = new Size(421, 16);
            direitosAutorais.TabIndex = 1;
            direitosAutorais.Text = "Copyright © 2026 Divas Lindas Ltda. Todos os direitos reservados.";
            direitosAutorais.Click += label1_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1067, 1037);
            Controls.Add(direitosAutorais);
            Controls.Add(startButton);
            DoubleBuffered = true;
            Name = "Menu";
            Text = "Space Wars";
            Load += Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Label direitosAutorais;
    }
}