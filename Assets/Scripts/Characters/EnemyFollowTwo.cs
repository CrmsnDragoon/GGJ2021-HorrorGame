using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTwo : MonoBehaviour
{
    public float speedSlow;
    public float speedFast;
    public AudioSource giggle;

    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= 3 && Vector2.Distance(transform.position, target.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speedFast * Time.deltaTime);
        }

        else if(Vector2.Distance(transform.position, target.position) >= 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speedSlow * Time.deltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            giggle.Play();
        }
    }


}
