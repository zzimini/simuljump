using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingBlock : MonoBehaviour
{
    public float speed = 2.0f; // 이동 속도
    public float distance = 5.0f; // 이동 거리

    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (movingUp)
        {
            movement = Vector3.up * speed * Time.deltaTime;
            transform.position += movement;
            if (transform.position.y >= startPosition.y + distance)
            {
                movingUp = false;
            }
        }
        else
        {
            movement = Vector3.down * speed * Time.deltaTime;
            transform.position += movement;
            if (transform.position.y <= startPosition.y - distance)
            {
                movingUp = true;
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
