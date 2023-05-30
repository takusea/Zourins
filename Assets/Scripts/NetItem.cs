using System.Collections;
using UnityEngine;

public class NetItem : Item
{
    public float trapDuration = 10f; // 罠の効果が続く時間

    public override void Use()
    {
        // 相手を一定時間停止させる罠を設置する処理
        // ここでは、相手プレイヤーの移動を無効化する例を示します
        StartCoroutine(ActivateTrapCoroutine());
    }

    private IEnumerator ActivateTrapCoroutine()
    {
        // 相手プレイヤーを停止させる処理を実装
        // 例えば、速度をゼロに設定することで停止させることができます
        ShipController[] players = FindObjectsOfType<ShipController>();

        foreach (ShipController player in players)
        {
            player.StopMovement(); // プレイヤーの移動を停止するメソッドを実装してください
        }

        yield return new WaitForSeconds(trapDuration);

        // 罠の効果の時間が経過した後の処理
        foreach (ShipController player in players)
        {
            player.ResumeMovement(); // プレイヤーの移動を再開するメソッドを実装してください
        }
    }
}
