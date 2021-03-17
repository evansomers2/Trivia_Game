
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.AnswerAButton = new System.Windows.Forms.Button();
            this.AnswerBButton = new System.Windows.Forms.Button();
            this.AnswerCButton = new System.Windows.Forms.Button();
            this.AnswerDButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect to Quiz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(361, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(340, 380);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 20);
            this.textBox1.TabIndex = 3;
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
            this.dataGridView1.Location = new System.Drawing.Point(623, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(165, 358);
            this.dataGridView1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(643, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Score Board";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Location = new System.Drawing.Point(253, 90);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(285, 21);
            this.QuestionLabel.TabIndex = 7;
            this.QuestionLabel.Text = "label4";
            this.QuestionLabel.Click += new System.EventHandler(this.QuestionLabel_Click);
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
            this.AnswerBButton.Click += new System.EventHandler(this.AnswerBButton_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AnswerDButton);
            this.Controls.Add(this.AnswerCButton);
            this.Controls.Add(this.AnswerBButton);
            this.Controls.Add(this.AnswerAButton);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Button AnswerAButton;
        private System.Windows.Forms.Button AnswerBButton;
        private System.Windows.Forms.Button AnswerCButton;
        private System.Windows.Forms.Button AnswerDButton;
    }
}

