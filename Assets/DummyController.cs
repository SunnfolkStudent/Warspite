using UnityEngine;

public class DummyController : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    [Header("health")]
    public int health = 10000;

    public float damageCooldown = 0.3f;
    private float _damageCooldownTimer;

    private void TakeDamage()
    {
        if (Time.time > _damageCooldownTimer)
        {
            health -= 1;
            _damageCooldownTimer = Time.time + damageCooldown;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet") == true)
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }

}
