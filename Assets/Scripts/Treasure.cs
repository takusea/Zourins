using UnityEngine;

public class Treasure : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Treasure"))
        {
            Destroy(collision.gameObject); // 宝箱を破壊する

            // アイテムを生成する処理を記述
            // 例えば、Instantiate()を使用してアイテムを生成するなど
            // 生成したアイテムを船の所持アイテムリストに追加するなどの処理を行います
        }
    }
}

