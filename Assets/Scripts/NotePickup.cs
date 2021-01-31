using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NotePickup : MonoBehaviour
{
    [SerializeField] private int NoteIndex;

    [SerializeField] bool isSimonsNote;

    public AudioSource pickUp;

    private bool isLevel2 = false;
    
    private void Start()
    {
        if (Global.NoteIsCollected(isLevel2?4+NoteIndex: NoteIndex))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        pickUp.Play();
        this.gameObject.SetActive(false);
        Notes.Instance.ShowNote(NoteIndex);
        Global.HasSimonsNote = isSimonsNote;
        Global.CollectedNote(isLevel2?4+NoteIndex: NoteIndex);
    }
}
