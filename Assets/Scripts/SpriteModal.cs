using UnityEngine;
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
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    #endregion
    [SerializeField] private SpriteRenderer itemSprite;
    [SerializeField] private Text itemText;

    public void DisplayModal(ItemType item)
    {
        var list = Global.GetItemList();
        itemText.text = list[item].Description;
        itemSprite.sprite = list[item].Sprite;
        gameObject.SetActive(true);
        Global.EmeryInputBlocked = true;
    }

    public void HideModal()
    {
        Global.EmeryInputBlocked = false;
        gameObject.SetActive(false);
    }
}
