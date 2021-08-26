using System.Collections;
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
    private float attackRange = 2.0f;
    private WeaponState weaponState = WeaponState.SearchTarget;
    private Transform attackTarget = null;
    private SpiderSpawner spiderSpawner;    //게임에 존재하는 Spider 적 정보 획득

    public Transform Enemy_Dish_AttackPoint;
    public LayerMask PlayerLayers;
    //private Transform Cannontransform;
    //private Vector3 Cannon;
    //public GameObject Spider;
    //public float closetDistance = Mathf.Infinity;


    public void Setup(SpiderSpawner spiderSpawner)
    {
        this.spiderSpawner = spiderSpawner;
       
        //ChangeState(WeaponState.SearchTarget);
        StartCoroutine("Enemy_Dish_Attack_Ani");
    }

    private void Update()
    {
        //Enemy_Dish_Attack_Ani();
    }

    public IEnumerator Enemy_Dish_Attack_Ani() //공격 함수 
    {
        while (true)
        {
            Collider2D[] HitPlayers = Physics2D.OverlapCircleAll(Enemy_Dish_AttackPoint.position, attackRange, PlayerLayers); // Enemy Attack_Point쪽에 닿는 모든것들을 수집 

            foreach (Collider2D player in HitPlayers) // 모든 배열을 foreach로 돌림 
            {
                if (player.tag == "Spider") // 배열중 이름이 Player가 있으면 아래 실행 
                {
                    SpawnProjectile(player.transform);
                    break;
                }
            }
            yield return new WaitForSeconds(attackRate);

        }
    }

    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString()); //이전에 재생중이던 상태 종료
        weaponState = newState; //상태 변경
        StartCoroutine(weaponState.ToString());
        //Debug.Log(spiderSpawner.SpiderList.Count);
        //StartCoroutine("SearchTarget");
        //Debug.Log(weaponState.ToString());
    }

    private IEnumerator SearchTarget()
    {
        while (true)
        {
            float closestDistSqr = Mathf.Infinity; //제일 가까운 적을 찾기 위해 최초 거리를 최대한 크게 설정

            Debug.Log(spiderSpawner.SpiderList.Count);

            for (int i = 0; i < spiderSpawner.SpiderList.Count; ++i)
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

            //SpawnProjectile();
        }
    }

    private void SpawnProjectile(Transform attackTarget)
    {
        GameObject clone =  Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<ProjectTile>().Setup(attackTarget);
    }
}
