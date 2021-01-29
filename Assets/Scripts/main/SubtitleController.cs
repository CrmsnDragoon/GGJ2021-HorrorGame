using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private Text SubtitleText;

    public void ShowSubtitle(string subtitleText)
    {
        
    }
}
