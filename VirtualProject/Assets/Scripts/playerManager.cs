using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 mousePos, mousePosTrans, moveTargetPos;
    float sprAngle;
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;

    public int Gold_check = 0;
    public int Power;
    public float ShotDelay;
    public float ReloadDelay;
    public int Life;
    public GameObject Player_Bullet;
    public gameManager gameManager;
    public ObjecManager objecManager;
    public new Transform transform;
    public int Player_maxHealth = 100;
    public int Player_Health;

    public HealthBar Player_HealthBar;

    void Start()
    {
        Player_Health = 100;
        Player_HealthBar.SetMaxHealth(Player_Health);
        Player_HealthBar.SetHealth(Player_Health);
    }

    void Update()
    {
        if (Input.GetMouseButton(1) || Input.GetMouseButtonUp(1))
        {
            CallMoveTagetPos();
            
            sprAngle = Mathf.Atan2(mousePosTrans.y - transform.position.y, mousePosTrans.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(sprAngle - 90, Vector3.forward);
        }

        Reload();
        
       
        Fire();
        

        MoveToTarget();     //마우스 클릭 위치로 이동
        //Shot();
        

    }
    void Fire()
    {
        if (!Input.GetButton("Fire1"))
        {
            return;
        }
        if (ShotDelay < ReloadDelay)
            return;

        
            GameObject bullet = Instantiate(Player_Bullet, transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector3.forward * 5, ForceMode2D.Impulse);
            ShotDelay = 0;
        
        
    }

    void Reload()
    {
        ShotDelay += Time.deltaTime;
    }
    /*void Shot()
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
    }*/
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
                case "UpperWall_Left_down":
                    isTouchBottom = true;
                    break;
                case "UpperWall_Left_Up":
                    isTouchTop = true;
                    break;
                case "UpperWall_Left":
                    isTouchLeft = true;
                    break;
                
                case "UpperWall_Right":
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
                    Gold_check++;
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
                case "UpperWall_Left_down":
                    isTouchBottom = false;
                    break;
                case "UpperWall_Left_Up":
                    isTouchTop = false;
                    break;
                case "UpperWall_Left":
                    isTouchLeft = false;
                    break;
                case "UpperWall_Right_down":
                    isTouchBottom = false;
                    break;
                case "UpperWall_Right_Up":
                    isTouchTop = false;
                    break;
                case "UpperWall_Right":
                    isTouchRight = false;
                    break;
            }
        }
    }
}
