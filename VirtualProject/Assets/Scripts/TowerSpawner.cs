using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;



public class TowerSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject CannonObject;
    Camera Maincamera;
    [SerializeField]
    private SpiderSpawner spiderSpawner; 

    Ray2D ray;
    RaycastHit2D rayhit;
    public Vector2 pos;

    void Start()
    {
         
        Maincamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        BulidCannon();
    }

    public void BulidCannon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject() == false)
            {
                pos = Maincamera.ScreenToWorldPoint(Input.mousePosition);
                ray = new Ray2D(pos, Vector2.zero);
                rayhit = Physics2D.Raycast(ray.origin, ray.direction);

                if (rayhit.transform.CompareTag("TileManager"))
                {
                    GameObject clone = Instantiate(CannonObject, pos, Quaternion.identity);
                    //GameObject clone = Instantiate(CannonObject, pos, Quaternion.identity);
                    clone.GetComponent<Cannon_Weapon>().Setup(spiderSpawner);
                    
                }
                else if (rayhit.collider)
                {
                    return;
                }
            }
            
           
            
        }
    }
    


}
