using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBlock : MonoBehaviour
{
    public static Vector3 ori = new Vector3(2f, 2f, 95.56f);  // 예를 들어 시작 위치로 설정

    void OnTriggerEnter(Collider other)
    {

        ori = transform.position;
    }
}