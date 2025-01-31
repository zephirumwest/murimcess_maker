using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;
    private Image image;

    [SerializeField]
    private GameObject GameStart;
    [SerializeField]
    private GameObject Loading;

    private void Awake()
    {
        image = GetComponent<Image>();


        OnFade();
    }

    public void OnFade()
    {
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(1, 0));
            yield return new WaitForSeconds(3f);
            yield return StartCoroutine(Fade(0, 1));

            GameStart.SetActive(false);
            Loading.SetActive(true);
           
            
            break;
        }
    }
    
    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = image.color;
            color.a = Mathf.Lerp(start, end, percent);
            image.color = color;

            yield return null;
        }
    }

}
