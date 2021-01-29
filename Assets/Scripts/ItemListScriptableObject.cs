using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "ScriptableObjects/ItemListScriptableObject", order = 1)]
public class ItemListScriptableObject : ScriptableObject
{
    [SerializeField] private ItemType[] itemTypes = new ItemType[Enum.GetNames(typeof(ItemType)).Length];
    [SerializeField] private Sprite[] itemSprites = new Sprite[Enum.GetNames(typeof(ItemType)).Length];

    public Dictionary<ItemType, ItemSprites> ConstructList()
    {
        Dictionary<ItemType, ItemSprites> list = new Dictionary<ItemType, ItemSprites>();
        for (var i = 0; i < itemTypes.Length; i++)
        {
            var sprite = new ItemSprites();
            sprite.sprite = itemSprites[i];;
            sprite.ItemType = itemTypes[i];
            list[itemTypes[i]] = sprite;
        }
        return list;
    }
}
