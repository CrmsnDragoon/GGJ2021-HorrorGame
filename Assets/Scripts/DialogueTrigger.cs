using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(BoxCollider2D))]
public class DialogueTrigger : MonoBehaviour
{
    [FormerlySerializedAs("DialoguesToDisplay")] 
    [SerializeField] private string[] dialoguesToDisplay;
    [SerializeField] private  Sprite[] spritePerLine;
    [SerializeField] private bool repeatable = false;
    [SerializeField] private bool dialogueShown = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Dialog Triggered");
        gameObject.SetActive(false);
        if (!dialogueShown || repeatable){
            dialogueShown = true;
            DialogueSystem.Instance.ShowDialogue(dialoguesToDisplay, spritePerLine);
        }
    }
}
