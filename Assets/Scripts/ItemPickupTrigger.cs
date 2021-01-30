using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemPickupTrigger : MonoBehaviour
{
    [SerializeField] private ItemType item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SpriteModal.Instance.DisplayModal(item);
        gameObject.SetActive(false);
    }
}
