using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Global 
{
    private static int _health = 2;

    public static int Health
    {
        get => _health;
        set
        {
            _health = value;
            mainUI.Instance.UpdateTotals();
        }
    }
    

    static Dictionary<ItemType, ItemSprites> itemList;
    private static bool inputBlocked;
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