using System.Collections;
using UnityEngine;

public class NetItem : Item
{
    public Sprite sprite;

    public float trapDuration = 10f; // 罠の効果が続く時間

    public override void Use()
    {
        // 相手を一定時間停止させる罠を設置する処理
        // ここでは、相手プレイヤーの移動を無効化する例を示します
        ActivateTrap();
    }

    public override Sprite GetItemImage()
    {
        return sprite;
    }

    private void ActivateTrap()
    {
        // 相手プレイヤーを停止させる処理を実装
        // 例えば、速度をゼロに設定することで停止させることができます
        ShipController[] players = FindObjectsOfType<ShipController>();

        foreach (ShipController player in players)
        {
            StartCoroutine(player.Stun(trapDuration));
        }
    }
}
