using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMila2 : MonoBehaviour
{
    public SpriteRenderer MilaOff;
    public AudioSource Scream;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(milaScreamMoment());
        }
    }

    IEnumerator milaScreamMoment()
    {
        Scream.Play();
        SubtitleController.Instance.ShowSubtitle("*Crackled Scream*",1);
        MilaOff.enabled=false;
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
