
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_playerName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_ScoreBoard = new System.Windows.Forms.Label();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.AnswerAButton = new System.Windows.Forms.Button();
            this.AnswerBButton = new System.Windows.Forms.Button();
            this.AnswerCButton = new System.Windows.Forms.Button();
            this.AnswerDButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Join
            // 
            this.button_Join.Location = new System.Drawing.Point(340, 406);
            this.button_Join.Name = "button_Join";
            this.button_Join.Size = new System.Drawing.Size(108, 23);
            this.button_Join.TabIndex = 0;
            this.button_Join.Text = "Connect to Quiz";
            this.button_Join.UseVisualStyleBackColor = true;
            this.button_Join.Click += new System.EventHandler(this.button_Join_Click);
            // 
            // label_enterName
            // 
            this.label_enterName.AutoSize = true;
            this.label_enterName.Location = new System.Drawing.Point(361, 353);
            this.label_enterName.Name = "label_enterName";
            this.label_enterName.Size = new System.Drawing.Size(63, 13);
            this.label_enterName.TabIndex = 1;
            this.label_enterName.Text = "Enter Name";
            this.label_enterName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(310, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trivia Game";
            // 
            // textBox_playerName
            // 
            this.textBox_playerName.Location = new System.Drawing.Point(340, 380);
            this.textBox_playerName.Name = "textBox_playerName";
            this.textBox_playerName.Size = new System.Drawing.Size(108, 20);
            this.textBox_playerName.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(340, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Load Question";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(623, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(165, 171);
            this.dataGridView1.TabIndex = 5;
            // 
            // label_ScoreBoard
            // 
            this.label_ScoreBoard.AutoSize = true;
            this.label_ScoreBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ScoreBoard.Location = new System.Drawing.Point(644, 16);
            this.label_ScoreBoard.Name = "label_ScoreBoard";
            this.label_ScoreBoard.Size = new System.Drawing.Size(126, 24);
            this.label_ScoreBoard.TabIndex = 6;
            this.label_ScoreBoard.Text = "Score Board";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Location = new System.Drawing.Point(253, 90);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(285, 21);
            this.QuestionLabel.TabIndex = 7;
            this.QuestionLabel.Text = "label4";
            // 
            // AnswerAButton
            // 
            this.AnswerAButton.Location = new System.Drawing.Point(200, 124);
            this.AnswerAButton.Name = "AnswerAButton";
            this.AnswerAButton.Size = new System.Drawing.Size(171, 23);
            this.AnswerAButton.TabIndex = 8;
            this.AnswerAButton.Text = "button3";
            this.AnswerAButton.UseVisualStyleBackColor = true;
            // 
            // AnswerBButton
            // 
            this.AnswerBButton.Location = new System.Drawing.Point(407, 124);
            this.AnswerBButton.Name = "AnswerBButton";
            this.AnswerBButton.Size = new System.Drawing.Size(171, 23);
            this.AnswerBButton.TabIndex = 9;
            this.AnswerBButton.Text = "button4";
            this.AnswerBButton.UseVisualStyleBackColor = true;
            // 
            // AnswerCButton
            // 
            this.AnswerCButton.Location = new System.Drawing.Point(200, 182);
            this.AnswerCButton.Name = "AnswerCButton";
            this.AnswerCButton.Size = new System.Drawing.Size(171, 23);
            this.AnswerCButton.TabIndex = 10;
            this.AnswerCButton.Text = "button5";
            this.AnswerCButton.UseVisualStyleBackColor = true;
            // 
            // AnswerDButton
            // 
            this.AnswerDButton.Location = new System.Drawing.Point(407, 182);
            this.AnswerDButton.Name = "AnswerDButton";
            this.AnswerDButton.Size = new System.Drawing.Size(171, 23);
            this.AnswerDButton.TabIndex = 11;
            this.AnswerDButton.Text = "button6";
            this.AnswerDButton.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(165, 82);
            this.listBox1.TabIndex = 12;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Game Log";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.AnswerDButton);
            this.Controls.Add(this.AnswerCButton);
            this.Controls.Add(this.AnswerBButton);
            this.Controls.Add(this.AnswerAButton);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.label_ScoreBoard);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_playerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_enterName);
            this.Controls.Add(this.button_Join);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Join;
        private System.Windows.Forms.Label label_enterName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_playerName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_ScoreBoard;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Button AnswerAButton;
        private System.Windows.Forms.Button AnswerBButton;
        private System.Windows.Forms.Button AnswerCButton;
        private System.Windows.Forms.Button AnswerDButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
    }
}

