using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTime : MonoBehaviour
{
    [SerializeField] private string[] Correct = new string[1] {"Correct."};
    [SerializeField] private string[] IncorrectDia = new string[1] {"Incorrect. Try again."};
    public void AnswerCorrect()
    {
        DialogueSystem.Instance.OnDialogueEndEvent.AddListener(CorrectEndOfDialogue);
        DialogueSystem.Instance.ShowDialogue(Correct, null);
    }
    public void Incorrect()
    {
        DialogueSystem.Instance.ShowDialogue(IncorrectDia, null);
    }

    private void CorrectEndOfDialogue()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
