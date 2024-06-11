using UnityEngine;

public class BowAndArrow : MonoBehaviour
{
    public GameObject arrowPrefab;  // ȭ�� ������
    public Transform arrowSpawnPoint;  // ȭ���� �߻�Ǵ� ��ġ
    public float launchForce = 10f;  // �߻��
    public Animator bowAnimator;  // Ȱ �ִϸ�����
    public string shootAnimationTrigger = "Shoot";  // �ִϸ��̼� Ʈ����

    private bool isShooting = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            isShooting = true;
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        // �ִϸ��̼� Ʈ���� ����
        if (bowAnimator != null)
        {
            bowAnimator.SetTrigger(shootAnimationTrigger);
        }

        // �ִϸ��̼��� ���� �� ȭ���� �߻��ϵ��� �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(LaunchArrowAfterAnimation());
    }

    System.Collections.IEnumerator LaunchArrowAfterAnimation()
    {
        // �ִϸ��̼� ��� �ð��� �ʿ��մϴ�. ���⼭�� 0.5�ʷ� �����մϴ�.
        yield return new WaitForSeconds(0.5f);

        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.velocity = launchForce * arrowSpawnPoint.forward;

        isShooting = false;
    }
}
