using UnityEngine;
public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; // 使用するアイテムのプレハブを格納する配列

    public Item SpawnRandomItem()
    {
        // ランダムなインデックスを生成して、アイテムを選択する
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        GameObject selectedPrefab = itemPrefabs[randomIndex];

        // 選択したアイテムを生成する
        return Instantiate(selectedPrefab, transform.position, Quaternion.identity).GetComponent<Item>();
    }
}
