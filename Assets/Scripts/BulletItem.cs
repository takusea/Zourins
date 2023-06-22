using UnityEngine;
using UnityEngine.UI;

public class BulletItem : Item
{
    public Sprite sprite;
    public int additionalBalls = 5; // 追加する残弾数

    public override void Use()
    {
        // BulletItemの使用時の処理
        // Shootingクラスのインスタンスを取得
        Shooting shooting = FindObjectOfType<Shooting>();

        if (shooting != null)
        {
            // 残弾数を増加させる
            shooting.IncreaseRemainingBalls(additionalBalls);
        }
    }

    public override Sprite GetItemImage()
    {
        return sprite;
    }
}
