using UnityEngine;
using UnityEngine.UI;

public class SubtitleController : MonoBehaviour {
    private static SubtitleController _instance;

    public static SubtitleController Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    [SerializeField] private Text subtitleText;

    private float _countdown = 0;
    
    private void Update()
    {
        if (_countdown > 0)
        {
            _countdown -= Time.deltaTime;

            if (_countdown < 0)
            {
                subtitleText.gameObject.SetActive(false);
            }
        }
    }

    public void ShowSubtitle(string text, float seconds)
    {
        subtitleText.gameObject.SetActive(true);
        subtitleText.text = text;
        _countdown = seconds;
    }

    public void HideSubtitle()
    {
        subtitleText.gameObject.SetActive(false);
        _countdown = -1;
    }
}
