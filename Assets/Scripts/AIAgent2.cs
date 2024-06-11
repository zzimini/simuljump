using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent2 : MonoBehaviour
{
    public GameObject target; // �÷��̾� ������Ʈ
    public float wait = 1.0f;

    private Coroutine followCoroutine;

    void Start()
    {
        // �÷��̾ ������� �ڷ�ƾ ����
        followCoroutine = StartCoroutine(MoveFollow());
    }

    void Update()
    {
        // �߰����� ������Ʈ ������ �ʿ��ϸ� ���⿡ �ۼ�
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
