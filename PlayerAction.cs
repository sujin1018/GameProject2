using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    public GameManager manager;

    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;
    
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Move Value
        h = manager.isAction? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        //Check Button Down & Up
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        //Check Horizontal Move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp|| vUp)
            isHorizonMove = h != 0;


        //Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }

        //Direction
        //상
        if (vDown && v == 1)
            dirVec = Vector3.up;
        //하
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        //좌
        else if (hDown && h == -1)
            dirVec = Vector3.left;
        //우
        else if (hDown && h == 1)
            dirVec = Vector3.right;

        //Scan Object
        if (Input.GetButtonDown("Jump") && scanObject != null) //스페이스바
            manager.Action(scanObject);

    }

    void FixedUpdate()
    {
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.6f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.6f, LayerMask.GetMask("Object"));

        //사물이 있으면
        if(rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }

    }




    //무적효과 함수
    void OnDamaged(Vector2 targetPos)
    {


        //Change Layer(Immortal Active)
        gameObject.layer = 11;

        ////Sound
        //PlaySound("DAMAGED");
        //audioSource.Play();

        //View Alpha
        spriteRenderer.color = new Color(0.4f, 0, 0, 0.4f);

        ////Reaction Force
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        //Animation
        //anim.SetTrigger("doDamaged");

        //무적시간 해제
        Invoke("OffDamaged", 1);
    }
    //무적해제
    void OffDamaged()
    {
        //Change Layer(Immortal Active)
        gameObject.layer = 12;

        //View Alpha
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    //공격
    void OnAttack(Transform enemy)
    {

        //Reaction Force
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        //Enemy Die
        EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
        enemyMove.OnDamaged();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //적을 밟으면, ATTACK
            if (rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                OnAttack(collision.transform); //position
            }
            else //Damaged
                OnDamaged(collision.transform.position);
        }

    }
}
