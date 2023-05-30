using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image itemImage; // アイテムの画像を表示するImageコンポーネント

    public void SetItem(Item item)
    {
        if (itemImage != null)
        {
            itemImage.sprite = item.GetItemImage(); // アイテムの画像を取得して表示する
        }
    }

    public void RemoveItem()
    {
            itemImage.sprite = null; // アイテムの画像を取得して表示する
    }
}
