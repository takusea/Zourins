using UnityEngine;

public class SakeItem : Item
{
    public Sprite sprite;

    public float slowdownDuration = 5f; // 酒の効果が続く時間
    public float slowdownFactor = 0.5f; // 酒の効果による速度減少率

    private ShipController player; // 酒の効果を受けるプレイヤー

    public override Sprite GetItemImage()
    {
        return sprite;
    }

    void Start()
    {
        player = GameObject.Find("Ship").GetComponent<ShipController>();
    }

    public override void Use()
    {
        if (player != null)
        {
            StartCoroutine(player.Slowdown(slowdownDuration, slowdownFactor));
        }
    }
}
