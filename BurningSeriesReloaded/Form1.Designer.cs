namespace BurningSeriesReloaded
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbSerie = new System.Windows.Forms.ComboBox();
            this.cbStaffel = new System.Windows.Forms.ComboBox();
            this.cbEpisode = new System.Windows.Forms.ComboBox();
            this.cmdPlay = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.chkAutoplay = new System.Windows.Forms.CheckBox();
            this.delay = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSerie
            // 
            this.cbSerie.FormattingEnabled = true;
            this.cbSerie.Location = new System.Drawing.Point(12, 39);
            this.cbSerie.Name = "cbSerie";
            this.cbSerie.Size = new System.Drawing.Size(304, 21);
            this.cbSerie.TabIndex = 0;
            this.cbSerie.SelectedValueChanged += new System.EventHandler(this.cbSerie_SelectedValueChanged);
            // 
            // cbStaffel
            // 
            this.cbStaffel.FormattingEnabled = true;
            this.cbStaffel.Location = new System.Drawing.Point(12, 66);
            this.cbStaffel.Name = "cbStaffel";
            this.cbStaffel.Size = new System.Drawing.Size(304, 21);
            this.cbStaffel.TabIndex = 1;
            this.cbStaffel.SelectedValueChanged += new System.EventHandler(this.cbStaffel_SelectedValueChanged);
            // 
            // cbEpisode
            // 
            this.cbEpisode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbEpisode.FormattingEnabled = true;
            this.cbEpisode.Location = new System.Drawing.Point(12, 93);
            this.cbEpisode.Name = "cbEpisode";
            this.cbEpisode.Size = new System.Drawing.Size(304, 21);
            this.cbEpisode.TabIndex = 2;
            this.cbEpisode.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbEpisode_DrawItem);
            this.cbEpisode.SelectedIndexChanged += new System.EventHandler(this.cbEpisode_SelectedIndexChanged);
            // 
            // cmdPlay
            // 
            this.cmdPlay.Location = new System.Drawing.Point(197, 120);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(119, 23);
            this.cmdPlay.TabIndex = 3;
            this.cmdPlay.Text = "Play";
            this.cmdPlay.UseVisualStyleBackColor = true;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.toolStripSeparator3,
            this.toolStripLabel4,
            this.toolStripSeparator2,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(328, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel2.Text = "Login";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.IsLink = true;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(69, 22);
            this.toolStripLabel3.Text = "Registrieren";
            this.toolStripLabel3.Click += new System.EventHandler(this.toolStripLabel3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Enabled = false;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel4.Text = "Zufall";
            this.toolStripLabel4.Click += new System.EventHandler(this.toolStripLabel4_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel1.Text = "About";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // chkAutoplay
            // 
            this.chkAutoplay.AutoSize = true;
            this.chkAutoplay.Location = new System.Drawing.Point(12, 126);
            this.chkAutoplay.Name = "chkAutoplay";
            this.chkAutoplay.Size = new System.Drawing.Size(67, 17);
            this.chkAutoplay.TabIndex = 5;
            this.chkAutoplay.Text = "Autoplay";
            this.chkAutoplay.UseVisualStyleBackColor = true;
            this.chkAutoplay.CheckedChanged += new System.EventHandler(this.chkAutoplay_CheckedChanged);
            // 
            // delay
            // 
            this.delay.Interval = 3000;
            this.delay.Tick += new System.EventHandler(this.delay_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 154);
            this.Controls.Add(this.chkAutoplay);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cmdPlay);
            this.Controls.Add(this.cbEpisode);
            this.Controls.Add(this.cbStaffel);
            this.Controls.Add(this.cbSerie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "BurningSeriesReloaded";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSerie;
        private System.Windows.Forms.ComboBox cbStaffel;
        private System.Windows.Forms.ComboBox cbEpisode;
        private System.Windows.Forms.Button cmdPlay;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox chkAutoplay;
        private System.Windows.Forms.Timer delay;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

    }
}

