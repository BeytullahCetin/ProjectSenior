using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletedController : MonoBehaviour
{
    [SerializeField] int showDuration = 5;
    WaitForSeconds showSeconds;

    Canvas canvas;

    private void Awake()
    {
        showSeconds = new WaitForSeconds(showDuration);
        canvas = GetComponent<Canvas>();
    }

    public IEnumerator ShowUI()
    {
        canvas.enabled = true;
        yield return showSeconds;
        canvas.enabled = false;
    }
}
