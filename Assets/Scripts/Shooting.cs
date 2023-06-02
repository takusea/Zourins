using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ballPrefab; // 球のプレハブ
    public float shootForce = 10f; // 球を飛ばす力

    public void ShootBall(Vector2 shootDirection)
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();

        ballRb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
    }
}
