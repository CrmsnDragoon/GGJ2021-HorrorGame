using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostFrank : MonoBehaviour
{
    public GameObject FranksBros;
    public AudioSource growl;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Global.Health--;
            if (FranksBros != null)
            {
                FranksBros.SetActive(true);
                StartCoroutine(frankGruntMoment());
            }
        }
    }

    IEnumerator frankGruntMoment()
    {
        growl.Play();
        SubtitleController.Instance.ShowSubtitle("Frank: *Grunting*", 1);
        yield return new WaitForSeconds(1);
    }
}
