using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleNun : MonoBehaviour
{
    public AudioSource soundTrigger;

    private bool soundPlayed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (soundPlayed == true || !gameObject.activeInHierarchy)
        {
            return;
        }
        if (!collision.gameObject.CompareTag("Player")) return;
        //  soundTrigger.Play();
        StartCoroutine(comeMoment());
        soundPlayed = true;
    }

    public void ResetTrigger()
    {
        soundPlayed = false;
    }

    IEnumerator comeMoment()
    {
        soundTrigger.Play();
        SubtitleController.Instance.ShowSubtitle("Sister Agatha: Stay Away.", 2);
        yield return new WaitForSeconds(1);
    }
}
