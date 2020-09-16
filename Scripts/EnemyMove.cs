using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsulecollider;
    public int verticalMove; // 좌우 행동지표를 결정할 변수
    public int horizontalMove;// 상하 행동지표를 결정할 변수
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsulecollider = GetComponent<CapsuleCollider2D>();
        //Invoke(): 주어진 시간이 지난 뒤, 지정된 함수를 실행하는 함수
        Invoke("Think", 5);
    }
   void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector2(verticalMove, horizontalMove);

        ////지형 체크(Platform Check)       
        //Vector2 frontVec = new Vector2(rigid.position.x + verticalMove * 0.4f, rigid.position.y + horizontalMove * 0.4f);
        //Debug.DrawRay(frontVec, Vector3.right, new Color(0, 1, 0));
        //Debug.DrawRay(frontVec, Vector3.up, new Color(0, 1, 0));
        //RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector2.right, 1, LayerMask.GetMask("Default"));
        ////RaycastHit2D rayHit2 = Physics2D.Raycast(frontVec, Vector2.up, 1, LayerMask.GetMask("Default"));
        //if (rayHit.collider == null)
        //{
        //    Turn();
        //}

    }
    //행동지표를 바꿔줄 함수, 재귀함수
    void Think()
    {
        //Set Next Active
        do
        {
            verticalMove = Random.Range(-1, 2); //Random: 랜덤 수를 생성하는 로직 관련 클래스, Range(): 최소~최대 범위의 랜덤 수 생성(최대 제외)
            horizontalMove = Random.Range(-1, 2);
        } while (verticalMove != 0 && horizontalMove != 0);

        //Sprite Animation
        anim.SetInteger("WalkSpeed", verticalMove);

        //방향 Flip Sprite
        if (verticalMove != 0)
        {
            spriteRenderer.flipX = verticalMove == 1;
        }



        //Recursive
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }

    void Turn()
    {
        verticalMove *= -1;
        spriteRenderer.flipX = verticalMove == 1;

        //CancelInvoke(): 현재 작동 중인 모든 Invoke 함수를 멈추는 함수
        CancelInvoke();
        Invoke("Think", 3);
    }
    public void OnDamaged()
    {
        //Sprite Alpha 투명화
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        //Collider disable 콜라이더 비활성화
        capsulecollider.enabled = false;
        //Destroy 5초 뒤에 사라지게 함
        Invoke("DeActive", 1);
    }

    void DeActive()
    {
        gameObject.SetActive(false);
    }
}
