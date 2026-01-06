

           using UnityEngine;

public class MoveDown : MonoBehaviour
{
    Transform x;

    void Start()
    {
        x = transform;
    }

    void Update()
    {
        x.position = new Vector3(
            x.position.x,
            x.position.y - 1f * Time.deltaTime,
            x.position.z
        );
    }
}
