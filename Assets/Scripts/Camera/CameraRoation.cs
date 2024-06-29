using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoation : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float minX = -10.0f; // Минимальное значение по оси X
    public float maxX = 10.0f;  // Максимальное значение по оси X

    public void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        // Вычисляем новое положение камеры
        Vector3 movement = new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Ограничиваем положение камеры по оси X
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Устанавливаем новое положение камеры
        transform.position = newPosition;
    }
}
    
