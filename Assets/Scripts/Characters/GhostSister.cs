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
    private BoxCollider2D _boxCollider;
    private Transform _target;
    private bool _moveTowardsTarget;
    [SerializeField] private Animator animator;
    [SerializeField] private float movementSpeed = 2;

    void Start()
    {
        //Reset position index and grab components.
        currentPositionIndex = 0;
        TryGetComponent(out _spriteRenderer);
        TryGetComponent(out _boxCollider);
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
            //Slow to do a nullcheck here, but it's fine for now.
            if (animator != null)
            {
                var moveDelta = (position - newPos);
                var maxSpeedThisFrame = movementSpeed * Time.deltaTime;
                animator.SetFloat(Speed, moveDelta.magnitude / maxSpeedThisFrame);
            }
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
            onCollisionSFX.Play();
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