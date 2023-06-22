using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    public GameObject ballPrefab; // 球のプレハブ
    public float shootForce = 10f; // 球を飛ばす力
    public int initialRemainingBalls = 10; // 初期の残弾数

    private int remainingBalls; // 残弾数

    public int RemainingBalls => remainingBalls; // 残弾数の取得

    public UnityAction RemainingBallsChanged; // 残弾数が変更されたときに呼び出されるイベント

    private void Start()
    {
        remainingBalls = initialRemainingBalls; // 初期の残弾数を設定
    }

    public void ShootBall(Vector2 shootDirection)
    {
        if (remainingBalls > 0)
        {
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();

            ballRb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);

            remainingBalls--; // 残弾数を減らす

            // 残弾数が変更されたことを通知する
            RemainingBallsChanged?.Invoke();
        }
    }

    public void IncreaseRemainingBalls(int amount)
    {
        remainingBalls += amount; // 残弾数を増やす

        // 残弾数が変更されたことを通知する
        RemainingBallsChanged?.Invoke();
    }
}
