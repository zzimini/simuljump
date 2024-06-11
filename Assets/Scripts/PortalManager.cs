using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalManager : MonoBehaviour
{
    public GameObject portalPrefab;  // ���� ������ ����
    public Vector3 portalPosition;   // ���� ���� ��ġ

    public void CreatePortal()
    {
        Instantiate(portalPrefab, portalPosition, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadMiniGame();
        }
    }

    private void LoadMiniGame()
    {
        SceneManager.LoadScene("MiniGameScene"); // �̴ϰ��� ���� �̸����� ����
    }
}
