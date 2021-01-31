using UnityEngine;

public class GhostSimon : MonoBehaviour
{
    [SerializeField] private bool gateBasedOnTrinkets = false;
    
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
        }
    }
}
