using UnityEngine;

public class Bow : MonoBehaviour
{
    private bool isHeld = false;
    private Transform playerHand;

    void Start()
    {
        // 플레이어의 손 위치를 찾습니다.
        playerHand = GameObject.FindWithTag("PlayerHand").transform;
    }

    void Update()
    {
        if (isHeld)
        {
            // 활을 플레이어 손 위치로 이동시킵니다.
            transform.position = playerHand.position;
            transform.rotation = playerHand.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            // 활이 플레이어 손에 닿았을 때 플레이어가 활을 들게 합니다.
            isHeld = true;
            // 물리적 효과를 제거합니다.
            GetComponent<Rigidbody>().isKinematic = true;
            // 필요에 따라 부모로 설정하여 손에 부착
            transform.SetParent(playerHand);
        }
    }
}
