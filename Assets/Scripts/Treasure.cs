using UnityEngine;

public class Treasure : MonoBehaviour
{
    public GameObject itemPrefab; // アイテムのプレハブ

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ItemStore player = collision.GetComponent<ItemStore>();
            if (player != null)
            {
               

                // アイテムを生成してプレイヤーに追加する処理
                GameObject itemObject = Instantiate(itemPrefab, player.transform.position, Quaternion.identity);
                Item item = itemObject.GetComponent<Item>();
                player.AddItem(item);

                Destroy(gameObject); // 宝箱を破壊する
            }
        }
    }
}
