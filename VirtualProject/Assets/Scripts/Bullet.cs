using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Hit_Damage;
    public float speed;
    public float lifetime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BorderBullet")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Spider")
        {
            collision.GetComponent<Spider>().Ondie();
            Destroy(gameObject);
        }

        //if (!collision.CompareTag("Spider")) return;
        //if (collision.transform != target) return;

        
    }
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
