using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private SpiderSpawner spiderSpawner;
    [SerializeField]
    private GameObject towerPrefab;

    void Start()
    {
        //GameObject clone = Instantiate(towerPrefab, transform.position, Quaternion.identity);
        GetComponent<Cannon_Weapon>().Setup(spiderSpawner);
        //clone.GetComponent<Cannon_Weapon>().Setup(spiderSpawner);
        Debug.Log(spiderSpawner.transform);
    }

 
}
