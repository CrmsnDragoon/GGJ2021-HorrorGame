using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnTriggerEnter : MonoBehaviour
{
    public int currentLevel;
    public int targetLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (targetLevel < 2 && targetLevel > 0){
            Global.SetStartPosition(targetLevel);
            SceneManager.LoadScene(targetLevel);
        }
    }
}
