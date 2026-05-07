using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatMove : MonoBehaviour
{
    public Transform center;
    public float radius = 5f;
    public float speed = 2f;

    private float angle = 0f;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        Vector3 newPosition = center.position + new Vector3(x, 0, z);
        transform.position = newPosition;

        // 👉 Направление движения
        Vector3 direction = newPosition - lastPosition;

        // 👉 Поворот в сторону движения
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        lastPosition = newPosition;
    }
}
