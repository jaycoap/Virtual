using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjecManager : MonoBehaviour
{
    public GameObject Enemy_Spider_Prefeb;
    public GameObject Item_Coin_Prefab;
    public GameObject Player_Bullet_Prefeb;
    public Text Gold_Text;

    GameObject[] Player_Bullet;
    GameObject[] Enemy_Spider;
    GameObject[] Item_Coin;
    GameObject[] TargetPool;
    void Awake() // 한번에 등장할 개수를 배열 길이로 할당
    {
        Enemy_Spider = new GameObject[10];
        Item_Coin = new GameObject[10];
        Player_Bullet = new GameObject[100];

        Generate();
    }

    void Generate()
    {
        for (int index = 0; index < Enemy_Spider.Length; index++)
        {
            Enemy_Spider[index] = Instantiate(Enemy_Spider_Prefeb);
            Enemy_Spider[index].SetActive(false);
        }
        for (int index = 0; index <Item_Coin.Length; index++)
        {
            Item_Coin[index] = Instantiate(Item_Coin_Prefab);
            Item_Coin[index].SetActive(false);
        }
        for (int index = 0; index < Player_Bullet.Length; index++)
        {
            Player_Bullet[index] = Instantiate(Player_Bullet_Prefeb);
            Player_Bullet[index].SetActive(false);

        }
    }
    public GameObject ManagerObject(string type)
    {
        switch(type)
        {
            case "Enemy_Spider":
                TargetPool = Enemy_Spider;
                break;
            case "Player_Bullet":
                TargetPool = Player_Bullet;
                break;
            case "Item_Coin":
                TargetPool = Item_Coin;
                break;

        }
        for (int index = 0; index < TargetPool.Length; index++)
        {
            if (!TargetPool[index].activeSelf)
            {
                TargetPool[index].SetActive(true);
                return TargetPool[index];
            }
        }
        return null;
    }
    
}
