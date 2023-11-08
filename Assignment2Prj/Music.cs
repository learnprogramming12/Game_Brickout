using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Prj
{
    public enum MusicType
    {
        Lost,
        Win,
        BallAgainstBrick,
        BallAgainstPaddle,
        BallAgainstWall,
        Bomb,
    }
    internal class Music
    {
/*        private static System.Media.SoundPlayer _ballAgainstBrick;
        private static System.Media.SoundPlayer _lost;*/
        public static void Load()
        {
            //reduce the response time, preload, it happens a lot with less interval
          //  _ballAgainstBrick = new System.Media.SoundPlayer(Properties.Resources.BallAgainstBrick);
            
        }
        public static void play(MusicType type)
        {
            System.IO.UnmanagedMemoryStream sound = Properties.Resources.GameOver; 
            switch (type)
            {
                case MusicType.Lost:
                    sound = Properties.Resources.GameOver;
                    break;
                case MusicType.BallAgainstPaddle:
                case MusicType.BallAgainstWall:
                    return;
                case MusicType.Bomb:
                    sound = Properties.Resources.explode;
                    break;
                case MusicType.BallAgainstBrick:
                    sound = Properties.Resources.BallAgainstBrick;
                    break;
                case MusicType.Win:
                    sound = Properties.Resources.applause;
                    break;
            }
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(sound);
            player.Play();
            player.Dispose();
        }
    }
}
