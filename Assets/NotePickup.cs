using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NotePickup : MonoBehaviour
{
    [SerializeField] private int NoteIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        this.gameObject.SetActive(false);
        Notes.Instance.ShowNote(NoteIndex);
    }
}
