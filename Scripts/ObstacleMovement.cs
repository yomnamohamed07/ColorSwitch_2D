


using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

      
        Camera cam = Camera.main;
        if (cam != null && transform.position.y < -cam.orthographicSize - 1f)
        {
            Destroy(gameObject);
        }
    }
}