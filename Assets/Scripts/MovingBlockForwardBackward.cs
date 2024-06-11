using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockForwardBackward : MonoBehaviour
{
    public float speed = 2.0f; // 블록이 움직이는 속도
    public float distance = 5.0f; // 블록이 움직이는 거리

    private Vector3 startPosition;
    private bool movingForward = true;
    private Vector3 previousPosition;

    void Start()
    {
        startPosition = transform.position;
        previousPosition = startPosition;
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (movingForward)
        {
            movement = Vector3.forward * speed * Time.deltaTime;
            transform.position += movement;
            if (transform.position.z >= startPosition.z + distance)
            {
                movingForward = false;
            }
        }
        else
        {
            movement = Vector3.back * speed * Time.deltaTime;
            transform.position += movement;
            if (transform.position.z <= startPosition.z - distance)
            {
                movingForward = true;
            }
        }

        // 플레이어가 블록 위에 있을 때 플레이어 위치 업데이트
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Player"))
            {
                child.position += movement;
            }
        }

        previousPosition = transform.position;
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
