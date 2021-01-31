using UnityEngine;

public class CollectableTrinket : MonoBehaviour
{
    [SerializeField] private ItemType item;
    [SerializeField] private UnityEngine.UI.Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.enabled = (false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.TrinketIsCollected(item))
        {
            image.enabled = (true);
            this.enabled = (false);
        }
    }
}
