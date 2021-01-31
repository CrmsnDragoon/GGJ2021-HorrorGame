using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private string[] DialoguesToDisplay;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Dialog Triggered");
        gameObject.SetActive(false);
        DialogueSystem.Instance.ShowDialogue(DialoguesToDisplay);
    }
}
