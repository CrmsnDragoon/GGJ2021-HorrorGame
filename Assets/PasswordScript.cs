using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordScript : MonoBehaviour
{
    public GameObject passwordSimon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
            passwordSimon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
            passwordSimon.SetActive(false);
        }
    }
}
