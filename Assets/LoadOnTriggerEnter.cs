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
        Global.SetStartPosition(currentLevel);
        SceneManager.LoadScene(targetLevel);
    }
}
