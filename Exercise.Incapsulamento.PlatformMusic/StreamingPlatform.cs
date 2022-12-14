using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using static Exercise.Incapsulamento.PlatformMusic.Application;
using static Exercise.Incapsulamento.PlatformMusic.Program;

namespace Exercise.Incapsulamento.PlatformMusic
{
    public enum SongStatus
    {
        Play,
        Stop,
        Pause
    }
    public abstract class StreamingPlatform : Player
    {
        protected string application_name;
        protected List<Song> application_tracks;
        protected Song streaming_song;
        protected Dictionary<Song, int> rated_songs;

        protected Timer streaming_timer;
        private int elapsedSeconds;
        protected abstract bool AccessVerified(User user_login);
        public StreamingPlatform(string _application_name)
        {
            application_name = _application_name;
            application_tracks = new List<Song>();
            rated_songs = new Dictionary<Song, int>();
            streaming_timer = new Timer(1000);
            elapsedSeconds = 0;
        }
        public void AddSong(string _song_name, int _song_duration)
        {
            Song newSong = new Song(_song_name, _song_duration);

            if (application_tracks.IndexOf(newSong) != -1)
                application_tracks.Add(newSong);
        }

        public bool RemoveSong(string _song_name, int _song_duration)
        {
            foreach (Song song in application_tracks)
                if (song.Name == _song_name && song.Duration == _song_duration)
                {
                    application_tracks.Remove(song);
                    return true;
                }

            return false;
        }

        protected class Song
        {
            private string song_name;
            private int song_rate;
            private SongStatus song_status;
            private int song_duration;
            private int song_actual_time;

            public Song(string _song_name, int _song_duration)
            {
                song_name = _song_name;
                song_duration = _song_duration;
                song_status = SongStatus.Stop;
                song_actual_time = 0;
            }

            public string DurationTime()
            {
                string duration = "";
                int h = 0, m = 0, s = 0;

                s = Math.DivRem(song_duration, 60, out m);
                m = Math.DivRem(song_duration, 60, out h);

                return h + ":" + m + ":" + s;
            }

            public string Name { get { return song_name; } set { song_name = value; } }
            public int Rate { get { return song_rate; } set { song_rate = value; } }
            public SongStatus Status { get { return song_status; } set { song_status = value; } }
            public int Duration { get { return song_duration; } set { song_duration = value; } }
            public int ActualTime { get { return song_actual_time; } set { song_actual_time = value; } }
        }



        internal void startTimer()
        {
            elapsedSeconds++;
            streaming_song.ActualTime = elapsedSeconds;
        }

        internal void stopTimer()
        {
            elapsedSeconds = 0;
        }

        public bool Play()
        {
            if (streaming_song != null)
            {
                streaming_song.Status = SongStatus.Play;

                streaming_timer.Start();
                startTimer();

                return true;
            }

            return false;
        }

        public bool Stop()
        {
            if (streaming_song != null)
            {
                streaming_song.Status = SongStatus.Stop;
                streaming_song.ActualTime = 0;

                streaming_timer.Stop();
                stopTimer();

                return true;
            }

            return false;
        }
        public bool Pause()
        {
            if (streaming_song != null)
            {
                streaming_song.Status = SongStatus.Pause;

                streaming_song.ActualTime = elapsedSeconds;
                streaming_timer.Stop();

                return true;
            }

            return false;
        }

        public void Rate()
        {
            if (streaming_song != null)
            {
                int newrate = 0;
                bool catchvalue = false;
                while (catchvalue == false)
                {
                    Console.Clear();
                    Console.WriteLine("Vote this Song (1/5): ");
                    catchvalue = Int32.TryParse(Console.ReadLine(), out newrate);
                }

                if (rated_songs[streaming_song] != 0)
                    rated_songs[streaming_song] = (streaming_song.Rate + newrate) / 2;
                else rated_songs.Add(streaming_song, newrate);
            }
        }
        public void Forward()
        {
            if (streaming_song != null)
            {
                int index = application_tracks.IndexOf(streaming_song);
                streaming_song.ActualTime = 0;

                if (index >= application_tracks.Count - 1)
                    streaming_song = application_tracks[0];
                else streaming_song = application_tracks[index + 1];

                if(streaming_song.Status != SongStatus.Play)
                    streaming_song.Status = SongStatus.Play;

                stopTimer();
                startTimer();
            }     
        }

        public void Backward()
        {
            if (streaming_song != null)
            {
                int index = application_tracks.IndexOf(streaming_song);

                if(streaming_song.ActualTime == 0)
                {
                    streaming_song.ActualTime = 0;

                    if (index <= 0)
                        streaming_song = application_tracks[application_tracks.Count - 1];
                    else streaming_song = application_tracks[index - 1];

                    if (streaming_song.Status != SongStatus.Play)
                        streaming_song.Status = SongStatus.Play;
                }

                stopTimer();
                startTimer();

            }
        }
    }

    public class Application : StreamingPlatform
    {
        private List<User> application_users;
        private User application_log_user;
        //private Dictionary<User, Dictionary<Song, int>> users_rate_songs;
        public Application(string _application_name) : base(_application_name)
        {
            application_users = new List<User>();
        }

        protected sealed override bool AccessVerified(User user_login)
        {
            if(application_users.IndexOf(user_login) == -1)
                return false;

            return true;
        }

        protected void ShowSongs()
        {
            foreach (Song song in application_tracks)
                Console.WriteLine($"{song.Name} [{song.DurationTime()}]");
        }

        protected bool LogInApplication(string username, string password)
        {
            User user_login = new User(username, password);

            if (AccessVerified(user_login))
            {
                application_log_user = user_login;
                return true;
            }
            else
                return false;
        }

        public void Start()
        {
            string username = "", password = "";
            bool result = false, dl_song = false; ;
            int command = 0, rs_song_duration = 0;
            string _song_name, _song_duration;

            Utility.ChangeTitleAppProgram(application_name);

            do
            {
                Utility.LogInProgramIndex(application_name);
                username = Utility.LogInData("Username");
                password = Utility.LogInData("Password");

                result = LogInApplication(username, password);
                 
                switch (result)
                {
                    case true:
                        Utility.IntoProgramIndex(application_name);

                        do
                        {
                            command = Utility.CatchCommand();

                            switch (command)
                            {
                                case 0:
                                    Utility.QuitProgram();
                                    break;

                                case 1:
                                    ShowSongs();
                                    break;

                                case 2:
                                    _song_name = Utility.CatchSongData("Titolo");
                                    int.TryParse(Utility.CatchSongData("Durata"), out rs_song_duration);
                                    AddSong(_song_name, rs_song_duration);
                                    break;

                                case 3:
                                    _song_name = Utility.CatchSongData("Titolo");
                                    int.TryParse(Utility.CatchSongData("Durata"), out rs_song_duration);
                                    
                                    Utility.CatchAction(RemoveSong(_song_name, rs_song_duration));
                                    break;

                                case 4:
                                    Utility.CatchAction(Play());
                                    break;

                                case 5:
                                    Utility.CatchAction(Pause());
                                    break;

                                case 6:
                                    Utility.CatchAction(Stop());
                                    break;

                                case -5:
                                    Utility.ErrorCommand();
                                    break;

                                Utility.PressKeyToContinue();
                            }
                        }
                        while (true);
                        break;

                    case false:
                        Utility.CatchAction(false);
                        Utility.PressKeyToContinue();
                        break;
                }
            }
            while (!result) ;
        }




        // ?? User Public into Application ??
        public class User
        {
            private string user_username;
            private string user_password;

            public string Username { get { return user_username; } set { user_username = value; } }
            public string Password { get { return user_password; } set { user_password = value; } }

            public User(string user_username, string user_password)
            {
                this.user_username = user_username;
                this.user_password = user_password;
            }
        }

    }





    interface Player
    {
        bool Play();
        bool Stop();
        bool Pause();
        void Rate();
        void Forward();
        void Backward();
    }


}
