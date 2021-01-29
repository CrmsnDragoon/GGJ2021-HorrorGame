﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class mainUI : MonoBehaviour
{
    public Text healthText;
    public Image fadeblack;
    public Animator fadeanim;
    public int level;

    private float fail = 0;
    private static int healthCount = Global.health;


    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthCount == fail)
        {
            StartCoroutine(youDied());
        }
    }

    void SetCountText()
    {
        healthText.text = healthCount.ToString();
    }

    IEnumerator Fading()
    {
        fadeanim.SetBool("Fade", true);
        yield return new WaitUntil(() => fadeblack.color.a == 1);
        LoadScene(level);
    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    IEnumerator youDied()
    //void youDied()
    {
        gameObject.GetComponent<EmeryMove>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        // died.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}