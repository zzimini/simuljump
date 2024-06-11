using UnityEngine;

public class BowAndArrow : MonoBehaviour
{
    public GameObject arrowPrefab;  // 화살 프리팹
    public Transform arrowSpawnPoint;  // 화살이 발사되는 위치
    public float launchForce = 10f;  // 발사력
    public Animator bowAnimator;  // 활 애니메이터
    public string shootAnimationTrigger = "Shoot";  // 애니메이션 트리거

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
        // 애니메이션 트리거 설정
        if (bowAnimator != null)
        {
            bowAnimator.SetTrigger(shootAnimationTrigger);
        }

        // 애니메이션이 끝날 때 화살을 발사하도록 코루틴을 시작합니다.
        StartCoroutine(LaunchArrowAfterAnimation());
    }

    System.Collections.IEnumerator LaunchArrowAfterAnimation()
    {
        // 애니메이션 재생 시간이 필요합니다. 여기서는 0.5초로 가정합니다.
        yield return new WaitForSeconds(0.5f);

        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.velocity = launchForce * arrowSpawnPoint.forward;

        isShooting = false;
    }
}
