using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMila : MonoBehaviour
{
    public GameObject MilaOn;
    public SpriteRenderer MilaOff;
    public AudioSource Scream;

    private bool FiredOnce;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !FiredOnce)
        {
            FiredOnce = true;
            StartCoroutine(milaScreamMoment());
        }
    }

    IEnumerator milaScreamMoment()
    {
        Scream.Play();
        SubtitleController.Instance.ShowSubtitle("*Crackled Scream*", 1);
        MilaOff.enabled = false;
        yield return new WaitForSeconds(1);
        if (MilaOn != null)
        {
            MilaOn.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}