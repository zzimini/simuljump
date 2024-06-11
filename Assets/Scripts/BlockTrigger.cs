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

    // ��� ����� ���� ȹ�� ���¸� �ʱ�ȭ�ϱ� ���� ����Ʈ
    private static List<BlockCollision> allBlocks = new List<BlockCollision>();

    void Awake()
    {
        // ����� ����Ʈ�� �߰�
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
                StartCoroutine(HideTextAfterDelay(3.0f)); // 3�� �� �ؽ�Ʈ ��Ȱ��ȭ
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
            // OnCollisionExit���� �ؽ�Ʈ ��Ȱ��ȭ�� �����մϴ�.
        }
    }

    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }

    public static void ResetAllBlocks()
    {
        // ��� ����� ���� ȹ�� ���� �ʱ�ȭ
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
