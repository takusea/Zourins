using UnityEngine;

public class Treasure : MonoBehaviour
{
    public ItemSpawner itemSpawner; // アイテムのプレハブ

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ItemStore player = collision.GetComponent<ItemStore>();
            if (player != null)
            {
                Item item = itemSpawner.SpawnRandomItem();
                player.AddItem(item);

                Destroy(gameObject); // 宝箱を破壊する
            }
        }
    }
}
