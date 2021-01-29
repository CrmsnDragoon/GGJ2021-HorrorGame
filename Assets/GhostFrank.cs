using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFrank : MonoBehaviour
{
    public Text healthText;
    public Text keyText;
    public GameObject growlCaption;
    public GameObject FranksBros;
    public AudioSource growl;


    private static int healthCount = Global.health;
    private static int keyCount = Global.key;


    void Start()
    {
        GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SetCountText();
            StartCoroutine(frankCallsBrothers());
        }
    }

    IEnumerator frankCallsBrothers()
    {
        growl.Play();
        Global.health--;
        growlCaption.SetActive(true);
        FranksBros.SetActive(true);
        yield return new WaitForSeconds(1);
        growlCaption.SetActive(false);
    }
}
