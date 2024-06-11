using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class NPCInteraction : MonoBehaviour
{
    public GameObject uiPanel;
    public Button playButton;
    public VideoPlayer videoPlayer;

    public VideoClip videoClip; // �� �ǹ����� �ٸ� ���� Ŭ���� �����ϱ� ���� ����

    void Start()
    {
        uiPanel.SetActive(false);
        playButton.onClick.AddListener(ToggleVideo); // �̺�Ʈ �����ʸ� �� ���� �߰�
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None; // Ŀ���� �����Ӱ� ������ �� �ְ� ����
            Cursor.visible = true; // Ŀ���� ���̰� ����
            videoPlayer.clip = videoClip; // ���� Ŭ���� �������� ����
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked; // Ŀ���� �������� ���� ȯ�濡 �°� ����
            Cursor.visible = false; // Ŀ���� ����
            videoPlayer.Stop(); // �÷��̾ ������ ���� ����
        }
    }

    void ToggleVideo()
    {
        Debug.Log("Button clicked");
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }
}
