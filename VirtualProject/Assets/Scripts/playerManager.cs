using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Vector3 mousePos, mousePosTrans, moveTargetPos;
    float sprAngle;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            CalMoveTagetPos();

            sprAngle = Mathf.Atan2(mousePosTrans.y - transform.position.y, mousePosTrans.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(sprAngle - 90, Vector3.forward);
        }

        MoveToTarget();     //마우스 클릭 위치로 이동
    }

    void CalMoveTagetPos()
    {
        mousePos = Input.mousePosition;
        mousePosTrans = Camera.main.ScreenToWorldPoint(mousePos);
        moveTargetPos = new Vector3(mousePosTrans.x, mousePosTrans.y, 0);
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTargetPos, Time.deltaTime * speed);
    }
}
