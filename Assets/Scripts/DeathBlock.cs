using System.Collections;
using StarterAssets;
using UnityEngine;

public class DeathBlock : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            ScoreManager.instance.ResetScore(); // 점수와 블록 상태 초기화
            StartCoroutine(ResetPlayerPosition());
        }
    }

    IEnumerator ResetPlayerPosition()
    {
        var thirdPersonController = player.GetComponent<ThirdPersonController>();
        var characterController = player.GetComponent<CharacterController>();
        var rigidbody = player.GetComponent<Rigidbody>();

        if (thirdPersonController != null) thirdPersonController.enabled = false;
        if (characterController != null) characterController.enabled = false;

        if (rigidbody != null)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.isKinematic = true;
        }

        yield return new WaitForSeconds(2);

        player.transform.position = CheckPointBlock.ori;
        player.transform.rotation = Quaternion.identity;

        yield return new WaitForSeconds(0.1f);

        if (rigidbody != null)
        {
            rigidbody.isKinematic = false;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

        if (characterController != null) characterController.enabled = true;
        if (thirdPersonController != null) thirdPersonController.enabled = true;
    }
}
