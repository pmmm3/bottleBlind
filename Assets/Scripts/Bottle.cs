using UnityEngine;

public class Bottle : MonoBehaviour
{
    private int id;
    private bool selected;
    private Color color;
    [SerializeField] private SpriteRenderer spriteRenderer;


    public void SetColor(Color color)
    {
        spriteRenderer.color = this.color = color;
    }
}
