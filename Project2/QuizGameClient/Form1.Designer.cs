
namespace QuizGameClient
{
    partial class Form1
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
            this.button_Join = new System.Windows.Forms.Button();
            this.label_enterName = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.textBox_playerName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_ScoreBoard = new System.Windows.Forms.Label();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.AnswerAButton = new System.Windows.Forms.Button();
            this.AnswerBButton = new System.Windows.Forms.Button();
            this.AnswerCButton = new System.Windows.Forms.Button();
            this.AnswerDButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Join
            // 
            this.button_Join.Location = new System.Drawing.Point(340, 406);
            this.button_Join.Name = "button_Join";
            this.button_Join.Size = new System.Drawing.Size(117, 23);
            this.button_Join.TabIndex = 0;
            this.button_Join.Text = "Connect to Quiz";
            this.button_Join.UseVisualStyleBackColor = true;
            this.button_Join.Click += new System.EventHandler(this.button_Join_Click);
            // 
            // label_enterName
            // 
            this.label_enterName.AutoSize = true;
            this.label_enterName.Location = new System.Drawing.Point(363, 364);
            this.label_enterName.Name = "label_enterName";
            this.label_enterName.Size = new System.Drawing.Size(63, 13);
            this.label_enterName.TabIndex = 1;
            this.label_enterName.Text = "Enter Name";
            this.label_enterName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.Location = new System.Drawing.Point(307, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(172, 31);
            this.label_Title.TabIndex = 2;
            this.label_Title.Text = "Trivia Game";
            // 
            // textBox_playerName
            // 
            this.textBox_playerName.Location = new System.Drawing.Point(340, 380);
            this.textBox_playerName.Name = "textBox_playerName";
            this.textBox_playerName.Size = new System.Drawing.Size(117, 20);
            this.textBox_playerName.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(432, 225);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(262, 171);
            this.dataGridView1.TabIndex = 5;
            // 
            // label_ScoreBoard
            // 
            this.label_ScoreBoard.AutoSize = true;
            this.label_ScoreBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ScoreBoard.Location = new System.Drawing.Point(498, 198);
            this.label_ScoreBoard.Name = "label_ScoreBoard";
            this.label_ScoreBoard.Size = new System.Drawing.Size(126, 24);
            this.label_ScoreBoard.TabIndex = 6;
            this.label_ScoreBoard.Text = "Score Board";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionLabel.Location = new System.Drawing.Point(70, 49);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(644, 21);
            this.QuestionLabel.TabIndex = 7;
            this.QuestionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AnswerAButton
            // 
            this.AnswerAButton.Location = new System.Drawing.Point(73, 73);
            this.AnswerAButton.Name = "AnswerAButton";
            this.AnswerAButton.Size = new System.Drawing.Size(298, 48);
            this.AnswerAButton.TabIndex = 8;
            this.AnswerAButton.UseVisualStyleBackColor = true;
            this.AnswerAButton.Click += new System.EventHandler(this.AnswerAButton_Click);
            // 
            // AnswerBButton
            // 
            this.AnswerBButton.Location = new System.Drawing.Point(416, 73);
            this.AnswerBButton.Name = "AnswerBButton";
            this.AnswerBButton.Size = new System.Drawing.Size(298, 48);
            this.AnswerBButton.TabIndex = 9;
            this.AnswerBButton.UseVisualStyleBackColor = true;
            this.AnswerBButton.Click += new System.EventHandler(this.AnswerBButton_Click);
            // 
            // AnswerCButton
            // 
            this.AnswerCButton.Location = new System.Drawing.Point(73, 127);
            this.AnswerCButton.Name = "AnswerCButton";
            this.AnswerCButton.Size = new System.Drawing.Size(298, 48);
            this.AnswerCButton.TabIndex = 10;
            this.AnswerCButton.UseVisualStyleBackColor = true;
            this.AnswerCButton.Click += new System.EventHandler(this.AnswerCButton_Click);
            // 
            // AnswerDButton
            // 
            this.AnswerDButton.Location = new System.Drawing.Point(416, 127);
            this.AnswerDButton.Name = "AnswerDButton";
            this.AnswerDButton.Size = new System.Drawing.Size(298, 48);
            this.AnswerDButton.TabIndex = 11;
            this.AnswerDButton.UseVisualStyleBackColor = true;
            this.AnswerDButton.Click += new System.EventHandler(this.AnswerDButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(89, 223);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(268, 173);
            this.listBox1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Game Log";
            // 
            // mainImage
            // 
            //this.mainImage.BackgroundImage = global::QuizGameClient.Properties.Resources.quiztime;
            this.mainImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.mainImage.InitialImage = global::QuizGameClient.Properties.Resources.quizLogo;
            this.mainImage.Location = new System.Drawing.Point(-6, 0);
            this.mainImage.Name = "mainImage";
            this.mainImage.Size = new System.Drawing.Size(806, 361);
            this.mainImage.TabIndex = 14;
            this.mainImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.AnswerDButton);
            this.Controls.Add(this.AnswerCButton);
            this.Controls.Add(this.AnswerBButton);
            this.Controls.Add(this.AnswerAButton);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.label_ScoreBoard);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox_playerName);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.label_enterName);
            this.Controls.Add(this.button_Join);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Join;
        private System.Windows.Forms.Label label_enterName;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.TextBox textBox_playerName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_ScoreBoard;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Button AnswerAButton;
        private System.Windows.Forms.Button AnswerBButton;
        private System.Windows.Forms.Button AnswerCButton;
        private System.Windows.Forms.Button AnswerDButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox mainImage;
    }
}

