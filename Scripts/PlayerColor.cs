
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public Color[] colors;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        for (int i = 0; i < colors.Length; i++)
            colors[i].a = 1f;
    }

    void Start()
    {
        ChangeColor();
    }

    public void ChangeColor()
    {
        sr.color = colors[Random.Range(0, colors.Length)];
    }

    public void ChangeColorTo(Color newColor)
    {
        sr.color = newColor;
    }

    public Color GetColor()
    {
        return sr.color;
    }
}


