using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOne : MonoBehaviour
{
    public Image fadeblack;
    public Animator fadeanim;
    public int level;
   
    // Start is called before the first frame update
   public void loadScene()
    {
        StartCoroutine(Fading());
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
}