using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingBlock : MonoBehaviour
{
    public float speed = 2.0f; // �̵� �ӵ�
    public float distance = 5.0f; // �̵� �Ÿ�

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

        // �÷��̾ ��� ���� ���� �� �÷��̾� ��ġ ������Ʈ
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
