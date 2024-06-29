using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRoation : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения

    private Vector2 minBounds;
    private Vector2 maxBounds;
    private float objectWidth;
    private float objectHeight;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        objectWidth = rectTransform.rect.width / 4;
    }

    void Update()
    {
        // Получаем ввод с клавиатуры
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Определяем направление движения
        Vector2 movement = new Vector2(moveHorizontal, 0);

        // Перемещаем объект
        rectTransform.anchoredPosition += -movement * moveSpeed * Time.deltaTime;

        // Ограничиваем движение в пределах границ
        Vector2 newPosition = rectTransform.anchoredPosition;
        newPosition.x = Mathf.Clamp(newPosition.x, -objectWidth, objectWidth);

        rectTransform.anchoredPosition = newPosition;
    }
}
    
