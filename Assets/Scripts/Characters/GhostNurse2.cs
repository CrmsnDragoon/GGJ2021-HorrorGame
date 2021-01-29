using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostNurse2 : MonoBehaviour
{
    public AudioSource happy;

    void Start()
    {
        GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            happy.Play();
            Global.Health++;
            gameObject.SetActive(false);
        }
    }
}
