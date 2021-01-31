using UnityEngine;

public class GhostNurse2 : MonoBehaviour
{
   public AudioSource happy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            happy.Play();
            Global.Health++;
            gameObject.SetActive(false);
        }
    }
}
