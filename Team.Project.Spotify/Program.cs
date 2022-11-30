using System;
using System.Collections.Generic;

namespace Team.Project.Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utility SpotifyClient = Utility.GetInstance();
            SpotifyClient.PrintMainMenu();
        }

        public sealed class Utility
        {
            private static Utility _instance;
            private ConsoleText _consoletext;
            private bool _firstexecute;

            public static Utility GetInstance()
            {
                if (_instance == null)
                    _instance = new Utility(); 
                return _instance;
            }

            private Utility()
            {
                _firstexecute = true;
                _consoletext = ConsoleText.GetInstance();
            }

            public void PrintMainMenu()
            {
                Console.Clear();
                if(_firstexecute)
                {
                    
                }
            }

            private sealed class ConsoleText
            {
                private List<TextColor> _colors;
                private static ConsoleText _instance;

                private ConsoleText()
                {
                    _colors = new List<TextColor>();
                    _colors.Add(new TextColor((int)PaletteColor.TextDefault, (int)PaletteColor.BackgroundDefault));
                    _colors.Add(new TextColor((int)PaletteColor.TextDefault, (int)PaletteColor.Artist));
                    _colors.Add(new TextColor((int)PaletteColor.TextDefault, (int)PaletteColor.Album));
                    _colors.Add(new TextColor((int)PaletteColor.TextDefault, (int)PaletteColor.Playlist));
                    _colors.Add(new TextColor((int)PaletteColor.TextDefault, (int)PaletteColor.Radio));
                    _colors.Add(new TextColor((int)PaletteColor.BackgroundDefault, (int)PaletteColor.TextDefault));
                }
                public static ConsoleText GetInstance()
                {
                    if (_instance == null)
                        _instance = new ConsoleText();
                    return _instance;
                }

                private sealed class TextColor
                {
                    private int _foregroundColor;
                    private int _backgroundColor;

                    public int ForegroundColor { get { return _foregroundColor; } set { _foregroundColor = value; } }
                    public int BackgroundColor { get { return _backgroundColor; } set { _backgroundColor = value; } }

                    public TextColor(int _foreground, int _background)
                    {
                        _foregroundColor = _foreground;
                        _backgroundColor = _background;
                    }
                }
                private enum PaletteColor
                {
                    BackgroundDefault = ConsoleColor.Black,
                    Playlist = ConsoleColor.DarkGreen,
                    Album = ConsoleColor.DarkRed,
                    Artist = ConsoleColor.DarkMagenta,
                    Radio = ConsoleColor.DarkYellow,
                    TextDefault = ConsoleColor.White
                }
            }
            public enum MenuOption
            {
                Default = 0,
                Artists = 1,
                Albums = 2,
                Playlists = 3,
                Radio = 4,
                Search = 5
            }
        }

    }
}
