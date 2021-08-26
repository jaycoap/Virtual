using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject SpiderPrefab;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private Transform[] wayPoints;
    private List<Spider> spiderList;


    public List<Spider> SpiderList => spiderList;

    private void Awake()
    {
        spiderList = new List<Spider>();
        StartCoroutine("SpawnSpider");
    }

    public IEnumerator SpawnSpider()
    {
        while(true)
        {
            GameObject clone = Instantiate(SpiderPrefab);
            Spider spider = clone.GetComponent<Spider>();

            spider.Setup(this, wayPoints);
            spiderList.Add(spider);
            //Debug.Log(SpiderList);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void DestroySpider(Spider spider)
    {
        spiderList.Remove(spider);
        Destroy(spider.gameObject);
    }
}
