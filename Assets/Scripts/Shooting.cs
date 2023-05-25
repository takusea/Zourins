using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ballPrefab; // 球のプレハブ
    public float shootForce = 10f; // 球を飛ばす力

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }
    }

    private void ShootBall()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();

        Vector2 shootDirection = transform.up;
        ballRb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
    }
}
