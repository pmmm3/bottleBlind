using UnityEngine;

namespace BotBlind.Bottle
{
    public class Bottle : MonoBehaviour
    {
        private int id;
        private bool selected;
        private Color _color;
        [SerializeField] private SpriteRenderer spriteRenderer;


        public void SetColor(Color color)
        {
            spriteRenderer.color = this._color = color;
        }

        public Color GetColor()
        {
            return this._color;
        }
        
    }
}
