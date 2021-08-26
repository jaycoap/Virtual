using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponState { SearchTarget = 0, AttackToTarget}

public class Cannon_Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float attackRate = 0.5f;
    [SerializeField]
    private float attackRange = 20.0f;
    private WeaponState weaponState = WeaponState.SearchTarget;
    private SpiderSpawner spiderSpawner;    //게임에 존재하는 Spider 적 정보 획득

    //private Transform Cannontransform;
    //private Vector3 Cannon;
    //public GameObject Spider;
    //public float closetDistance = Mathf.Infinity;


    public void Setup(SpiderSpawner spiderSpawner)
    {
        this.spiderSpawner = spiderSpawner;

        ChangeState(WeaponState.SearchTarget);
    }


    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString()); //이전에 재생중이던 상태 종료
        weaponState = newState; //상태 변경
        StartCoroutine(weaponState.ToString());
        Debug.Log(spiderSpawner.SpiderList.Count);
        //StartCoroutine("SearchTarget");
        //Debug.Log(weaponState.ToString());
    }

    private IEnumerator SearchTarget()
    {
        while (true)
        {
            //float closestDistSqr = Mathf.Infinity; //제일 가까운 적을 찾기 위해 최초 거리를 최대한 크게 설정

            Debug.Log(spiderSpawner.SpiderList.Count);
            yield return null;
        }
    }
            //Debug.Log(spiderSpawner.Spider_count);

            /*for (int i = 0; i < spiderSpawner.SpiderList.Count; ++i)
            {
                float distance = Vector3.Distance(spiderSpawner.SpiderList[i].transform.position, transform.position);

                if (distance <= attackRange && distance <= closestDistSqr)
                {
                    closestDistSqr = distance;
                    attackTarget = spiderSpawner.SpiderList[i].transform;
                }
            }

            if(attackTarget != null)
            {
                ChangeState(WeaponState.AttackToTarget);
            }

            yield return null;
        }
    }

    private IEnumerator AttackToTarget()
    {
        while(true)
        {
            if (attackTarget == null)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            float distance = Vector3.Distance(attackTarget.position, transform.position);

            if (distance > attackRange)
            {
                attackTarget = null;
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            yield return new WaitForSeconds(attackRate);

            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
    }*/
}
