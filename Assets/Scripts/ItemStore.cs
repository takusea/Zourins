using System.Collections.Generic;
using UnityEngine;

public class ItemStore : MonoBehaviour
{
    private List<Item> items = new List<Item>(); // プレイヤーが保持するアイテムのリスト
    public ItemUI itemUI;

    public void AddItem(Item item)
    {
        itemUI.SetItem(item);
        items.Add(item);
    }

    public Item item(int index)
    {
        return items[index];
    }

    public void UseItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            Item item = items[index];
            item.Use();
            items.RemoveAt(index);
            itemUI.RemoveItem();
        }
    }
}
