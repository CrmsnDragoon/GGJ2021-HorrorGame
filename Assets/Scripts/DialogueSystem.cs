using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    #region Singleton
    private static DialogueSystem _instance;

    public static DialogueSystem Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        this.gameObject.SetActive(false);
    }
    #endregion
    
    
}
