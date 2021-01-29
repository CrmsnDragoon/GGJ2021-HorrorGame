﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMila2 : MonoBehaviour
{
    public SpriteRenderer MilaOff;
    public GameObject screamCaption;
    public AudioSource Scream;


    void Start()
    {
        GetComponent<AudioSource>();
    }


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
        screamCaption.SetActive(true);
        MilaOff.enabled=false;
        yield return new WaitForSeconds(1);
        screamCaption.SetActive(false);
    }
}