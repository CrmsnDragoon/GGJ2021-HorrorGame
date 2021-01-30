using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TutorialSong : MonoBehaviour
{
    [SerializeField] private bool played;
    [SerializeField] private PlayableDirector playable;
    [SerializeField] private AudioSource song;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (played)
        {
            return;
        }
        if (!other.gameObject.CompareTag("Player")) return;

        song.Play();
        playable.Play();
        played = true;
    }
}
