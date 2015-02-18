using System;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet;

namespace BurningSeriesReloaded
{
    public partial class Form1 : Form
    {
        public bool AutoPlay { get; set; }
        private Random Rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        //Lade beim Start alle Serien und füge sie zu cbSerie hinzu.
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            cbEpisode.DrawItem -= cbEpisode_DrawItem;
            if (Properties.Settings.Default.ApiKey != "")
            {
                toolStripLabel2.Text = "Ausloggen";
                toolStripLabel3.Visible = false;
                toolStripSeparator2.Visible = false;
            }
            else
            {
                toolStripLabel2.Text = "Einloggen";
                toolStripLabel3.Visible = true;
                toolStripSeparator2.Visible = true;
            }
            updateController1.updateFound += updateController1_updateFound;
              updateController1.checkForUpdatesAsync();

            cmdPlay.Enabled = false;
            cbSerie.SelectedValueChanged -= cbSerie_SelectedValueChanged;

            cbSerie.ValueMember = "id"; // Ausgewählt wird die ID zum weiterarbeiten
            cbSerie.DisplayMember = "series"; // Angezeigt werden sollen die Namen der Serien
            cbSerie.DataSource = BurningSeries.Serien();
            cbSerie.SelectedValueChanged += cbSerie_SelectedValueChanged;
        }
        private void updateController1_updateFound(object sender, updateSystemDotNet.appEventArgs.updateFoundEventArgs e)
        {
            updateController1.updateInteractive();
        }
        // Wenn eine Serie ausgewählt wird Infos abfragen und zu cbEpisode hinzufügen.
        //
        private void cbSerie_SelectedValueChanged(object sender, EventArgs e)
        {
            cbStaffel.SelectedValueChanged -= cbStaffel_SelectedValueChanged;
            string selectedValue = cbSerie.SelectedValue.ToString();

            cbStaffel.DataSource = BurningSeries.SerienInfo(selectedValue);
            cbStaffel.SelectedValueChanged += cbStaffel_SelectedValueChanged;
        }
        private void cbStaffel_SelectedValueChanged(object sender, EventArgs e)
        {

            string selectedValue = cbStaffel.SelectedIndex.ToString();
            cbEpisode.DataSource = BurningSeries.EpisodenInfo(selectedValue);
            cbEpisode.DrawItem += cbEpisode_DrawItem;
        }
        private void cmdPlay_Click(object sender, EventArgs e)
        {
            switch (BurningSeries.HoleLink(cbEpisode.SelectedIndex.ToString()))
            {
                case "error1":
                    MessageBox.Show("Kein Vivo oder Streamcloud Link verfügbar");
                    break;
                default:

                    Hide();
                    VideoPlayer player = new VideoPlayer(BurningSeries.HoleLink(cbEpisode.SelectedIndex.ToString()), AutoPlay);
                    player.FormClosed += player_FormClosed;
                    player.ShowDialog(this);
                    break;
            }
        }

        private void player_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (AutoPlay)
            {
                if ((cbEpisode.SelectedIndex + 1) <= cbEpisode.Items.Count)
                {
                    cbEpisode.SelectedIndex += 1;
                }
                else
                {
                    //Staffelende erreeicht.
                }
            }
            else
            {
                cmdPlay.Enabled = true;
            }
            Show();
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }
        private void cbEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AutoPlay)
            {
                delay.Enabled = true;
            }
            cmdPlay.Enabled = true;
            toolStripLabel4.Enabled = true;
        }
        private void chkAutoplay_CheckedChanged(object sender, EventArgs e)
        {
            AutoPlay = chkAutoplay.Checked;
        }
        private void delay_Tick(object sender, EventArgs e)
        {
            delay.Enabled = false;
            switch (BurningSeries.HoleLink(cbEpisode.SelectedIndex.ToString()))
            {
                case "error1":
                    MessageBox.Show("Kein Vivo oder Streamcloud Link verfügbar");
                    break;
                default:
                    if (AutoPlay)
                    {
                        Hide();
                        VideoPlayer player = new VideoPlayer(BurningSeries.HoleLink(cbEpisode.SelectedIndex.ToString()), AutoPlay);
                        player.FormClosed += player_FormClosed;
                        player.ShowDialog(this);
                    }
                    break;
            }
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            switch (toolStripLabel2.Text)
            {
                case "Einloggen":
                    string apikey = BurningSeries.ApiKey();
                    switch (apikey)
                    {
                        case "errorUnPwWrong":
                            MessageBox.Show("Username oder Passwort falsch!");
                            toolStripLabel3.Visible = true;
                            toolStripSeparator2.Visible = true;
                            break;
                        case "errorunkown":
                            MessageBox.Show("Unbekannter Fehler!");
                            toolStripLabel3.Visible = true;
                            toolStripSeparator2.Visible = true;
                            break;
                        default:
                            toolStripLabel2.Text = "Ausloggen";
                            toolStripLabel3.Visible = false;
                            toolStripSeparator2.Visible = false;
                            break;
                    }
                    break;
                case "Ausloggen":
                    toolStripLabel3.Visible = false;
                    toolStripSeparator2.Visible = false;
                    Properties.Settings.Default.ApiKey = "";
                    Properties.Settings.Default.Save();
                    toolStripLabel2.Text = "Einloggen";
                    toolStripLabel3.Visible = true;
                    toolStripSeparator2.Visible = true;
                    break;
            }
        }
        private void cbEpisode_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;
            e.DrawBackground();
            if (combo != null)
            {
                if (combo.Items.Count < 1)
                {
                    return;
                }
                if (combo.Items[e.Index].ToString().EndsWith(" "))
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                    e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font, Brushes.ForestGreen, e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                    e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font, Brushes.Red, e.Bounds);
                }
            }
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.burning-seri.es/registrierung");
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            this.cbStaffel.SelectedIndex = this.Rnd.Next(0, this.cbStaffel.Items.Count);
            this.cbEpisode.SelectedIndex = this.Rnd.Next(0, this.cbEpisode.Items.Count);
        }
    }
}


