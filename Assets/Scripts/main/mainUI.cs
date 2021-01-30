using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class mainUI : MonoBehaviour
{
    private static mainUI _instance;

    public static mainUI Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
    public Text healthText;
    public Image fadeblack;
    public Animator fadeanim;
    public int level;

    private float fail = 0;

    public ItemListScriptableObject itemList;

    
    // Start is called before the first frame update
    void Start()
    {
        UpdateTotals();
        //For WebGL, we may not have access to the Resources Folder
        if(itemList != null) 
        {
            Global.SetItemList(itemList);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.Health <= fail)
        {
            StartCoroutine(youDied());
        }
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
        Global.Reset();
        SceneManager.LoadScene(0);
    }

    public void UpdateTotals()
    {
        healthText.text = $"{Global.Health}";
    }
}
