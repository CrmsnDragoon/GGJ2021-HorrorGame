using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemPickupTrigger : MonoBehaviour
{
    [SerializeField] private ItemType item;

    private void Start()
    {
        if (Global.TrinketIsCollected(item))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SpriteModal.Instance.DisplayModal(item);
        gameObject.SetActive(false);
        Global.CollectedTrinket(item);
        Global.TrinketScore++;
    }
}
