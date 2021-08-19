using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject CanonObject;
    Camera Camera;
    private Testing testing;
    private Ray ray;
    private RaycastHit hit;
    Vector2 MousePosition;
    private bool checkPosition = false;
    private Vector2[] savePosition = new Vector2[100];
    int i = 0;
    Vector3 pos;

    private void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        
        pos = this.gameObject.transform.position;

        
    }
    void Update()
    {
        savePosition[i] = MousePosition;
        if (Input.GetMouseButtonDown(0))
        {

            if (CanonObject.transform.position == pos)
            {
                Debug.Log("설치불가");
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                MousePosition = Input.mousePosition;
                MousePosition = Camera.ScreenToWorldPoint(MousePosition);
                Instantiate(CanonObject, MousePosition, Quaternion.identity);
                i++;
                
            }
            
            
            
        }
    }


}
