using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = Global.StartPosition;
    }
}
