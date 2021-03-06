﻿using UnityEngine;
using UnityEngine.UI;

public class SpriteModal : MonoBehaviour
{
    #region Singleton
    private static SpriteModal _instance;

    public static SpriteModal Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
        gameObject.SetActive(false);
    }
    #endregion
    [SerializeField] private Image itemSprite;
    [SerializeField] private Text itemText;

    public void DisplayModal(ItemType item)
    {
        var list = Global.GetItemList();
        itemText.text = list[item].Description;
        itemSprite.sprite = list[item].Sprite;
        gameObject.SetActive(true);
        Global.BlockInput();
    }

    public void HideModal()
    {
        Global.UnblockInput();
        gameObject.SetActive(false);
    }
}
