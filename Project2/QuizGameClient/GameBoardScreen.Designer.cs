namespace QuizGameClient
{
    partial class GameBoardScreen
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
            if (disposing && (components != null)) {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_gameTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_question = new System.Windows.Forms.Label();
            this.btn_answer1 = new System.Windows.Forms.Button();
            this.btn_answer2 = new System.Windows.Forms.Button();
            this.btn_answer3 = new System.Windows.Forms.Button();
            this.btn_answer4 = new System.Windows.Forms.Button();
            this.label_Countdown = new System.Windows.Forms.Label();
            this.dataGrid_scoreBoard = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_scoreBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.53998F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.46002F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 336F));
            this.tableLayoutPanel1.Controls.Add(this.label_gameTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGrid_scoreBoard, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_Countdown, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 692);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_gameTitle
            // 
            this.label_gameTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_gameTitle.AutoSize = true;
            this.label_gameTitle.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_gameTitle.Location = new System.Drawing.Point(315, 7);
            this.label_gameTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_gameTitle.Name = "label_gameTitle";
            this.label_gameTitle.Size = new System.Drawing.Size(392, 65);
            this.label_gameTitle.TabIndex = 0;
            this.label_gameTitle.Text = "TRIVIA GAME";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label_question, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_answer1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_answer2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_answer3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_answer4, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(164, 85);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.59184F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.40816F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(695, 461);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label_question
            // 
            this.label_question.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_question.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label_question, 2);
            this.label_question.Location = new System.Drawing.Point(103, 48);
            this.label_question.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_question.Name = "label_question";
            this.label_question.Size = new System.Drawing.Size(488, 20);
            this.label_question.TabIndex = 0;
            this.label_question.Text = "Question: This is a sample question, select the correct answer below";
            // 
            // btn_answer1
            // 
            this.btn_answer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_answer1.Location = new System.Drawing.Point(25, 142);
            this.btn_answer1.Margin = new System.Windows.Forms.Padding(25);
            this.btn_answer1.Name = "btn_answer1";
            this.btn_answer1.Size = new System.Drawing.Size(297, 128);
            this.btn_answer1.TabIndex = 1;
            this.btn_answer1.Text = "ANSWER ONE";
            this.btn_answer1.UseVisualStyleBackColor = true;
            // 
            // btn_answer2
            // 
            this.btn_answer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_answer2.Location = new System.Drawing.Point(372, 142);
            this.btn_answer2.Margin = new System.Windows.Forms.Padding(25);
            this.btn_answer2.Name = "btn_answer2";
            this.btn_answer2.Size = new System.Drawing.Size(298, 128);
            this.btn_answer2.TabIndex = 2;
            this.btn_answer2.Text = "ANSWER TWO";
            this.btn_answer2.UseVisualStyleBackColor = true;
            // 
            // btn_answer3
            // 
            this.btn_answer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_answer3.Location = new System.Drawing.Point(25, 320);
            this.btn_answer3.Margin = new System.Windows.Forms.Padding(25);
            this.btn_answer3.Name = "btn_answer3";
            this.btn_answer3.Size = new System.Drawing.Size(297, 116);
            this.btn_answer3.TabIndex = 3;
            this.btn_answer3.Text = "ANSWER THREE";
            this.btn_answer3.UseVisualStyleBackColor = true;
            // 
            // btn_answer4
            // 
            this.btn_answer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_answer4.Location = new System.Drawing.Point(372, 320);
            this.btn_answer4.Margin = new System.Windows.Forms.Padding(25);
            this.btn_answer4.Name = "btn_answer4";
            this.btn_answer4.Size = new System.Drawing.Size(298, 116);
            this.btn_answer4.TabIndex = 4;
            this.btn_answer4.Text = "ANWSER FOUR";
            this.btn_answer4.UseVisualStyleBackColor = true;
            // 
            // label_Countdown
            // 
            this.label_Countdown.AutoSize = true;
            this.label_Countdown.Location = new System.Drawing.Point(4, 0);
            this.label_Countdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Countdown.Name = "label_Countdown";
            this.label_Countdown.Size = new System.Drawing.Size(120, 20);
            this.label_Countdown.TabIndex = 2;
            this.label_Countdown.Text = "Countdown: XX";
            // 
            // dataGrid_scoreBoard
            // 
            this.dataGrid_scoreBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_scoreBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_scoreBoard.Location = new System.Drawing.Point(867, 85);
            this.dataGrid_scoreBoard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid_scoreBoard.Name = "dataGrid_scoreBoard";
            this.dataGrid_scoreBoard.RowHeadersWidth = 62;
            this.dataGrid_scoreBoard.Size = new System.Drawing.Size(329, 461);
            this.dataGrid_scoreBoard.TabIndex = 3;
            // 
            // GameBoardScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GameBoardScreen";
            this.Text = "GameBoardScreen";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_scoreBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_gameTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_question;
        private System.Windows.Forms.Button btn_answer1;
        private System.Windows.Forms.Button btn_answer2;
        private System.Windows.Forms.Button btn_answer3;
        private System.Windows.Forms.Button btn_answer4;
        private System.Windows.Forms.Label label_Countdown;
        private System.Windows.Forms.DataGridView dataGrid_scoreBoard;
    }
}