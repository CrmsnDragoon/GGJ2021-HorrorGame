using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class GhostSister : MonoBehaviour
{
    //Speed improvement when updating animator parameters.
    private static readonly int Speed = Animator.StringToHash("Speed");
    
    [FormerlySerializedAs("OnCollisionSFX")] 
    public AudioSource onCollisionSFX;

    public Vector3[] positions = new Vector3[1];

    [SerializeField] private int currentPositionIndex;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D[] _boxColliders;
    private Transform _target;
    private bool _moveTowardsTarget;
    [SerializeField] private Animator animator;
    [SerializeField] private float movementSpeed = 2;

    void Start()
    {
        //Reset position index and grab components.
        currentPositionIndex = 0;
        TryGetComponent(out _spriteRenderer);
        _boxColliders = GetComponents<BoxCollider2D>();
        if (animator == null && !TryGetComponent(out animator))
        {
            Debug.LogWarning($"Add an animator to {gameObject.name} to play a movement animation");
            //gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_moveTowardsTarget)
        {
            var position = transform.position;
            var newPos = Vector3.MoveTowards(position, _target.position,movementSpeed * Time.deltaTime);
            transform.position = newPos;
        }
    }
    
    private void StartMovingTowardsTarget(Transform targetTransform)
    {
        _target = targetTransform;
        _moveTowardsTarget = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartMovingTowardsTarget(other.transform);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Global.Health--;
            MoveToNextPosition();
            StartCoroutine(agathaMoment());
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
        _moveTowardsTarget = false;
    }

    private IEnumerator StartRemoval()
    {
        _spriteRenderer.enabled = false;
        foreach (var boxCollider in _boxColliders)
        {
            boxCollider.enabled = false;
        }
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    IEnumerator agathaMoment()
    {
        onCollisionSFX.Play();
        SubtitleController.Instance.ShowSubtitle("Sister Agatha: Nooo", 1);
        yield return new WaitForSeconds(1);
    }
}