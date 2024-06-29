using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoation : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private float minX; // ����������� �������� �� ��� X (����� ������� ����)
    private float maxX; // ������������ �������� �� ��� X (������ ������� ����)

    [SerializeField] private Collider2D left;
    [SerializeField] private Collider2D right;

    void Start()
    {
            minX = left.transform.position.x;
            maxX = right.transform.position.x;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        // ��������� ����� ��������� ������
        Vector3 movement = new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // ������������ ��������� ������ �� ��� X
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // ������������� ����� ��������� ������
        transform.position = newPosition;
    }
}
    
