﻿using NAudio.Wave;
using VoiceCraft_Android.Droid.Audio;
using VoiceCraft_Android.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(AudioManager))]
namespace VoiceCraft_Android.Droid.Audio
{
    public class AudioManager : IAudioManager
    {
        public IWavePlayer CreatePlayer(ISampleProvider waveProvider)
        {
            var Player = new AudioTrackOut();
            Player.Init(waveProvider);
            return Player;
        }

        public IWaveIn CreateRecorder(WaveFormat waveFormat)
        {
            var Recorder = new AudioRecorder();
            Recorder.WaveFormat = waveFormat;
            Recorder.BufferMilliseconds = 50;
            Recorder.audioSource = Android.Media.AudioSource.VoiceCommunication;
            return Recorder;
        }
    }
}