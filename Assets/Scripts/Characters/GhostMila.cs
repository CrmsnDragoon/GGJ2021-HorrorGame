using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMila : MonoBehaviour
{

    public GameObject MilaOff;
    public GameObject MilaOn;
    public AudioSource Scream;


    void Start()
    {
        GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Scream.Play();
            MilaOn.SetActive(true);
            MilaOff.SetActive(false);

        }
    }
}
