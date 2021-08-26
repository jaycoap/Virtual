using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private Movement2D movement2D;
    private SpiderSpawner spiderSpawner;

    public float Attack_Delay;


    public Sprite[] sprites;
    public int Health;
    public GameObject ItemGold;
    public GameObject Player;
    public ObjecManager objecManager;

    SpriteRenderer spriteRenderer;


    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Setup(SpiderSpawner spiderSpawner2,Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();
        spiderSpawner = spiderSpawner2;

        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;


        transform.position = wayPoints[currentIndex].position;

        StartCoroutine("OnMove");
    }

    private void Update()
    {
        //NextMoveTo();
    }
    void Delay()
    {
        Attack_Delay += Time.deltaTime;
    }

    public void OnHit(int Spider_Damage)
    {
        if (Health <= 0)
            return;

        Health -= Spider_Damage;
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);

        if (Health <= 0 )
        {
            playerManager playerCS = Player.GetComponent<playerManager>();
            int RandomGold = Random.Range(0, 10);
            if(RandomGold < 7)
            {
                GameObject ItemGold = objecManager.ManagerObject("ItemGold");
            }
            gameObject.SetActive(false);
        }
    }
    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }
    private IEnumerator OnMove()
    {
        while(true)
        {
            NextMoveTo();
            yield return null;
        }
        /*while (true)
        {
            NextMoveTo();
        }*/
    }

    private void NextMoveTo()
    {
        //wayPoints[1].position = GameObject.FindGameObjectWithTag("Player").transform.position;
        //Vector3 direction = (wayPoints[1].position - transform.position).normalized;
        //movement2D.MoveTo(direction);
        wayPoints[1].position = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (transform.position != wayPoints[1].position)
        {
            //transform.position = wayPoints[currentIndex].position;
            //transform.position = transform.position;
            //currentIndex++;
            //wayPoints[1].position = GameObject.FindGameObjectWithTag("Player").transform.position;
            //Debug.Log("WayPoints: " + wayPoints[1].position + "SpiderPoint: " + transform.position);

            Vector3 direction = (wayPoints[1].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
    }

    public void Ondie()
    {
        float my_Value = Random.Range(0,10);

        if (my_Value > 7)
        {
            GameObject clone = Instantiate(ItemGold, transform.position, Quaternion.identity);

            spiderSpawner.DestroySpider(this);
        }
        else { spiderSpawner.DestroySpider(this); }
    }
}
