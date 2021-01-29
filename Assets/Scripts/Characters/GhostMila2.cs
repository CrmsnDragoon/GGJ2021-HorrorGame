using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMila2 : MonoBehaviour
{
    public GameObject MilaOff;
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
            MilaOff.SetActive(false);

        }
    }
}
