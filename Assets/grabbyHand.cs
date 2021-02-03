using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbyHand : MonoBehaviour
{
 
    public AudioSource growl;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Global.Health--;
            StartCoroutine(grabbyMoment());
        }
    }

    IEnumerator grabbyMoment()
    {
        growl.Play();
        SubtitleController.Instance.ShowSubtitle("*rabid growling*", 1);
        yield return new WaitForSeconds(1);
    }
}
