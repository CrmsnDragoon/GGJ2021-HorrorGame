using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoSidecar : MonoBehaviour
{
    public VideoPlayer player;
    public UnityEvent onVideoEnded;
    public void PlayVideo()
    {
        player.loopPointReached += OnVideoEndedEvent;
        player.Play();
    }

    private void OnVideoEndedEvent(VideoPlayer source)
    {
        player.loopPointReached -= OnVideoEndedEvent;
        onVideoEnded?.Invoke();
        source.Stop();
    }
}
