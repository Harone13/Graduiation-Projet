namespace naftaall1.client_part
{
    partial class orderListFrm
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
            this.components = new System.ComponentModel.Container();
            this.lb_count = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VoirDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.validerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anullerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lesNouvousCommandesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lesCommandesEncaisseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lesCommandesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lhistoriqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bonEnlevementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lhistoriqueBEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_count
            // 
            this.lb_count.AutoSize = true;
            this.lb_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_count.Location = new System.Drawing.Point(138, 592);
            this.lb_count.Name = "lb_count";
            this.lb_count.Size = new System.Drawing.Size(0, 17);
            this.lb_count.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(70, 590);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "#Lignes: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(74, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "filtrer : ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(347, 171);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 20);
            this.textBox1.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(73, 209);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(716, 362);
            this.dataGridView1.TabIndex = 8;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VoirDetailToolStripMenuItem,
            this.toolStripSeparator1,
            this.modifierToolStripMenuItem,
            this.suprimerToolStripMenuItem,
            this.toolStripSeparator2,
            this.validerToolStripMenuItem,
            this.anullerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 146);
            // 
            // VoirDetailToolStripMenuItem
            // 
            this.VoirDetailToolStripMenuItem.Image = global::naftaall1.Properties.Resources.eye;
            this.VoirDetailToolStripMenuItem.Name = "VoirDetailToolStripMenuItem";
            this.VoirDetailToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.VoirDetailToolStripMenuItem.Text = "Voir Detail";
            this.VoirDetailToolStripMenuItem.Click += new System.EventHandler(this.VoirDetailToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(128, 6);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Image = global::naftaall1.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_user_properties_24;
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.modifierToolStripMenuItem.Text = "Modifier";
            // 
            // suprimerToolStripMenuItem
            // 
            this.suprimerToolStripMenuItem.Image = global::naftaall1.Properties.Resources.Saki_Snowish_Trash_full_32;
            this.suprimerToolStripMenuItem.Name = "suprimerToolStripMenuItem";
            this.suprimerToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.suprimerToolStripMenuItem.Text = "Suprimer";
            this.suprimerToolStripMenuItem.Click += new System.EventHandler(this.suprimerToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(128, 6);
            // 
            // validerToolStripMenuItem
            // 
            this.validerToolStripMenuItem.Image = global::naftaall1.Properties.Resources.accept_document;
            this.validerToolStripMenuItem.Name = "validerToolStripMenuItem";
            this.validerToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.validerToolStripMenuItem.Text = "Valider";
            this.validerToolStripMenuItem.Click += new System.EventHandler(this.validerToolStripMenuItem_Click);
            // 
            // anullerToolStripMenuItem
            // 
            this.anullerToolStripMenuItem.Image = global::naftaall1.Properties.Resources.Saki_NuoveXT_2_Actions_stop_32;
            this.anullerToolStripMenuItem.Name = "anullerToolStripMenuItem";
            this.anullerToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.anullerToolStripMenuItem.Text = "Anuller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(236, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "La Liste des Commandes: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gold;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lesNouvousCommandesToolStripMenuItem,
            this.lesCommandesEncaisseToolStripMenuItem,
            this.lesCommandesToolStripMenuItem,
            this.lhistoriqueToolStripMenuItem,
            this.bonEnlevementToolStripMenuItem,
            this.lhistoriqueBEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(854, 28);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lesNouvousCommandesToolStripMenuItem
            // 
            this.lesNouvousCommandesToolStripMenuItem.Image = global::naftaall1.Properties.Resources.order__1_;
            this.lesNouvousCommandesToolStripMenuItem.Name = "lesNouvousCommandesToolStripMenuItem";
            this.lesNouvousCommandesToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.lesNouvousCommandesToolStripMenuItem.Text = "Les nouvous ";
            this.lesNouvousCommandesToolStripMenuItem.Click += new System.EventHandler(this.lesNouvousCommandesToolStripMenuItem_Click);
            // 
            // lesCommandesEncaisseToolStripMenuItem
            // 
            this.lesCommandesEncaisseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cacheToolStripMenuItem,
            this.creditToolStripMenuItem});
            this.lesCommandesEncaisseToolStripMenuItem.Image = global::naftaall1.Properties.Resources.coins__2_;
            this.lesCommandesEncaisseToolStripMenuItem.Name = "lesCommandesEncaisseToolStripMenuItem";
            this.lesCommandesEncaisseToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.lesCommandesEncaisseToolStripMenuItem.Text = "Les commandes encaissees";
            // 
            // cacheToolStripMenuItem
            // 
            this.cacheToolStripMenuItem.Name = "cacheToolStripMenuItem";
            this.cacheToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.cacheToolStripMenuItem.Text = "cache";
            this.cacheToolStripMenuItem.Click += new System.EventHandler(this.cacheToolStripMenuItem_Click);
            // 
            // creditToolStripMenuItem
            // 
            this.creditToolStripMenuItem.Name = "creditToolStripMenuItem";
            this.creditToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.creditToolStripMenuItem.Text = "credit";
            this.creditToolStripMenuItem.Click += new System.EventHandler(this.creditToolStripMenuItem_Click);
            // 
            // lesCommandesToolStripMenuItem
            // 
            this.lesCommandesToolStripMenuItem.Image = global::naftaall1.Properties.Resources.Graphicloads_Flat_Finance_Certificate_48;
            this.lesCommandesToolStripMenuItem.Name = "lesCommandesToolStripMenuItem";
            this.lesCommandesToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.lesCommandesToolStripMenuItem.Text = "Les commandes finits";
            this.lesCommandesToolStripMenuItem.Click += new System.EventHandler(this.lesCommandesToolStripMenuItem_Click);
            // 
            // lhistoriqueToolStripMenuItem
            // 
            this.lhistoriqueToolStripMenuItem.Image = global::naftaall1.Properties.Resources.Iconshock_Super_Vista_Accounting_Cabinet_48;
            this.lhistoriqueToolStripMenuItem.Name = "lhistoriqueToolStripMenuItem";
            this.lhistoriqueToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.lhistoriqueToolStripMenuItem.Text = "L\'historique B.L";
            this.lhistoriqueToolStripMenuItem.Click += new System.EventHandler(this.lhistoriqueToolStripMenuItem_Click);
            // 
            // bonEnlevementToolStripMenuItem
            // 
            this.bonEnlevementToolStripMenuItem.Image = global::naftaall1.Properties.Resources.order__1_;
            this.bonEnlevementToolStripMenuItem.Name = "bonEnlevementToolStripMenuItem";
            this.bonEnlevementToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.bonEnlevementToolStripMenuItem.Text = "bon Enlevement";
            this.bonEnlevementToolStripMenuItem.Click += new System.EventHandler(this.bonEnlevementToolStripMenuItem_Click);
            // 
            // lhistoriqueBEToolStripMenuItem
            // 
            this.lhistoriqueBEToolStripMenuItem.Image = global::naftaall1.Properties.Resources.Iconshock_Super_Vista_Accounting_Cabinet_48;
            this.lhistoriqueBEToolStripMenuItem.Name = "lhistoriqueBEToolStripMenuItem";
            this.lhistoriqueBEToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.lhistoriqueBEToolStripMenuItem.Text = "L\'historique B.E";
            this.lhistoriqueBEToolStripMenuItem.Click += new System.EventHandler(this.lhistoriqueBEToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(167, 171);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 21);
            this.comboBox1.TabIndex = 61;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::naftaall1.Properties.Resources.naftal_seeklogo;
            this.pictureBox2.Location = new System.Drawing.Point(730, 590);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(124, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::naftaall1.Properties.Resources.order__2_;
            this.pictureBox1.Location = new System.Drawing.Point(638, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 73);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // orderListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(854, 629);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_count);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "orderListFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Management des Commandes";
            this.Load += new System.EventHandler(this.orderListFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_count;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lesNouvousCommandesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lesCommandesEncaisseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lesCommandesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lhistoriqueToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem VoirDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem bonEnlevementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lhistoriqueBEToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem validerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anullerToolStripMenuItem;
    }
}