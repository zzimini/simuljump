using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    private int score;
    public PortalManager portalManager; // 포털 매니저 참조 추가
    public GameObject finishNPCPrefab; // FinishNPC 프리팹
    private GameObject finishNPCInstance; // FinishNPC 인스턴스

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
        BlockCollision.ResetAllBlocks(); // 모든 블록의 점수 획득 상태 초기화
        if (finishNPCInstance != null)
        {
            finishNPCInstance.SetActive(false); // FinishNPC 비활성화
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
            // finishNPCPrefab이 있는 경우, 인스턴스화하여 나타냅니다.
            finishNPCInstance = Instantiate(finishNPCPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            // 이미 인스턴스화된 경우, 활성화합니다.
            finishNPCInstance.SetActive(true);
        }
    }
}
