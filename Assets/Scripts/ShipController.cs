using System.Collections;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public float speed = 10f;
    public float rotationSpeed = 100f;
    public float maxSpeed = 20f;

    private bool isStunned = false;
    public float stunDuration = 2f;

    private bool isInvincible = false;
    public float invincibleDuration = 5f;

    public float blinkInterval = 0.2f;

    private bool isSlowed = false;

    public float moveVertical = 0f;
    public float moveHorizontal = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isStunned)
        {
            Move(transform.up * moveVertical * speed);
            Rotate(-moveHorizontal * rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !isInvincible)
        {
            StartCoroutine(Stun(stunDuration));
        }
    }

    private void Move(Vector2 movement)
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(movement);
        }
    }

    private void Rotate(float rotation)
    {
        rb.rotation += rotation;
    }

    public IEnumerator Stun(float duration)
    {
        isStunned = true;

        yield return new WaitForSeconds(duration);

        isStunned = false;

        StartCoroutine(Invincible(invincibleDuration));
    }

    public IEnumerator Invincible(float duration)
    {
        isInvincible = true;
        IEnumerator coroutine = Blink(blinkInterval);
        StartCoroutine(coroutine);

        yield return new WaitForSeconds(duration);

        isInvincible = false;
        StopCoroutine(coroutine);
        spriteRenderer.enabled = true;
    }

    public IEnumerator Blink(float interval)
    {
        while (true)
        {
            ToggleRenderer();

            yield return new WaitForSeconds(interval);
        }
    }

    private void ToggleRenderer()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }

    public IEnumerator Slowdown(float duration, float factor)
    {
        if (isSlowed)
        {
            yield break;
        }

        float originalSpeed = speed;
        float slowedSpeed = speed * factor;

        isSlowed = true;
        speed = slowedSpeed;

        yield return new WaitForSeconds(duration);

        isSlowed = false;
        speed = originalSpeed;
    }
}
