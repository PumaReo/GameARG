using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flicking : MonoBehaviour
{
    [Header("Alpha Range")]
    [Range(0f, 1f)] public float minAlpha = 0.3f;
    [Range(0f, 1f)] public float maxAlpha = 1f;

    [Header("Animation")]
    public float speed = 1f;          // Скорость изменения
    public float smoothness = 2f;     // Плавность перехода

    [Header("Random")]
    public float randomAmount = 0.1f; // Сколько случайности добавлять
    public float randomSpeed = 0.5f;  // Как часто обновлять рандом

    private Image img;
    private Color currentColor;

    private float targetAlpha;
    private float randomOffset;
    private float randomTimer;

    void Start()
    {
        img = GetComponent<Image>();
        currentColor = img.color;

        targetAlpha = maxAlpha;

        // Случайный старт
        randomOffset = Random.Range(-randomAmount, randomAmount);
    }

    void Update()
    {
        randomTimer += Time.deltaTime;

        // Периодически обновляем рандом
        if (randomTimer >= randomSpeed)
        {
            randomTimer = 0f;
            randomOffset = Random.Range(-randomAmount, randomAmount);
        }

        // Синус для плавного пульса
        float t = (Mathf.Sin(Time.time * speed + randomOffset) + 1f) * 0.5f;

        // Интерполяция между min/max
        float desiredAlpha = Mathf.Lerp(minAlpha, maxAlpha, t);

        // Доп плавность
        currentColor.a = Mathf.Lerp(currentColor.a, desiredAlpha, Time.deltaTime * smoothness);

        img.color = currentColor;
    }
}
