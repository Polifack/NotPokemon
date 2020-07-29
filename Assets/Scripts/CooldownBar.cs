using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    public SpriteRenderer background;
    public SpriteRenderer filler;

    public Color emptyColor;
    public Color fillColor;

    private Vector2 _fillerMaxSize;

    private void Awake()
    {
        _fillerMaxSize = filler.size;

        background.gameObject.SetActive(false);
        filler.gameObject.SetActive(false);
    }

    public void enableCooldownBar()
    {
        background.gameObject.SetActive(true);
        filler.gameObject.SetActive(true);
    }
    public void disableCooldownBar()
    {
        background.gameObject.SetActive(false);
        filler.gameObject.SetActive(false);
    }

    public void setPercentage(float percentage)
    {
        float yValue = _fillerMaxSize.y;
        float xValue = percentage * _fillerMaxSize.x;

        Color percentageColor = emptyColor + percentage * fillColor;

        filler.size = new Vector2(xValue, yValue);
        filler.color = percentageColor;
    }

}
