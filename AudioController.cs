using System;
using System.Collections.Generic;
using System.Text;
using NAudio.Wave;
using NAudio.Vorbis;
using NVorbis;
using System.Threading;
using System.Collections;
using System.IO;

namespace Text_Adventure
{
    class AudioController
    {
        private class AudioPathStorage
        {
            public IList[] BGM { get;}
            public IList[] SFX { get;}

            private IList[] bgm;

            private IList[] sfx;
        }
        //BGM
        private static WaveOutEvent wavStream = new WaveOutEvent();

        //SFX
        private static WaveOutEvent[] outputDeviceSFX = new WaveOutEvent[5];
        private static WaveOutEvent waveOut = new WaveOutEvent();

        //Refrences all audio Files
        private static string[] SFXfiles = Directory.GetFiles(@"..\..\..\Resource_Files\AudioFiles\SFX\", "*.wav");
        private static string[] BGMfiles = Directory.GetFiles(@"..\..\..\Resource_Files\AudioFiles\BGM\", "*.ogg");

        public static class BusControl
        {
            public static void PlayWavAudioFiles(int BusType, int BusNumber, int audioIndex)
            {

                try
                {

                    AudioFileReader audioFile = new AudioFileReader(BGMfiles[audioIndex]);
                    switch (BusType)
                    {
                        //BGM
                        case 0:
                            wavStream.Dispose();
                            wavStream.Init(audioFile);
                            wavStream.Play();

                            break;

                        //SFX
                        case 1:
                            wavStream.Dispose();
                            wavStream.Init(audioFile);
                            wavStream.Play();

                            while (wavStream.PlaybackState == PlaybackState.Playing && wavStream.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1000);
                            }

                            break;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }

            public static void PlayOGGAudioFiles(int BusType, int BusNumber, int audioIndex)
            {
                VorbisWaveReader vorbisStream = new VorbisWaveReader(BGMfiles[audioIndex]);
                
                try
                {
                    vorbisStream.Dispose();
                    vorbisStream = new VorbisWaveReader(BGMfiles[audioIndex]);
                    
                    switch (BusType)
                    {
                        //BGM
                        case 0:

                            waveOut.Init(vorbisStream);
                            waveOut.Play();
                            break;

                        //SFX
                        case 1:
                            waveOut.Init(vorbisStream);
                            waveOut.Play();

                            break;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

}
