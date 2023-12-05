using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.LightingExplorerTableColumn;


[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] Sprite[] upSprites;
    [SerializeField] Sprite[] forwardSprites;
    [SerializeField] Sprite[] rightSprites;
    [SerializeField] Sprite[] leftSprites;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] int totalFramesPerAnimation = 4;
    [SerializeField] int animationFramesPerSecond = 12;

    private Direction direction = Direction.Forward;
    private Coroutine spriteAnimationsCoroutine;
    private bool animate = true;
    private float AnimationDuration => 1f / animationFramesPerSecond;
    enum Direction { Left, Right, Up, Forward }

    private void OnEnable()
    {
        InputHandler.OnInputMovement += ChangeSpriteSheetAnimation;

    }
    private void OnDisable()
    {
        InputHandler.OnInputMovement -= ChangeSpriteSheetAnimation;
    }

    private void ChangeSpriteSheetAnimation(Vector2 directionInput)
    {

      
        if (directionInput.y > 0.1)
            direction = Direction.Up;
        else if (directionInput.y < -0.1)
            direction = Direction.Forward;
        else if (directionInput.x > 0.1)
            direction = Direction.Right;
        else if (directionInput.x < -0.1)
            direction = Direction.Left;

        StartAnimation();


        if (directionInput == Vector2.zero)
        {
            StopAnimation();
            return;
        }
    }

    private void StopAnimation()
    {
        animate = false;
        if (spriteAnimationsCoroutine != null)
        {
            StopCoroutine(spriteAnimationsCoroutine);
            spriteAnimationsCoroutine = null;
        }
    }

    private void StartAnimation()
    {
        StopAnimation();
        animate = true;
        spriteAnimationsCoroutine = StartCoroutine(AnimateSprites());

    }

    IEnumerator AnimateSprites()
    {
        Sprite[] sprites = GetSpriteArray();
        int index = 1;

        do
        {
            if (sprites.Length > 0)
            {
                spriteRenderer.sprite = sprites[index];
                index++;
                if (index >= totalFramesPerAnimation)
                    index = 0;
            }
           
            yield return new WaitForSeconds(AnimationDuration);

        }
        while (animate);
       
    }

    public void RenderOneFrame()
    {
        Sprite[] sprites = GetSpriteArray();
        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[1];
        }
    }

    private Sprite[] GetSpriteArray()
    {
        switch (direction)
        {
            case Direction.Left:
                return leftSprites;
            case Direction.Right:
                return rightSprites;
            case Direction.Up:
                return upSprites;
            case Direction.Forward:
                return forwardSprites;
            default:
                return null;
        }
    }

    public void SetSprites(Sprite[] upSprites, Sprite[] forwardSprites, 
            Sprite[] rightSprites, Sprite[] leftSprites)
    {

        this.upSprites = upSprites;
        this.forwardSprites = forwardSprites;
        this.rightSprites = rightSprites;
        this.leftSprites = leftSprites;

        RenderOneFrame();
    }

    public void ClearSprites()
    {
        spriteRenderer.sprite = null;
        this.upSprites = Array.Empty<Sprite>();
        this.forwardSprites = Array.Empty<Sprite>();
        this.rightSprites = Array.Empty<Sprite>();
        this.leftSprites = Array.Empty<Sprite>();
    }


}
