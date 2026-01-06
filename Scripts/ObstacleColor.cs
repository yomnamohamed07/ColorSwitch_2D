
using UnityEngine;

public class ObstacleColor : MonoBehaviour
{
    public enum ObstacleType { ColorObstacle, DeadlyObstacle }
    public ObstacleType obstacleType = ObstacleType.ColorObstacle;
    public Color obstacleColor = Color.white;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) 
            return;

        PlayerColor pc = collision.GetComponent<PlayerColor>();
        if (pc == null) 
            return;

        if (obstacleType == ObstacleType.DeadlyObstacle)
        {
            GameManager.instance?.GameOver();
        }
        else if (obstacleType == ObstacleType.ColorObstacle)
        {
            pc.ChangeColorTo(obstacleColor);
            GameManager.instance?.AddScore(1);
        }

        Destroy(gameObject); 
    }
}
