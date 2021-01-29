using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBrother : MonoBehaviour
{
  
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
        }
    }

  //  IEnumerator frankCallsBrothers()
  //  {
       
     //   yield return new WaitForSeconds(1);
  //  }
}
