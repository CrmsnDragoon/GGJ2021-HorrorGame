using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostFrank : MonoBehaviour
{
    public GameObject growlCaption;
    public GameObject FranksBros;
    public AudioSource growl;

    void Start()
    {
        GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(frankCallsBrothers());
        }
    }

    IEnumerator frankCallsBrothers()
    {
        growl.Play();
        Global.Health--;
        growlCaption.SetActive(true);
        FranksBros.SetActive(true);
        yield return new WaitForSeconds(1);
        growlCaption.SetActive(false);
    }
}
