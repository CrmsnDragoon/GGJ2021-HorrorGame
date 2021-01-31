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
            growl.Play();
            Global.Health--;
            if (FranksBros != null)
            {
                FranksBros.SetActive(true);
            }
        }
    }
}
