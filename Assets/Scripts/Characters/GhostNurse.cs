using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostNurse : MonoBehaviour
{
    public AudioSource happy;
    public GameObject nurse2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Global.Health++;
            nurse2.SetActive(true);
            StartCoroutine(happyMoment());
        }
    }

    IEnumerator happyMoment()
    {
        happy.Play();
        SubtitleController.Instance.ShowSubtitle("*bloop bloop*", 1);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        
    }


}
