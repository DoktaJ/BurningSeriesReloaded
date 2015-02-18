using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WMPLib;

namespace BurningSeriesReloaded
{
    public partial class VideoPlayer : Form
    {
        private string url;
        private bool Autoplay;
        public VideoPlayer()
        {
            InitializeComponent();
        }

        public VideoPlayer(string directlink, bool Fullscreen)
        {
            Autoplay = Fullscreen;
            url = directlink;
            InitializeComponent();
            MediaPlayer.enableContextMenu = false;
            MediaPlayer.stretchToFit = true;
        }
        
        private void VideoPlayer_Load(object sender, EventArgs e)
        {
            IWMPPlaylist playlist = MediaPlayer.playlistCollection.newPlaylist("BurningSeries");
            IWMPMedia item = MediaPlayer.newMedia(url);
            playlist.appendItem(item);
            MediaPlayer.currentPlaylist = playlist;
            MediaPlayer.Ctlcontrols.play();
        }

        private void MediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (MediaPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                if (Autoplay)
                {
                    MediaPlayer.fullScreen = true;
                }
               
            }
            if (MediaPlayer.playState == WMPPlayState.wmppsStopped)
            {
                MediaPlayer.close();
                Close();
            }
        }
        private void VideoPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            MediaPlayer.close();
        }
    }
}
