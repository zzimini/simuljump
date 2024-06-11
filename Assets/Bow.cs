using UnityEngine;

public class Bow : MonoBehaviour
{
    private bool isHeld = false;
    private Transform playerHand;

    void Start()
    {
        // �÷��̾��� �� ��ġ�� ã���ϴ�.
        playerHand = GameObject.FindWithTag("PlayerHand").transform;
    }

    void Update()
    {
        if (isHeld)
        {
            // Ȱ�� �÷��̾� �� ��ġ�� �̵���ŵ�ϴ�.
            transform.position = playerHand.position;
            transform.rotation = playerHand.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            // Ȱ�� �÷��̾� �տ� ����� �� �÷��̾ Ȱ�� ��� �մϴ�.
            isHeld = true;
            // ������ ȿ���� �����մϴ�.
            GetComponent<Rigidbody>().isKinematic = true;
            // �ʿ信 ���� �θ�� �����Ͽ� �տ� ����
            transform.SetParent(playerHand);
        }
    }
}
