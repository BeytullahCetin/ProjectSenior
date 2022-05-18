using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingText : MonoBehaviour
{
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
        while (!isEnded)
        {
            if (!(text.localPosition.y < text.sizeDelta.y + screenHeight))
            {
                isEnded = true;
            }

            text.localPosition += Vector3.up;
            yield return slideSeconds;
        }
        isEnded = false;
        text.anchoredPosition = Vector2.zero;
        gameObject.SetActive(false);
    }
}
