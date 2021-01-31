using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSimon : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Global.HasSimonsNote)
        {
            gameObject.SetActive(false);
        }
    }
}
