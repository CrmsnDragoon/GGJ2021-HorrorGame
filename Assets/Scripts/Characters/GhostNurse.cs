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
            happy.Play();
            Global.Health++;
            nurse2.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
