namespace BurningSeriesReloaded
{
    partial class VideoPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPlayer));
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(284, 261);
            this.MediaPlayer.TabIndex = 0;
            this.MediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.MediaPlayer_PlayStateChange);
            // 
            // VideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.MediaPlayer);
            this.Name = "VideoPlayer";
            this.Text = "VideoPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoPlayer_FormClosing);
            this.Load += new System.EventHandler(this.VideoPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
    }
}