using UnityEngine;
using System.Collections;

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

    private bool isSlowed = false; // プレイヤーが遅くなっているかどうか
    private float slowdownTimer = 0f; // 遅くなっている残り時間
    private float slowdownFactor = 1f; // 通常の速度に対する遅くなる割合

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

        if (isSlowed)
        {
            // 遅くなっている残り時間を更新
            slowdownTimer -= Time.fixedDeltaTime;

            // 遅くなっている残り時間が0以下になった場合、遅くなる効果を解除
            if (slowdownTimer <= 0f)
            {
                isSlowed = false;
                SetPlayerSpeed(speed); // 通常の速度に戻す
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

    public void ApplySlowdown(float duration, float factor)
    {
        if (!isSlowed)
        {
            isSlowed = true;
            slowdownTimer = duration;
            slowdownFactor = factor;

            // プレイヤーを遅くする処理を実行
            StartCoroutine(SlowdownCoroutine());
        }
    }

    private IEnumerator SlowdownCoroutine()
    {
        float originalSpeed = speed; // 元の速度を保存
        float slowedSpeed = speed * slowdownFactor; // 遅くなった速度を計算
        SetPlayerSpeed(slowedSpeed); // 速度を遅くする

        yield return new WaitForSeconds(slowdownTimer);

        // 遅くなる効果の時間が経過した後の処理
        SetPlayerSpeed(originalSpeed); // 元の速度に戻す
    }

    private void SetPlayerSpeed(float newSpeed)
    {
        maxSpeed = newSpeed;
        // 速度に関連する処理を実装
        // 例えば、速度を直接変更するか、Rigidbody2Dの速度を更新するなどの方法があります
    }

    private float GetPlayerSpeed()
    {
        return maxSpeed;
        // 速度を返す処理を実装
        // 例えば、Rigidbody2Dの速度を返すなどの方法があります
    }
}
