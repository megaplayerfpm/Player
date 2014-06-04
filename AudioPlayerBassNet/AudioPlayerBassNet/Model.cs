using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Un4seen.Bass;

namespace AudioPlayerBassNet
{
    class Model
    {
        public string[] files;
        public string[] paths;
        public int stream;
        public string playStatus;
        public float volumeLevel;
        public float balanceLevel;
        public List<int> BassPluginsHandles = new List<int>();
        public BASS_CHANNELINFO info;
    }
}
