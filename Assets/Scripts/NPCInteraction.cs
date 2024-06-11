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

    public VideoClip videoClip; // 각 건물마다 다른 비디오 클립을 설정하기 위한 변수

    void Start()
    {
        uiPanel.SetActive(false);
        playButton.onClick.AddListener(ToggleVideo); // 이벤트 리스너를 한 번만 추가
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None; // 커서를 자유롭게 움직일 수 있게 설정
            Cursor.visible = true; // 커서를 보이게 설정
            videoPlayer.clip = videoClip; // 비디오 클립을 동적으로 설정
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked; // 커서를 고정시켜 게임 환경에 맞게 설정
            Cursor.visible = false; // 커서를 숨김
            videoPlayer.Stop(); // 플레이어가 나가면 비디오 정지
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
