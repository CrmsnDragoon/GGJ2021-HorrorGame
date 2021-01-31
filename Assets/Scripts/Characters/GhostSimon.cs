using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GhostSimon : MonoBehaviour
{
    [SerializeField] private bool gateBasedOnTrinkets = false;

    [SerializeField] private UnityEvent onSatisfied = new UnityEvent();
    
    // Update is called once per frame
    void Update()
    {
        if (!gateBasedOnTrinkets && Global.HasSimonsNote)
        {
            gameObject.SetActive(false);
        }
        else if (Global.TrinketScore == 4)
        {
            gameObject.SetActive(false);
            onSatisfied?.Invoke();
        }
    }
}
