namespace mayınTarlası
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxBoard = new System.Windows.Forms.GroupBox();
            this.groupBoxCustom = new System.Windows.Forms.GroupBox();
            this.buttonUpdatee = new System.Windows.Forms.Button();
            this.textBoxMines = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBoard
            // 
            this.groupBoxBoard.Location = new System.Drawing.Point(12, 76);
            this.groupBoxBoard.Name = "groupBoxBoard";
            this.groupBoxBoard.Size = new System.Drawing.Size(381, 312);
            this.groupBoxBoard.TabIndex = 0;
            this.groupBoxBoard.TabStop = false;
            this.groupBoxBoard.Text = "Board";
            // 
            // groupBoxCustom
            // 
            this.groupBoxCustom.Controls.Add(this.buttonUpdatee);
            this.groupBoxCustom.Controls.Add(this.textBoxMines);
            this.groupBoxCustom.Controls.Add(this.textBoxHeight);
            this.groupBoxCustom.Controls.Add(this.label3);
            this.groupBoxCustom.Controls.Add(this.label2);
            this.groupBoxCustom.Controls.Add(this.label1);
            this.groupBoxCustom.Controls.Add(this.textBoxWidth);
            this.groupBoxCustom.Location = new System.Drawing.Point(12, 5);
            this.groupBoxCustom.Name = "groupBoxCustom";
            this.groupBoxCustom.Size = new System.Drawing.Size(381, 65);
            this.groupBoxCustom.TabIndex = 1;
            this.groupBoxCustom.TabStop = false;
            this.groupBoxCustom.Text = "Custom ";
            // 
            // buttonUpdatee
            // 
            this.buttonUpdatee.BackColor = System.Drawing.SystemColors.Control;
            this.buttonUpdatee.Location = new System.Drawing.Point(311, 25);
            this.buttonUpdatee.Name = "buttonUpdatee";
            this.buttonUpdatee.Size = new System.Drawing.Size(56, 23);
            this.buttonUpdatee.TabIndex = 8;
            this.buttonUpdatee.Text = "Update";
            this.buttonUpdatee.UseVisualStyleBackColor = false;
            this.buttonUpdatee.Click += new System.EventHandler(this.buttonUpdatee_Click);
            // 
            // textBoxMines
            // 
            this.textBoxMines.Location = new System.Drawing.Point(257, 25);
            this.textBoxMines.Name = "textBoxMines";
            this.textBoxMines.Size = new System.Drawing.Size(32, 20);
            this.textBoxMines.TabIndex = 7;
            this.textBoxMines.Text = "15";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(162, 25);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(29, 20);
            this.textBoxHeight.TabIndex = 6;
            this.textBoxHeight.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mines :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Width :";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(62, 25);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(33, 20);
            this.textBoxWidth.TabIndex = 0;
            this.textBoxWidth.Text = "10";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonUpdatee;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(403, 396);
            this.Controls.Add(this.groupBoxCustom);
            this.Controls.Add(this.groupBoxBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxCustom.ResumeLayout(false);
            this.groupBoxCustom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBoard;
        private System.Windows.Forms.GroupBox groupBoxCustom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxMines;
        private System.Windows.Forms.Button buttonUpdatee;
        private System.Windows.Forms.Timer timer1;
    }
}

