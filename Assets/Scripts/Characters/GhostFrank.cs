using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostFrank : MonoBehaviour
{
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
            growl.Play();
            Global.Health--;
            FranksBros.SetActive(true);
        }
    }

   // IEnumerator frankCallsBrothers()
  //  {
        
        //yield return new WaitForSeconds(1);

  //  }
}
