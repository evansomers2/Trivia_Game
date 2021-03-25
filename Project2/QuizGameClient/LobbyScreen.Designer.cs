namespace QuizGameClient
{
    partial class LobbyScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Ready = new System.Windows.Forms.Button();
            this.dataGrid_lobby = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_lobby)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 561F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 370F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Ready, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGrid_lobby, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.97902F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.02098F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 692);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(312, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "X PLAYERS JOINED";
            // 
            // btn_Ready
            // 
            this.btn_Ready.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Ready.Location = new System.Drawing.Point(493, 484);
            this.btn_Ready.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Ready.Name = "btn_Ready";
            this.btn_Ready.Size = new System.Drawing.Size(112, 35);
            this.btn_Ready.TabIndex = 2;
            this.btn_Ready.Text = "Ready";
            this.btn_Ready.UseVisualStyleBackColor = true;
            this.btn_Ready.Click += new System.EventHandler(this.btn_Ready_Click);
            // 
            // dataGrid_lobby
            // 
            this.dataGrid_lobby.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_lobby.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_lobby.Location = new System.Drawing.Point(272, 103);
            this.dataGrid_lobby.Name = "dataGrid_lobby";
            this.dataGrid_lobby.RowHeadersWidth = 62;
            this.dataGrid_lobby.RowTemplate.Height = 28;
            this.dataGrid_lobby.Size = new System.Drawing.Size(555, 373);
            this.dataGrid_lobby.TabIndex = 3;
            // 
            // LobbyScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LobbyScreen";
            this.Text = "LobbyScreen";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_lobby)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Ready;
        private System.Windows.Forms.DataGridView dataGrid_lobby;
    }
}