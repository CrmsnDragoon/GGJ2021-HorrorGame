using UnityEngine;

public class EnemyFollowTwo : MonoBehaviour
{
    public float speedSlow;
    public float speedFast;
    public AudioSource giggle;
    
    public float soundLength;
    
    private float soundTimer = -1;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        soundLength = giggle.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.EmeryInputBlocked)
        {
            return;
        }
        if (soundTimer > 0) soundTimer -= Time.deltaTime;
        if (soundTimer < 0) soundTimer = -1;
        
        float speed;
        if (Vector2.Distance(transform.position, target.position) <= 3 && Vector2.Distance(transform.position, target.position) > 1)
        {
            speed = speedFast;
        }
        else if(Vector2.Distance(transform.position, target.position) >= 4)
        {
            speed = speedSlow;
        }
        else
        {
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (soundTimer < 0 && other.gameObject.CompareTag("Player"))
        {
            giggle.Play();
            soundTimer = soundLength;
        }
    }
}
