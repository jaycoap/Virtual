using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 mousePos, mousePosTrans, moveTargetPos;
    float sprAngle;
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;

    public int Power;
    public float ShotDelay;
    public float ReloadDelay;
    public int Life;
    public GameObject Player_Bullet;
    public gameManager gameManager;
    public ObjecManager objecManager;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(1) || Input.GetMouseButtonUp(1))
        {
            CallMoveTagetPos();

            sprAngle = Mathf.Atan2(mousePosTrans.y - transform.position.y, mousePosTrans.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(sprAngle - 90, Vector3.forward);
        }

        MoveToTarget();     //마우스 클릭 위치로 이동
    }
    void Shot()
    {
        if (!Input.GetButton("Fire1"))
            return;
        if (ReloadDelay < ShotDelay)
            return;
        switch(Power)
        {
            case 1:
                GameObject Player_Bullet = objecManager.ManagerObject("Player_Bullet");
                Player_Bullet.transform.position = transform.position;
                Rigidbody2D rigid = Player_Bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                break;
        }
        ReloadDelay = 0;
    }
    void CallMoveTagetPos()
    {
        mousePos = Input.mousePosition;
        mousePosTrans = Camera.main.ScreenToWorldPoint(mousePos);
        
        if ((isTouchTop == true) || (isTouchBottom == true))
        {
            mousePosTrans.y = 0;
        }
        
        if ((isTouchLeft == true) || (isTouchRight == true))
        {
            mousePosTrans.x = 0;
        }
        moveTargetPos = new Vector3(mousePosTrans.x, mousePosTrans.y, 0);
    }

    void MoveToTarget()
    { 
        transform.position = Vector3.MoveTowards(transform.position, moveTargetPos, Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;

                case "Right":
                    isTouchRight = true;
                    break;
            }
        }
        else if(collision.gameObject.tag == "Gold")
        {
            Gold gold = collision.gameObject.GetComponent<Gold>();
            switch (gold.type)
            {
                case "Gold":
                    break;

            }
            gold.Destroy();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;

                case "Right":
                    isTouchRight = false;
                    break;
            }
        }
    }
}
