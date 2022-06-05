using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingText : MonoBehaviour
{
    public event Action OnTextEnd = delegate { };

    [SerializeField] RectTransform text;
    [Range(1, 10)]
    [SerializeField] int slideSpeed = 1;

    bool isEnded = false;
    float screenHeight;
    WaitForSeconds slideSeconds;

    void Awake()
    {
        screenHeight = Screen.currentResolution.height;
        slideSeconds = new WaitForSeconds(0.01f / slideSpeed);
    }

    public void StartSlideText()
    {
        gameObject.SetActive(true);
        StartCoroutine(SlideText());
    }

    IEnumerator SlideText()
    {
        //Text is slided until the whole text area is unvisible
        while (false == isEnded)
        {
            if (!(text.anchoredPosition.y < text.sizeDelta.y + screenHeight))
            {
                isEnded = true;
            }

            //Every slideSeconds text area is move up by 1 pixel
            text.anchoredPosition += Vector2.up;
            yield return slideSeconds;
        }

        //After all text slide operation is completed
        //Text area position has reset
        isEnded = false;
        text.anchoredPosition = Vector2.zero;
        gameObject.SetActive(false);
        OnTextEnd();
    }
}
