using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tenticle : MonoBehaviour
{
    public AudioSource sloppy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Global.Health--;
            StartCoroutine(sloppyMoment());

        }
    }

    IEnumerator sloppyMoment()
    {
        sloppy.Play();
        SubtitleController.Instance.ShowSubtitle("*really gross sloppy sound*", 2);
        yield return new WaitForSeconds(1);
    }
}
