namespace naftaall1.prod_trnsprt_part
{
    partial class AddUpVeh
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_non = new System.Windows.Forms.RadioButton();
            this.rb_oui = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_cit = new System.Windows.Forms.RadioButton();
            this.rb_trac = new System.Windows.Forms.RadioButton();
            this.lb_trnsprt = new System.Windows.Forms.Label();
            this.lb_trnsplabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(385, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ajouter Vehicule :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(28, 308);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Liste des Transporteurs privee : ";
            this.label1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 332);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(883, 181);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.Visible = false;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lb_trnsprt);
            this.panel1.Controls.Add(this.lb_trnsplabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(32, 89);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 185);
            this.panel1.TabIndex = 40;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_non);
            this.groupBox2.Controls.Add(this.rb_oui);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(492, 28);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(267, 85);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trans Privee";
            // 
            // rb_non
            // 
            this.rb_non.AutoSize = true;
            this.rb_non.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_non.Location = new System.Drawing.Point(135, 39);
            this.rb_non.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_non.Name = "rb_non";
            this.rb_non.Size = new System.Drawing.Size(60, 22);
            this.rb_non.TabIndex = 52;
            this.rb_non.TabStop = true;
            this.rb_non.Text = "Non";
            this.rb_non.UseVisualStyleBackColor = true;
            this.rb_non.CheckedChanged += new System.EventHandler(this.rb_oui_CheckedChanged);
            // 
            // rb_oui
            // 
            this.rb_oui.AutoSize = true;
            this.rb_oui.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_oui.Location = new System.Drawing.Point(39, 39);
            this.rb_oui.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_oui.Name = "rb_oui";
            this.rb_oui.Size = new System.Drawing.Size(55, 22);
            this.rb_oui.TabIndex = 51;
            this.rb_oui.TabStop = true;
            this.rb_oui.Text = "Oui";
            this.rb_oui.UseVisualStyleBackColor = true;
            this.rb_oui.CheckedChanged += new System.EventHandler(this.rb_oui_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_cit);
            this.groupBox1.Controls.Add(this.rb_trac);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(29, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(267, 85);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type de vehicule";
            // 
            // rb_cit
            // 
            this.rb_cit.AutoSize = true;
            this.rb_cit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_cit.Location = new System.Drawing.Point(137, 39);
            this.rb_cit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_cit.Name = "rb_cit";
            this.rb_cit.Size = new System.Drawing.Size(80, 22);
            this.rb_cit.TabIndex = 60;
            this.rb_cit.TabStop = true;
            this.rb_cit.Text = "citerne";
            this.rb_cit.UseVisualStyleBackColor = true;
            this.rb_cit.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rb_trac
            // 
            this.rb_trac.AutoSize = true;
            this.rb_trac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_trac.Location = new System.Drawing.Point(8, 39);
            this.rb_trac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_trac.Name = "rb_trac";
            this.rb_trac.Size = new System.Drawing.Size(87, 22);
            this.rb_trac.TabIndex = 59;
            this.rb_trac.TabStop = true;
            this.rb_trac.Text = "tracteur";
            this.rb_trac.UseVisualStyleBackColor = true;
            this.rb_trac.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // lb_trnsprt
            // 
            this.lb_trnsprt.AutoSize = true;
            this.lb_trnsprt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_trnsprt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_trnsprt.Location = new System.Drawing.Point(653, 144);
            this.lb_trnsprt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_trnsprt.Name = "lb_trnsprt";
            this.lb_trnsprt.Size = new System.Drawing.Size(18, 17);
            this.lb_trnsprt.TabIndex = 56;
            this.lb_trnsprt.Text = ": ";
            this.lb_trnsprt.Visible = false;
            // 
            // lb_trnsplabel
            // 
            this.lb_trnsplabel.AutoSize = true;
            this.lb_trnsplabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_trnsplabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_trnsplabel.Location = new System.Drawing.Point(488, 140);
            this.lb_trnsplabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_trnsplabel.Name = "lb_trnsplabel";
            this.lb_trnsplabel.Size = new System.Drawing.Size(135, 20);
            this.lb_trnsplabel.TabIndex = 55;
            this.lb_trnsplabel.Text = "Transporteur : ";
            this.lb_trnsplabel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(25, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "matricule : ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 138);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 22);
            this.textBox1.TabIndex = 52;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::naftaall1.Properties.Resources.tank_truck;
            this.pictureBox4.ImageLocation = "";
            this.pictureBox4.Location = new System.Drawing.Point(563, 3);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(92, 78);
            this.pictureBox4.TabIndex = 55;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::naftaall1.Properties.Resources.naftal_seeklogo;
            this.pictureBox2.Location = new System.Drawing.Point(-16, 3);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(165, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::naftaall1.Properties.Resources.Franksouza183_Fs_Actions_stock_save_as_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(731, 556);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 46);
            this.button1.TabIndex = 61;
            this.button1.Text = "Enregistrer";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button3_Click);
            // 
            // AddUpVeh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(943, 615);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddUpVeh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.AddUpVeh_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_trnsprt;
        private System.Windows.Forms.Label lb_trnsplabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_cit;
        private System.Windows.Forms.RadioButton rb_trac;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_non;
        private System.Windows.Forms.RadioButton rb_oui;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
    }
}