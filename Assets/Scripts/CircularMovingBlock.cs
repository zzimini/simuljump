using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovingBlock : MonoBehaviour
{
    public float speed = 2.0f; // 회전 속도
    public float radius = 5.0f; // 원의 반지름

    private Vector3 centerPosition;
    private float angle;

    void Start()
    {
        centerPosition = transform.position;
    }

    void Update()
    {
        angle += speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(centerPosition.x + x, centerPosition.y, centerPosition.z + z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
