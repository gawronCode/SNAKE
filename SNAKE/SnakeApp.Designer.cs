using System.Windows.Forms;

namespace SNAKE
{
    partial class SnakeApp
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
            this.gameField = new System.Windows.Forms.Panel();
            this.gameOver = new System.Windows.Forms.Label();
            this.bestScore = new System.Windows.Forms.Label();
            this.currentScore = new System.Windows.Forms.Label();
            this.snakeLenght = new System.Windows.Forms.Label();
            this.snakeSpeed = new System.Windows.Forms.Label();
            this.gameDifficulty = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.timeTillSpeedUp = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Label();
            this.color = new System.Windows.Forms.Button();
            this.difficulty = new System.Windows.Forms.Button();
            this.gameField.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameField
            // 
            this.gameField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gameField.BackColor = System.Drawing.Color.MediumPurple;
            this.gameField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameField.Controls.Add(this.gameOver);
            this.gameField.ForeColor = System.Drawing.Color.Black;
            this.gameField.Location = new System.Drawing.Point(320, 30);
            this.gameField.MaximumSize = new System.Drawing.Size(800, 800);
            this.gameField.MinimumSize = new System.Drawing.Size(800, 800);
            this.gameField.Name = "gameField";
            this.gameField.Size = new System.Drawing.Size(800, 800);
            this.gameField.TabIndex = 0;
            this.gameField.Paint += new System.Windows.Forms.PaintEventHandler(this.GameField_Paint);
            // 
            // gameOver
            // 
            this.gameOver.AutoSize = true;
            this.gameOver.BackColor = System.Drawing.Color.Crimson;
            this.gameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameOver.ForeColor = System.Drawing.Color.Yellow;
            this.gameOver.Location = new System.Drawing.Point(87, 140);
            this.gameOver.Name = "gameOver";
            this.gameOver.Size = new System.Drawing.Size(626, 108);
            this.gameOver.TabIndex = 5;
            this.gameOver.Text = "GAME OVER";
            this.gameOver.Visible = false;
            // 
            // bestScore
            // 
            this.bestScore.AutoSize = true;
            this.bestScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bestScore.Location = new System.Drawing.Point(1139, 40);
            this.bestScore.Name = "bestScore";
            this.bestScore.Size = new System.Drawing.Size(279, 31);
            this.bestScore.TabIndex = 1;
            this.bestScore.Text = "BEST SCORE: 12345";
            // 
            // currentScore
            // 
            this.currentScore.AutoSize = true;
            this.currentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentScore.Location = new System.Drawing.Point(1139, 80);
            this.currentScore.Name = "currentScore";
            this.currentScore.Size = new System.Drawing.Size(141, 31);
            this.currentScore.TabIndex = 2;
            this.currentScore.Text = "SCORE: 0";
            // 
            // snakeLenght
            // 
            this.snakeLenght.AutoSize = true;
            this.snakeLenght.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.snakeLenght.Location = new System.Drawing.Point(1139, 120);
            this.snakeLenght.Name = "snakeLenght";
            this.snakeLenght.Size = new System.Drawing.Size(254, 31);
            this.snakeLenght.TabIndex = 3;
            this.snakeLenght.Text = "SNAKE LENGHT: 1";
            // 
            // snakeSpeed
            // 
            this.snakeSpeed.AutoSize = true;
            this.snakeSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.snakeSpeed.Location = new System.Drawing.Point(1139, 160);
            this.snakeSpeed.Name = "snakeSpeed";
            this.snakeSpeed.Size = new System.Drawing.Size(250, 31);
            this.snakeSpeed.TabIndex = 4;
            this.snakeSpeed.Text = "SNAKE SPEED: 12";
            // 
            // gameDifficulty
            // 
            this.gameDifficulty.AutoSize = true;
            this.gameDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameDifficulty.Location = new System.Drawing.Point(1139, 200);
            this.gameDifficulty.Name = "gameDifficulty";
            this.gameDifficulty.Size = new System.Drawing.Size(261, 31);
            this.gameDifficulty.TabIndex = 5;
            this.gameDifficulty.Text = "DIFFICULTY: EASY";
            // 
            // start
            // 
            this.start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.start.Location = new System.Drawing.Point(1137, 599);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(290, 73);
            this.start.TabIndex = 6;
            this.start.Text = "START";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // pause
            // 
            this.pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pause.Location = new System.Drawing.Point(1137, 678);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(290, 73);
            this.pause.TabIndex = 7;
            this.pause.Text = "PAUSE";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // exit
            // 
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exit.Location = new System.Drawing.Point(1137, 757);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(290, 73);
            this.exit.TabIndex = 8;
            this.exit.Text = "EXIT";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // timeTillSpeedUp
            // 
            this.timeTillSpeedUp.AutoSize = true;
            this.timeTillSpeedUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeTillSpeedUp.Location = new System.Drawing.Point(15, 40);
            this.timeTillSpeedUp.Name = "timeTillSpeedUp";
            this.timeTillSpeedUp.Size = new System.Drawing.Size(285, 31);
            this.timeTillSpeedUp.TabIndex = 9;
            this.timeTillSpeedUp.Text = "TIME TILL SPEED UP";
            // 
            // clock
            // 
            this.clock.AutoSize = true;
            this.clock.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.clock.Location = new System.Drawing.Point(58, 94);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(199, 108);
            this.clock.TabIndex = 10;
            this.clock.Text = "59s";
            // 
            // color
            // 
            this.color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.color.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.color.Location = new System.Drawing.Point(13, 678);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(290, 73);
            this.color.TabIndex = 11;
            this.color.Text = "COLOR";
            this.color.UseVisualStyleBackColor = true;
            this.color.Click += new System.EventHandler(this.Color_Click);
            // 
            // difficulty
            // 
            this.difficulty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.difficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.difficulty.Location = new System.Drawing.Point(13, 757);
            this.difficulty.Name = "difficulty";
            this.difficulty.Size = new System.Drawing.Size(290, 73);
            this.difficulty.TabIndex = 12;
            this.difficulty.Text = "DIFFICULTY";
            this.difficulty.UseVisualStyleBackColor = true;
            this.difficulty.Click += new System.EventHandler(this.Difficulty_Click);
            // 
            // SnakeApp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1440, 861);
            this.Controls.Add(this.difficulty);
            this.Controls.Add(this.color);
            this.Controls.Add(this.clock);
            this.Controls.Add(this.timeTillSpeedUp);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.start);
            this.Controls.Add(this.gameDifficulty);
            this.Controls.Add(this.snakeSpeed);
            this.Controls.Add(this.snakeLenght);
            this.Controls.Add(this.currentScore);
            this.Controls.Add(this.bestScore);
            this.Controls.Add(this.gameField);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SnakeApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.Activated += new System.EventHandler(this.SnakeApp_Load);
            this.Load += new System.EventHandler(this.SnakeApp_Load);
            this.gameField.ResumeLayout(false);
            this.gameField.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gameField;
        private System.Windows.Forms.Label bestScore;
        private System.Windows.Forms.Label currentScore;
        private System.Windows.Forms.Label snakeLenght;
        private System.Windows.Forms.Label snakeSpeed;
        private System.Windows.Forms.Label gameDifficulty;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label timeTillSpeedUp;
        private System.Windows.Forms.Label clock;
        private System.Windows.Forms.Button color;
        private System.Windows.Forms.Button difficulty;
        private Label gameOver;
    }
}

