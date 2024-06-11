using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    private int score;
    public PortalManager portalManager; // ���� �Ŵ��� ���� �߰�
    public GameObject finishNPCPrefab; // FinishNPC ������
    private GameObject finishNPCInstance; // FinishNPC �ν��Ͻ�

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();

        if (score >= 100)
        {
            portalManager.CreatePortal();
            ShowFinishNPC();
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
        BlockCollision.ResetAllBlocks(); // ��� ����� ���� ȹ�� ���� �ʱ�ȭ
        if (finishNPCInstance != null)
        {
            finishNPCInstance.SetActive(false); // FinishNPC ��Ȱ��ȭ
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void ShowFinishNPC()
    {
        if (finishNPCInstance == null)
        {
            // finishNPCPrefab�� �ִ� ���, �ν��Ͻ�ȭ�Ͽ� ��Ÿ���ϴ�.
            finishNPCInstance = Instantiate(finishNPCPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            // �̹� �ν��Ͻ�ȭ�� ���, Ȱ��ȭ�մϴ�.
            finishNPCInstance.SetActive(true);
        }
    }
}
