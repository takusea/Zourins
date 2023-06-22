using UnityEngine;
using UnityEngine.UI;

public class CoinItem : Item
{
    public Sprite sprite;
    public int scoreValue = 10; // コインアイテムのスコア値

    public override void Use()
    {
        // コインアイテムの使用時の処理
        // スコアを加算する
        ScoreManager.Instance.AddScore(scoreValue);
    }

    public override Sprite GetItemImage()
    {
        return sprite;
    }
}
