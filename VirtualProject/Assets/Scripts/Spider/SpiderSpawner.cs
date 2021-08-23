using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject SpiderPrefab;
    [SerializeField]
    private float SpawnTime;
    [SerializeField]
    private Transform[] wayPoints;
    private List<Spider> spiderList;

    public List<Spider> SpiderList => spiderList;

    private void Awake()
    {
        spiderList = new List<Spider>();
        StartCoroutine("SpawnSpider");
    }

    private IEnumerator SpawnSpider()
    {
        while(true)
        {
            GameObject clone = Instantiate(SpiderPrefab);
            Spider spider = clone.GetComponent<Spider>();

            spider.Setup(this,wayPoints);
            spiderList.Add(spider);
            yield return new WaitForSeconds(SpawnTime);
        }
    }

    public void DestroySpider(Spider spider)
    {
        spiderList.Remove(spider);
        Destroy(spider.gameObject);
    }
}
