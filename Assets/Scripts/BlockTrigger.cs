using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class BlockCollision : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    private Renderer blockRenderer;
    public bool isCorrectBlock;
    private bool hasScored = false;

    // 모든 블록의 점수 획득 상태를 초기화하기 위한 리스트
    private static List<BlockCollision> allBlocks = new List<BlockCollision>();

    void Awake()
    {
        // 블록을 리스트에 추가
        allBlocks.Add(this);
    }

    void Start()
    {
        if (displayText != null)
        {
            displayText.gameObject.SetActive(false);
        }

        blockRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (displayText != null)
            {
                displayText.gameObject.SetActive(true);
                StartCoroutine(HideTextAfterDelay(3.0f)); // 3초 후 텍스트 비활성화
            }

            if (blockRenderer != null)
            {
                blockRenderer.material.color = GetRandomColor();
            }

            if (isCorrectBlock && !hasScored)
            {
                ScoreManager.instance.AddScore(10);
                hasScored = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // OnCollisionExit에서 텍스트 비활성화는 제거합니다.
        }
    }

    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }

    public static void ResetAllBlocks()
    {
        // 모든 블록의 점수 획득 상태 초기화
        foreach (var block in allBlocks)
        {
            block.hasScored = false;
        }
    }

    private IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (displayText != null)
        {
            displayText.gameObject.SetActive(false);
        }
    }
}
