using System.Collections.Generic;
using UnityEngine;

public class ItemStore : MonoBehaviour
{
    private List<Item> items = new List<Item>(); // プレイヤーが保持するアイテムのリスト

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void UseItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            Item item = items[index];
            item.Use();
            items.RemoveAt(index);
        }
    }
}
