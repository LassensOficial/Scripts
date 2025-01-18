using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsCounter : MonoBehaviour
{
    private int frameCount = 0; // счётчик кадров
    private float timePerFrame = 0f; // время на один кадр
    private const float updateInterval = 1f; // интервал обновления

    public Text textFps;

    void Update()
    {
        frameCount++; // увеличиваем счётчик кадров на каждом кадре
        timePerFrame += Time.deltaTime; // суммируем время каждого кадра
        if (Time.time >= updateInterval) // если прошло достаточно времени
        {
            float fps = frameCount / timePerFrame; // вычисляем FPS
            textFps.text = ((int)fps).ToString();
            frameCount = 0; // сбрасываем счётчик кадров
            timePerFrame = 0f; // сбрасываем время на кадр
        }
    }
}
