using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float despawnTime = 5f;
    public Rigidbody2D rigidBody2D;

    private void Start()
    {
        Destroy(gameObject, despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody2D.linearVelocity = Vector2.right * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") == true)
        {
            Destroy(gameObject);
        }
    }
}
