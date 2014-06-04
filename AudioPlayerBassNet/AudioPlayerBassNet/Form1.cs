using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass;

namespace AudioPlayerBassNet
{
    public partial class Form1 : Form
    {

        public event Action openMusic;
        public event Action initialize;
        public event Action playMusic;
        public event Action stopMusic;
        public event Action pauseMusic;
        public event Action playMusicByIndex;
        public event Action rewindTrackMD;
        public event Action rewindTrackMU;
        public event Action nextSong;
        public event Action prevSong;
        public event Action volumeUp;
        public event Action volumeDown;
        public event Action volButtonDown;
        public event Action volButtonUp;
        public event Action balanceButtonUp;
        public event Action balanceBoxChange;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (initialize != null)
                initialize();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            if (openMusic != null)
                openMusic();
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            if (playMusic != null)
                playMusic();
        }

        private void btOpen_Click_1(object sender, EventArgs e)
        {
            if (openMusic != null)
                openMusic();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            if (stopMusic != null)
                stopMusic();
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            if (pauseMusic != null)
                pauseMusic();
        }

        private void listPlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void musicProgress_MouseDown(object sender, MouseEventArgs e)
        {
            if (rewindTrackMD != null)
                rewindTrackMD();
        }

        private void musicProgress_MouseUp(object sender, MouseEventArgs e)
        {
            if (rewindTrackMU != null)
                rewindTrackMU();
        }

        private void listPlay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (playMusicByIndex != null)
                playMusicByIndex();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (nextSong != null)
                nextSong();
        }

        private void btPrev_Click(object sender, EventArgs e)
        {
            if (prevSong != null)
                prevSong();
        }

        private void volumeBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (volButtonDown != null)
                volButtonDown();
        }

        private void volumeBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (volButtonUp != null)
                volButtonUp();
        }

        private void balanceBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (balanceButtonUp != null)
                balanceButtonUp();
        }

        private void bakanceCenter_Click(object sender, EventArgs e)
        {
            if (balanceBoxChange != null)
                balanceBoxChange();
        }   
    }
}
