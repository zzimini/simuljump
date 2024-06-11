using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAreaTrigger : MonoBehaviour
{
    public GameObject textObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textObject.SetActive(false);
        }
    }
}
