using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent2 : MonoBehaviour
{
    public GameObject target; // 플레이어 오브젝트
    public float wait = 1.0f;

    private Coroutine followCoroutine;

    void Start()
    {
        // 플레이어를 따라오는 코루틴 시작
        followCoroutine = StartCoroutine(MoveFollow());
    }

    void Update()
    {
        // 추가적인 업데이트 로직이 필요하면 여기에 작성
    }

    IEnumerator MoveFollow()
    {
        while (true)
        {
            if (target != null)
            {
                Vector3 targetPos = target.transform.position;
                GetComponent<NavMeshAgent>().SetDestination(targetPos);
            }
            yield return new WaitForSeconds(wait);
        }
    }
}
