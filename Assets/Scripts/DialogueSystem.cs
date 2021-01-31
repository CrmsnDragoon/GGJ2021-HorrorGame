using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    #endregion

    [SerializeField] private Text textBox;
    private float lineSpeed = 0.3f;
    private float characterTimer = 0; 
    private float currentLineIndex;
    private string currentLine;
    private int dialogLineIndex;
    private string[] currentDialogueLines;
    public Sprite[] spritePerLine;
    
    enum DialogueState
    {
        NoDialogue,
        OutputtingText,
        WaitingForInput
    }

    private DialogueState currentState;
    
    public void ShowDialogue(string dialogueToDisplay)
    {
        throw new System.NotImplementedException();
    }
    public void ShowDialogue(string[] dialogueToDisplay)
    {
        currentDialogueLines = dialogueToDisplay;
        currentLineIndex = 0;
        dialogLineIndex = 0;
        currentLine = dialogueToDisplay[dialogLineIndex];
    }

    public void ContinueDialogue()
    {
        if (currentState == DialogueState.OutputtingText)
        {
            currentState = DialogueState.WaitingForInput;
        }
        else if (currentState == DialogueState.WaitingForInput)
        {
            currentState = DialogueState.OutputtingText;
            currentLineIndex = 0;
            dialogLineIndex++;
            if (dialogLineIndex < currentDialogueLines.Length)
            {
                currentLine = currentDialogueLines[dialogLineIndex];
            }
            else
            {
                currentState = DialogueState.NoDialogue;
            }
        }
    }

    private void Update()
    {
        switch (currentState)
        {
            case DialogueState.NoDialogue:
                break;
            case DialogueState.OutputtingText:
                characterTimer -= Time.deltaTime;
                if (characterTimer < 0)
                {
                    if (currentLineIndex < currentLine.Length)
                    {
                        currentLineIndex++;
                        characterTimer = lineSpeed;
                        //Play sound here
                    }
                    else
                    {
                        currentState = DialogueState.WaitingForInput;
                        break;
                    }
                }
                textBox.text = currentLine.Substring(0, (int)currentLineIndex);
                break;
            case DialogueState.WaitingForInput:
                textBox.text = currentLine;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
