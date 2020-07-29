using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PokemonVisuals : MonoBehaviour
{
    public Sprite[] forwardSprite;
    public Sprite[] backwardSprite;

    private Animation _anim;
    private SpriteRenderer _sr;

    private void Awake()
    {
        _anim = gameObject.AddComponent<Animation>();
        _sr = gameObject.GetComponent<SpriteRenderer>();
        _anim.Setup(forwardSprite, _sr, 0.1f);

        _anim.Play();
    }

    public void doFlip(bool isFlipping)
    {
        _sr.flipX = isFlipping;
    }
    public void doForward()
    {
        _anim.ChangeFrames(forwardSprite);
    }
    public void doBackward()
    {
        _anim.ChangeFrames(backwardSprite);
    }
}
