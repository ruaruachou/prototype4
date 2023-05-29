using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Enemy targetEnemy;

    void Update()
    {
        if (targetEnemy != null)
        {
            Vector3 dir = (targetEnemy.transform.position - transform.position);
            transform.Translate(dir * 10 * Time.deltaTime);
        }
        else if (targetEnemy == null) { Destroy(gameObject); }
    }

 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromBullet = (collision.transform.position - transform.position);
            enemyRb.AddForce(awayFromBullet * 50, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}

