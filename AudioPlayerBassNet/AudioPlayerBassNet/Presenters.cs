using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Wma;

namespace AudioPlayerBassNet
{
    class Presenters
    {
        private Form1 view;
        private Model model;

        Timer PlayTimer = new Timer();  //?? о местоположении
        Timer BarTimer = new Timer();   //??
        //Timer changeTimer = new Timer(); 

        public Presenters(Form1 form1)
        {
            view = form1;
            model = new Model();
            view.initialize += InitializeBass;
            view.openMusic += Open;
            view.playMusic += Play;
            view.stopMusic += Stop;
            view.pauseMusic += Pause;
            view.nextSong += NextSong;
            view.prevSong += PrevSong;
            view.playMusicByIndex += Play;
            view.rewindTrackMD += Rewind_MouseDown;
            view.rewindTrackMU += Rewind_MouseUp;
            view.volButtonUp += volumeMouseUp;
            view.volButtonDown += volumeMouseDown;
            view.balanceButtonUp += balanceChange;
            view.balanceBoxChange += balanceChangeBox;
            view.FormClosed += ApplicationClose;
            view.Show();
            
            PlayTimer.Interval = 20;
            PlayTimer.Tick += PlayTimerFunc; //?????
            BarTimer.Interval = 20;
            BarTimer.Tick += BarTimerFunc;
            //view.timerForChange.Interval = 1000000000;
            view.timerForChange.Tick += changeSong;
            
        }

        private void setBarPos()
        {
            if (model.playStatus == "stopped")
                view.musicProgress.Value = 0;
            else
            {
                double curr = Bass.BASS_ChannelBytes2Seconds(model.stream, Bass.BASS_StreamGetFilePosition(model.stream, BASSStreamFilePosition.BASS_FILEPOS_CURRENT));
                double len = Bass.BASS_ChannelBytes2Seconds(model.stream, Bass.BASS_StreamGetFilePosition(model.stream, BASSStreamFilePosition.BASS_FILEPOS_END));
                int b = Convert.ToInt32(curr / len * 100);
                view.musicProgress.Value = b;
                
            }
        }

        private void BarTimerFunc(object sender, EventArgs e)
        {
            setBarPos();
            
        }

        private void PlayTimerFunc(object sender, EventArgs e)
        {
            Bass.BASS_ChannelPlay(model.stream, false);
            Bass.BASS_ChannelSetAttribute(model.stream, BASSAttribute.BASS_ATTRIB_VOL, model.volumeLevel);
            Bass.BASS_ChannelSetAttribute(model.stream, BASSAttribute.BASS_ATTRIB_PAN, model.balanceLevel);
            //view.timerForChange.Interval = (int)Bass.BASS_ChannelGetLength(model.stream)*100;

            if (Bass.BASS_StreamGetFilePosition(model.stream, BASSStreamFilePosition.BASS_FILEPOS_CURRENT) == Bass.BASS_StreamGetFilePosition(model.stream, BASSStreamFilePosition.BASS_FILEPOS_END))
            {
               model.playStatus = "stopped";
               Bass.BASS_ChannelStop(model.stream);
               setBarPos();
               PlayTimer.Stop();
            }
        }
       

        private void InitializeBass()
        {
            Bass.BASS_Init(-1, 22050, BASSInit.BASS_DEVICE_3D, IntPtr.Zero);
            model.playStatus = "stopped";
            model.volumeLevel = 0.5F;
            model.balanceLevel = 0;
           
            //model.BassPluginsHandles.Add(Bass.BASS_PluginLoad("bass_aac.dll"));
            //model.BassPluginsHandles.Add(Bass.BASS_PluginLoad("basswma.dll"));
            //model.BassPluginsHandles.Add(Bass.BASS_PluginLoad("bassflac.dll"));
            //Bass.BASS_SetVolume(model.volumeLevel);
            //Bass.BASS_ChannelSetAttribute(model.stream, BASSAttribute.BASS_ATTRIB_VOL, model.volumeLevel);
            view.balanceBar.Value = 0;
            view.balanceBox.Text = "0";
            view.volumeBar.Value = 50;
        }

        private void Open()
        {
            view.listPlay.Items.Clear();
            if (view.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                model.files = view.openFileDialog1.SafeFileNames;
                model.paths = view.openFileDialog1.FileNames;
                for (int i = 0; i < model.files.Length; i++)
                {
                    view.listPlay.Items.Add(model.files[i]);
                }
                view.listPlay.SelectedIndex = 0;
                Play();
            }
            
        }

        private void Play()
        {
            if (view.listPlay.SelectedItem != null)
            {
                if (model.playStatus == "playing")
                {
                    PlayTimer.Stop();
                    view.timerForChange.Stop();
                    Bass.BASS_ChannelStop(model.stream);
                    model.playStatus = "stopped";
                    model.stream = Bass.BASS_StreamCreateFile(model.paths[view.listPlay.SelectedIndex], 0, 0, BASSFlag.BASS_DEFAULT);
                    if (model.stream != 0)
                    {
                        model.playStatus = "playing";
                        PlayTimer.Start();
                        BarTimer.Start();
                        view.timerForChange.Interval = (int)Bass.BASS_ChannelBytes2Seconds(model.stream, Bass.BASS_ChannelGetLength(model.stream)) * 1000;
                        view.timerForChange.Start();
                    }
                }
                if (model.playStatus == "stopped")
                {
                    model.stream = Bass.BASS_StreamCreateFile(model.paths[view.listPlay.SelectedIndex], 0, 0, BASSFlag.BASS_DEFAULT);
                    if (model.stream != 0)
                    {
                        model.playStatus = "playing";
                        PlayTimer.Start();
                        BarTimer.Start();
                        view.timerForChange.Interval = (int)Bass.BASS_ChannelBytes2Seconds(model.stream, Bass.BASS_ChannelGetLength(model.stream)) * 1000;
                        view.timerForChange.Start();
                    }
                }
                else if (model.playStatus == "paused")
                {
                    view.timerForChange.Stop();
                    model.playStatus = "playing";
                    PlayTimer.Start();
                    BarTimer.Start();
                    view.timerForChange.Interval = (int)Bass.BASS_ChannelBytes2Seconds(model.stream, Bass.BASS_ChannelGetLength(model.stream)) * 1000;
                    view.timerForChange.Start();
                }
            }
        }

        private void Stop()
        {
            if (view.listPlay.SelectedItem != null)
            {
                view.timerForChange.Stop();
                PlayTimer.Stop();
                BarTimer.Stop();
                Bass.BASS_ChannelStop(model.stream);
                model.playStatus = "stopped";
                setBarPos();
            }
        }

        private void Rewind_MouseDown()
        {
          BarTimer.Stop();
          view.timerForChange.Stop();
        }

        private void Rewind_MouseUp()
        {
            try
            {
                Bass.BASS_ChannelPause(model.stream);
                double end = Bass.BASS_ChannelBytes2Seconds(model.stream, Bass.BASS_ChannelGetLength(model.stream));
                double newPos = view.musicProgress.Value * end / 100;
                Bass.BASS_ChannelSetPosition(model.stream, newPos);
                int allInterval = (int)Bass.BASS_ChannelBytes2Seconds(model.stream, Bass.BASS_ChannelGetLength(model.stream));
                int newInterval = (int)Bass.BASS_ChannelBytes2Seconds(model.stream, Bass.BASS_ChannelGetPosition(model.stream));
                view.timerForChange.Interval = (allInterval - newInterval) * 1000;
                BarTimer.Start();
                view.timerForChange.Start();
                Bass.BASS_ChannelPlay(model.stream, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void Pause()
        {
            if (view.listPlay.SelectedItem != null)
            {
                if (model.playStatus == "playing")
                {
                    PlayTimer.Stop();
                    view.timerForChange.Stop();
                    Bass.BASS_ChannelPause(model.stream);
                    model.playStatus = "paused";
                }
                else
                {
                    if (model.playStatus == "paused")
                    {
                        model.playStatus = "playing";
                        PlayTimer.Start();
                        view.timerForChange.Start();
                    }
                }
            }
        }

        private void NextSong()
        {
            if (view.listPlay.SelectedItem != null)
            {
                PlayTimer.Stop();
                BarTimer.Stop();
                view.timerForChange.Stop();
                Bass.BASS_ChannelStop(model.stream);
                model.playStatus = "stopped";
                setBarPos();
                if (view.listPlay.SelectedIndex == view.listPlay.Items.Count - 1)
                {
                    view.listPlay.SelectedIndex = 0;
                }
                else
                {
                    view.listPlay.SelectedIndex++;
                }
                model.stream = Bass.BASS_StreamCreateFile(model.paths[view.listPlay.SelectedIndex], 0, 0, BASSFlag.BASS_DEFAULT);
                if (model.stream != 0)
                {
                    model.playStatus = "playing";
                    PlayTimer.Start();
                    BarTimer.Start();
                    view.timerForChange.Interval = (int)Bass.BASS_ChannelBytes2Seconds(model.stream, Bass.BASS_ChannelGetLength(model.stream)) * 1000;
                    view.timerForChange.Start();
                }
            }
        }

        private void PrevSong()
        {
            if (view.listPlay.SelectedItem != null)
            {
                PlayTimer.Stop();
                BarTimer.Stop();
                view.timerForChange.Stop();
                Bass.BASS_ChannelStop(model.stream);
                model.playStatus = "stopped";
                setBarPos();
                if (view.listPlay.SelectedIndex == 0)
                {
                    view.listPlay.SelectedIndex = view.listPlay.Items.Count - 1;
                }
                else
                {
                    view.listPlay.SelectedIndex--;
                }
                model.stream = Bass.BASS_StreamCreateFile(model.paths[view.listPlay.SelectedIndex], 0, 0, BASSFlag.BASS_DEFAULT);
                if (model.stream != 0)
                {
                    model.playStatus = "playing";
                    PlayTimer.Start();
                    BarTimer.Start();
                    view.timerForChange.Interval = (int)Bass.BASS_ChannelBytes2Seconds(model.stream, Bass.BASS_ChannelGetLength(model.stream)) * 1000;
                    view.timerForChange.Start();
                }
            }
        }

        private void volumeMouseUp()
        {
            model.volumeLevel = (float)(view.volumeBar.Value) / 100;
            //Bass.BASS_SetVolume(model.volumeLevel);
            Bass.BASS_ChannelSetAttribute(model.stream, BASSAttribute.BASS_ATTRIB_VOL, model.volumeLevel);
        }

        private void volumeMouseDown()
        {

        }

        private void balanceChange()
        {
            model.balanceLevel = (float)(view.balanceBar.Value) / 100;
            view.balanceBox.Text = view.balanceBar.Value.ToString(); 
            Bass.BASS_ChannelSetAttribute(model.stream, BASSAttribute.BASS_ATTRIB_PAN, model.balanceLevel);
        }

        private void balanceChangeBox()
        {
            model.balanceLevel = 0;
            view.balanceBar.Value = 0;
            view.balanceBox.Text = "0";
            Bass.BASS_ChannelSetAttribute(model.stream, BASSAttribute.BASS_ATTRIB_PAN, model.balanceLevel);
        }

        public void changeSong(Object myObject, EventArgs myEventArgs)
        {
            if (view.listPlay.SelectedItem != null)
            {
                PlayTimer.Stop();
                BarTimer.Stop();
                view.timerForChange.Stop();
                Bass.BASS_ChannelStop(model.stream);
                model.playStatus = "stopped";
                setBarPos();
                if (view.listPlay.SelectedIndex == view.listPlay.Items.Count - 1)
                {
                    view.listPlay.SelectedIndex = 0;
                }
                else
                {
                    view.listPlay.SelectedIndex++;
                    model.stream = Bass.BASS_StreamCreateFile(model.paths[view.listPlay.SelectedIndex], 0, 0, BASSFlag.BASS_DEFAULT);
                    if (model.stream != 0)
                    {
                        model.playStatus = "playing";
                        PlayTimer.Start();
                        BarTimer.Start();
                        view.timerForChange.Interval = (int)Bass.BASS_ChannelBytes2Seconds(model.stream, Bass.BASS_ChannelGetLength(model.stream)) * 1000;
                        view.timerForChange.Start();
                    }
                }
            }
        }


        private void ApplicationClose(object sender, FormClosedEventArgs e)
        {
            Bass.BASS_Stop();
            //for (int i = 0; i < model.BassPluginsHandles.Count; i++)
            //   Bass.BASS_PluginFree(model.BassPluginsHandles[i]);
            Bass.BASS_Free();
            Application.Exit();
        }
    }
}
