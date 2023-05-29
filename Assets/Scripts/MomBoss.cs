using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomBoss : MonoBehaviour
{
    public GameObject sonEnemy;

    void Start()
    {
        InvokeRepeating("Spawn", 3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        Instantiate(sonEnemy, transform.position+new Vector3(2,0,0), transform.rotation);
    }
}
