using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 10f; // 船の移動速度
    public float rotationSpeed = 100f; // 船の回転速度
    public float maxSpeed = 20f; // 船の速度上限
    public float stunDuration = 2f; // スタン状態の期間
    public float invincibleDuration = 5f; // 無敵時間の期間
    public float blinkInterval = 0.2f; // 点滅の間隔

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isStunned = false; // 船がスタン状態かどうか
    private float stunTimer = 0f; // スタン状態の経過時間
    private bool isInvincible = false; // 船が無敵状態かどうか
    private float invincibleTimer = 0f; // 無敵状態の経過時間
    private bool isBlinking = false; // 点滅中かどうか
    private float blinkTimer = 0f; // 点滅の経過時間

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isStunned)
        {
            float moveVertical = Input.GetAxis("Vertical");
            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector2 movement = transform.up * moveVertical * speed;

            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(movement);
            }

            float rotation = -moveHorizontal * rotationSpeed * Time.fixedDeltaTime;
            rb.rotation += rotation;
        }

        if (isStunned)
        {
            // スタン状態の経過時間を更新
            stunTimer += Time.fixedDeltaTime;

            // スタン状態の経過時間が指定の期間を超えた場合、無敵状態に移行
            if (stunTimer >= stunDuration)
            {
                isStunned = false;
                isInvincible = true;
                stunTimer = 0f;
                invincibleTimer = 0f;
                isBlinking = true;
                blinkTimer = 0f;
            }
        }

        if (isInvincible)
        {
            // 無敵状態の経過時間を更新
            invincibleTimer += Time.fixedDeltaTime;

            // 無敵状態の経過時間が指定の期間を超えた場合、無敵状態を解除
            if (invincibleTimer >= invincibleDuration)
            {
                isInvincible = false;
                invincibleTimer = 0f;
                isBlinking = false;
                spriteRenderer.enabled = true; // 点滅を停止し、表示を元に戻す
            }
        }

        if (isBlinking)
        {
            // 点滅の経過時間を更新
            blinkTimer += Time.fixedDeltaTime;

            // 点滅の間隔を超えた場合、表示を切り替える
            if (blinkTimer >= blinkInterval)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                blinkTimer = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 障害物に当たった場合
        if (collision.gameObject.CompareTag("Obstacle") && !isInvincible)
        {
            isStunned = true; // スタン状態にする
            stunTimer = 0f; // スタン状態の経過時間をリセット
            spriteRenderer.enabled = false; // 表示を切り替えて点滅を開始
            isBlinking = true;
            blinkTimer = 0f;
        }
    }
}
