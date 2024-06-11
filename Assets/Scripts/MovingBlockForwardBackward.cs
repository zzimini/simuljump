using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockForwardBackward : MonoBehaviour
{
    public float speed = 2.0f; // ����� �����̴� �ӵ�
    public float distance = 5.0f; // ����� �����̴� �Ÿ�

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

        // �÷��̾ ��� ���� ���� �� �÷��̾� ��ġ ������Ʈ
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
