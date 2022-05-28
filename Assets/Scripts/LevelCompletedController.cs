using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletedController : MonoBehaviour
{
    [SerializeField] int showDuration = 5;
    [SerializeField] AudioClip levelWinClip;
    WaitForSeconds showSeconds;

    Canvas canvas;

    private void Reset()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Awake()
    {
        Reset();
        showSeconds = new WaitForSeconds(showDuration);
    }

    public IEnumerator ShowUI()
    {
        SoundManager.Instance.PlayClip(levelWinClip);
        canvas.enabled = true;
        yield return showSeconds;
        canvas.enabled = false;
    }
}
