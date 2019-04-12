namespace lab3
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bezierCurvesInfo_dgv = new System.Windows.Forms.DataGridView();
            this.drawPoints_chb = new System.Windows.Forms.CheckBox();
            this.width_label = new System.Windows.Forms.Label();
            this.height_label = new System.Windows.Forms.Label();
            this.animation_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bezierCurvesInfo_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(93, 171);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(714, 451);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bezierCurvesInfo_dgv
            // 
            this.bezierCurvesInfo_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bezierCurvesInfo_dgv.Location = new System.Drawing.Point(12, 13);
            this.bezierCurvesInfo_dgv.Name = "bezierCurvesInfo_dgv";
            this.bezierCurvesInfo_dgv.Size = new System.Drawing.Size(795, 152);
            this.bezierCurvesInfo_dgv.TabIndex = 8;
            // 
            // drawPoints_chb
            // 
            this.drawPoints_chb.AutoSize = true;
            this.drawPoints_chb.Location = new System.Drawing.Point(13, 392);
            this.drawPoints_chb.Name = "drawPoints_chb";
            this.drawPoints_chb.Size = new System.Drawing.Size(73, 17);
            this.drawPoints_chb.TabIndex = 9;
            this.drawPoints_chb.Text = "Build lines";
            this.drawPoints_chb.UseVisualStyleBackColor = true;
            // 
            // width_label
            // 
            this.width_label.AutoSize = true;
            this.width_label.Location = new System.Drawing.Point(12, 202);
            this.width_label.Name = "width_label";
            this.width_label.Size = new System.Drawing.Size(35, 13);
            this.width_label.TabIndex = 10;
            this.width_label.Text = "label1";
            // 
            // height_label
            // 
            this.height_label.AutoSize = true;
            this.height_label.Location = new System.Drawing.Point(12, 215);
            this.height_label.Name = "height_label";
            this.height_label.Size = new System.Drawing.Size(35, 13);
            this.height_label.TabIndex = 11;
            this.height_label.Text = "label2";
            // 
            // animation_btn
            // 
            this.animation_btn.Location = new System.Drawing.Point(12, 444);
            this.animation_btn.Name = "animation_btn";
            this.animation_btn.Size = new System.Drawing.Size(75, 23);
            this.animation_btn.TabIndex = 12;
            this.animation_btn.Text = "Anime";
            this.animation_btn.UseVisualStyleBackColor = true;
            this.animation_btn.Click += new System.EventHandler(this.animation_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 634);
            this.Controls.Add(this.animation_btn);
            this.Controls.Add(this.height_label);
            this.Controls.Add(this.width_label);
            this.Controls.Add(this.drawPoints_chb);
            this.Controls.Add(this.bezierCurvesInfo_dgv);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bezierCurvesInfo_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView bezierCurvesInfo_dgv;
        private System.Windows.Forms.CheckBox drawPoints_chb;
        private System.Windows.Forms.Label width_label;
        private System.Windows.Forms.Label height_label;
        private System.Windows.Forms.Button animation_btn;
    }
}

