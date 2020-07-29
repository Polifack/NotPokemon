using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Sprite[] frames;
    SpriteRenderer sr;

    bool isPlaying = false;
    float timer;
    int frameIndex;
    float animationTime;

    public void Setup(Sprite[] _frames, SpriteRenderer _sr, float _animationTime)
    {
        frames = _frames;
        sr = _sr;
        animationTime = _animationTime;
    }

    public void Play()
    {
        isPlaying = true;
    }

    public void Pause()
    {
        isPlaying = false;
    }

    public void ChangeFrames(Sprite[] _frames)
    {
        frames = _frames;
    }

    private void Update()
    {
        if (isPlaying && frames != null)
        {
            timer += Time.deltaTime;
            if (timer > animationTime)
            {
                frameIndex = ((frameIndex + 1) >= frames.Length) ? 0 : frameIndex + 1;
                sr.sprite = frames[frameIndex];
                timer = 0;
            }
        }
    }


}
