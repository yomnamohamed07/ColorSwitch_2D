


using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY
                       | RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); 
        rb.velocity = new Vector2(x * moveSpeed, 0);
    }
}
