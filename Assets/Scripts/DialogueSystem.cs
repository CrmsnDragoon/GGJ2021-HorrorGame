using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    [SerializeField] private Image faceplate;
    private float lineSpeed = 0.3f;
    private float characterTimer = 0; 
    private float currentLineIndex;
    private string currentLine;
    private int dialogLineIndex;
    private string[] currentDialogueLines;
    private Sprite[] currentDialogueSprites;

    public UnityEvent OnDialogueEndEvent = new UnityEvent();
    
    enum DialogueState
    {
        NoDialogue,
        OutputtingText,
        WaitingForInput
    }

    private DialogueState currentState;
    
    public void ShowDialogue(string[] dialogueToDisplay, Sprite[] sprites)
    {
        currentDialogueLines = dialogueToDisplay;
        currentDialogueSprites = sprites;
        currentLineIndex = 0;
        dialogLineIndex = 0;
        currentLine = dialogueToDisplay[dialogLineIndex];
        currentState = DialogueState.OutputtingText;
        textBox.text = String.Empty;
        if (sprites != null && sprites.Length != 0){
            faceplate.sprite = sprites[dialogLineIndex];
        }
        else
        {
            faceplate.sprite = null;
        }
        this.gameObject.SetActive(true);
        Global.BlockInput();
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
                if (currentDialogueSprites != null && currentDialogueSprites.Length > dialogLineIndex){
                    faceplate.sprite = currentDialogueSprites[dialogLineIndex];
                }
                else
                {
                    faceplate.sprite = null;
                }
            }
            else
            {
                currentState = DialogueState.NoDialogue;
                this.gameObject.SetActive(false);
                Global.UnblockInput();
                OnDialogueEndEvent?.Invoke();
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
