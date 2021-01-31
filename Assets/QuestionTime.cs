using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTime : MonoBehaviour
{
    [SerializeField] private GameObject QuestionUI;
    [SerializeField] private string[] Correct = new string[1] {"Correct."};
    [SerializeField] private string[] IncorrectDia = new string[1] {"Incorrect. Try again."};
    public void AnswerCorrect()
    {
        QuestionUI.SetActive(false);
        DialogueSystem.Instance.OnDialogueEndEvent.AddListener(CorrectEndOfDialogue);
        DialogueSystem.Instance.ShowDialogue(Correct, null);
    }
    public void Incorrect()
    {
        QuestionUI.SetActive(false);
        DialogueSystem.Instance.ShowDialogue(IncorrectDia, null);
    }

    private void CorrectEndOfDialogue()
    {
        this.transform.parent.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Global.BlockInput();
        QuestionUI.SetActive(true);
    }
}
