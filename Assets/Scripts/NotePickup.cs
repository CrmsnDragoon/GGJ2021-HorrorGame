using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NotePickup : MonoBehaviour
{
    [SerializeField] private int NoteIndex;

    [SerializeField] bool isSimonsNote;

    public AudioSource pickUp;

    private void Start()
    {
        GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        pickUp.Play();
        this.gameObject.SetActive(false);
        Notes.Instance.ShowNote(NoteIndex);
        Global.HasSimonsNote = isSimonsNote;
    }
}
