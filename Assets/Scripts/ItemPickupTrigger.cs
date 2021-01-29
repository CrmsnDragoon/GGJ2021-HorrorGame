using System;
using UnityEngine;

public class ItemPickupTrigger : MonoBehaviour
{
    [SerializeField] private SpriteModal modal;
    [SerializeField] private ItemType item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        modal.DisplayModal(item);
        gameObject.SetActive(false);
    }
}
