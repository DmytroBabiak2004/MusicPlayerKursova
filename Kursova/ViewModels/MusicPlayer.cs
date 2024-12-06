using System;
using System.Windows.Media;

public class MusicPlayer
{
    private static MusicPlayer _instance;
    private MediaPlayer _mediaPlayer;
    private string _currentFilePath;

    public static MusicPlayer Instance => _instance ??= new MusicPlayer();

    public bool IsPlaying { get; private set; }

    private MusicPlayer()
    {
        _mediaPlayer = new MediaPlayer();
    }

    public void Play(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath)) return;

        if (IsPlaying && _currentFilePath != filePath)
        {
            Stop();
        }

        _mediaPlayer.Open(new Uri(filePath));
        _mediaPlayer.Play();
        _currentFilePath = filePath;
        IsPlaying = true;
    }

    public void Pause()
    {
        if (!IsPlaying) return;

        _mediaPlayer.Pause();
        IsPlaying = false;
    }

    public void Stop()
    {
        if (!IsPlaying) return;

        _mediaPlayer.Stop();
        _currentFilePath = null;
        IsPlaying = false;
    }
}
