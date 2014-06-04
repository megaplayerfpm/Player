using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;

namespace AudioPlayerBassNet
{
    public class AudioDevice
    {
        public static void InitializeBass()
        {
            /*if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
            {
                MessageBox.Show("", Bass.BASS_ErrorGetCode().ToString());
            }
            */
            Bass.BASS_Init(-1, 22050, BASSInit.BASS_DEVICE_3D, IntPtr.Zero);
        }

        public static void FreeBass()
        {
            Bass.BASS_Stop();
            Bass.BASS_Free();
        }
    }
}
