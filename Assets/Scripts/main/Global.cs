using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global 
{
    private static int _health = 2;

    public static int Health
    {
        get => _health;
        set
        {
            _health = value;
            if (mainUI.Instance != null){
                mainUI.Instance.UpdateTotals();
            }
        }
    }
    

    static Dictionary<ItemType, ItemSprites> itemList;
    private static bool inputBlocked;
    public static bool HasSimonsNote;

    public static bool EmeryInputBlocked
    {
        get => inputBlocked;
    }

    public static Dictionary<ItemType, ItemSprites> GetItemList()
    {
        if (itemList == null)
        {
            var list = Resources.Load<ItemListScriptableObject>("ItemList");
            //Load list scriptable object
            itemList = list.ConstructList();
        }

        return itemList;
    }

    public static void BlockInput()
    {
        inputBlocked = true;
    }

    public static void UnblockInput()
    {
        inputBlocked = false;
    }

    public static void Reset()
    {
        Health = 10;
        HasSimonsNote = false;
        TrinketScore = 0;
        UnblockInput();
        CollectedNotes.Clear();
        CollectedTrinkets.Clear();
    }

    public static void SetItemList(ItemListScriptableObject itemListScriptableObject)
    {
        itemList = itemListScriptableObject.ConstructList();
    }

    public static Vector3[] StartPositions = new Vector3[3]
    {
        Vector3.zero,
        new Vector3(15.28f,27.2f,0f),
        new Vector3(1.51f,0,0)
    };
    public static Vector3 StartPosition = Vector3.zero;
    public static int TrinketScore = 0;

    public static void SetStartPosition(int currentLevel)
    {
        StartPosition = StartPositions[currentLevel];
    }

    public static readonly List<int> CollectedNotes = new List<int>();
    public static void CollectedNote(int noteIndex)
    {
        if (!CollectedNotes.Contains(noteIndex))
        {
            CollectedNotes.Add(noteIndex);
        }
    }
    public static bool NoteIsCollected(int noteIndex)
    {
        return CollectedNotes.Contains(noteIndex);
    }
    public static readonly List<ItemType> CollectedTrinkets = new List<ItemType>();
    public static void CollectedTrinket(ItemType trinketType)
    {
        if (!CollectedTrinkets.Contains(trinketType))
        {
            CollectedTrinkets.Add(trinketType);
        }
    }
    public static bool TrinketIsCollected(ItemType trinketType)
    {
        return CollectedTrinkets.Contains(trinketType);
    }
}

public enum ItemType
{
    Bow,
    Crown,
    Goat,
    Locket
}

public struct ItemSprites
{
    public ItemType ItemType;
    public Sprite Sprite;
    public string Description;
}