using UnityEngine;

public class SakeItem : Item
{
    public float slowdownDuration = 5f; // 酒の効果が続く時間
    public float slowdownFactor = 0.5f; // 酒の効果による速度減少率

    private ShipController player; // 酒の効果を受けるプレイヤー

    public void SetPlayer(ShipController player)
    {
        this.player = player;
    }

    public override void Use()
    {
        if (player != null)
        {
            player.ApplySlowdown(slowdownDuration, slowdownFactor);
        }
    }
}
