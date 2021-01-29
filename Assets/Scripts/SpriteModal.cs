using UnityEngine;
using UnityEngine.UI;

public class SpriteModal : MonoBehaviour
{
    [SerializeField] private SpriteRenderer itemSprite;
    [SerializeField] private Text itemText;

    public void DisplayModal(ItemType item)
    {

        var list = Global.GetItemList();
        gameObject.SetActive(true);
    }

    public void HideModal()
    {
        gameObject.SetActive(false);
    }
}
