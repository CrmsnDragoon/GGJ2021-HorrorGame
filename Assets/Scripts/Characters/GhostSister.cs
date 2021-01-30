using System.Collections;
using UnityEngine;

public class GhostSister : MonoBehaviour
{
    public AudioSource OnCollisionSFX;
    public AudioTrigger audioTrigger;

    public Vector3[] positions = new Vector3[1];

    [SerializeField] private int currentPositionIndex;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    
    void Start()
    {
        //Reset position
        currentPositionIndex = 0;
        TryGetComponent(out _spriteRenderer);
        TryGetComponent(out _boxCollider);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCollisionSFX.Play();
            Global.Health--;
            MoveToNextPosition();
        }
    }

    void MoveToNextPosition()
    {
        //Start at starting position, then move to next position,
        //if we are out of positions, disable character
        if (currentPositionIndex < positions.Length)
        {
            transform.position = positions[currentPositionIndex];
        }
        else
        {
            StartCoroutine(StartRemoval());
        }
        currentPositionIndex++;
    }

    private IEnumerator StartRemoval()
    {
        _spriteRenderer.enabled = false;
        _boxCollider.enabled = false;
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}