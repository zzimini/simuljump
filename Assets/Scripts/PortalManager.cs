using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalManager : MonoBehaviour
{
    public GameObject portalPrefab;  // 포털 프리팹 참조
    public Vector3 portalPosition;   // 포털 생성 위치

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
        SceneManager.LoadScene("MiniGameScene"); // 미니게임 씬의 이름으로 변경
    }
}
