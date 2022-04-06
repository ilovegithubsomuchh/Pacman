using UnityEngine;


public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[0];
    public float animationTime = 0.25f;
    public int animationFrame;
    public bool loop = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Advance), animationTime, animationTime);
    }

    private void Advance()
    {
        if (!spriteRenderer.enabled) {
            return;
        }

        animationFrame++;

        if (animationFrame >= sprites.Length && loop) {
            animationFrame = 0;
        }

        if (animationFrame >= 0 && animationFrame < sprites.Length) {
            spriteRenderer.sprite = sprites[animationFrame];
        }
    }

    public void Restart()
    {
        animationFrame = -1;

        Advance();
    }

}
