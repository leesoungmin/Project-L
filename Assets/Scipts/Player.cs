using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("플레이어 속도")]
    [SerializeField] float speed;

    [SerializeField] Vector2 inputVec;

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void FixedUpdate()
    {
        PlayerMovePos();
    }

    private void LateUpdate()
    {
        PlayerFlip();
    }

    void PlayerMove()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void PlayerMovePos()
    {
        //normalized : 벡터 값의 크기가 1이 되도록 좌표가 수정된 값
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + nextVec);
    }
    void PlayerFlip()
    {
        //magnitude : 벡터의 순수한 크기 값
        animator.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriteRenderer.flipX = inputVec.x < 0 ? true : false;
        }
    }
}
