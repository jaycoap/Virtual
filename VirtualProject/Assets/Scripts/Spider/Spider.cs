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

    public void Setup(SpiderSpawner spiderSpawner, Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();
        this.spiderSpawner = spiderSpawner;

        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        transform.position = wayPoints[currentIndex].position;

        //StartCoroutine("OnMove");
    }

    private void Update()
    {
        NextMoveTo();
    }
    private IEnumerator OnMove()
    {
         NextMoveTo();

        while(true)
        {
            //transform.Rotate(Vector3.forward * 10);
            //wayPoints[1].position = GameObject.FindGameObjectWithTag("Player").transform.position;
            if (Vector3.Distance(transform.position, wayPoints[1].position) < 0.02f * movement2D.MoveSpeed)
            {
                NextMoveTo();
            }
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
        else
        {
            Ondie();
        }
    }

    public void Ondie()
    {
        spiderSpawner.DestroySpider(this);
    }
}
