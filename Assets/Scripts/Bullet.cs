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
    }

 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}

