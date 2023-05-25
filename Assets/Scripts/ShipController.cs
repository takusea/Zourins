using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 10f; // 船の移動速度
    public float rotationSpeed = 100f; // 船の回転速度

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = transform.up * moveVertical * speed;
        rb.AddForce(movement);

        float rotation = -moveHorizontal * rotationSpeed * Time.fixedDeltaTime;
        rb.rotation += rotation;
    }
}
