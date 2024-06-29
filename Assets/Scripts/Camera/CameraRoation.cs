using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRoation : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ��������

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
        // �������� ���� � ����������
        float moveHorizontal = Input.GetAxis("Horizontal");

        // ���������� ����������� ��������
        Vector2 movement = new Vector2(moveHorizontal, 0);

        // ���������� ������
        rectTransform.anchoredPosition += -movement * moveSpeed * Time.deltaTime;

        // ������������ �������� � �������� ������
        Vector2 newPosition = rectTransform.anchoredPosition;
        newPosition.x = Mathf.Clamp(newPosition.x, -objectWidth, objectWidth);

        rectTransform.anchoredPosition = newPosition;
    }
}
    
