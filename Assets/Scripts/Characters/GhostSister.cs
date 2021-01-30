using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSister : MonoBehaviour
{
    public AudioSource goAway;
    public GameObject sister1;

    void Start()
    {
        GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            goAway.Play();
            Global.Health--;
            sister1.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
