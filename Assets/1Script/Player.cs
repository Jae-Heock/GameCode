using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 15f;
    float hAxis;
    float vAxis;

    Vector3 moveVec;
    Rigidbody rigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator animator;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.FreezeRotation;
        animator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        Move();
    }
    void Move()
    {
        // 입력값 받기
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        // 카메라 기준 방향 구하기
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // 카메라 기준 이동 방향
        moveVec = (camForward * vAxis + camRight * hAxis).normalized;

        // 이동 적용
        transform.position += moveVec * moveSpeed * Time.deltaTime;
        if (moveVec != Vector3.zero)
        {
            transform.LookAt(transform.position + moveVec); // 회전
        }
        animator.SetBool("isRun", moveVec != Vector3.zero);
    }
}
