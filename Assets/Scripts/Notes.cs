using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    #region Singleton
    private static Notes _instance;

    public static Notes Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        HideAllNotes();
    }
    #endregion

    [SerializeField] private GameObject[] notes = new GameObject[4];

    public void ShowNote(int noteIndex)
    {
        Global.BlockInput();
        HideAllNotes();
        this.gameObject.SetActive(true);
        notes[noteIndex].SetActive(true);
    }

    public void HideNote()
    {
        Global.UnblockInput();
        HideAllNotes();
    }

    private void HideAllNotes()
    {
        foreach (var note in notes)
        {
            note.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
}
