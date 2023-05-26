using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[]enemyLst;
    void Start()
    {
        InvokeRepeating("Spawn", 2, 5);
    }

    void Update()
    {
        
    }

    void Spawn()
    {
        int enemyIndex = Random.Range(0, enemyLst.Length - 1);
        Instantiate(enemyLst[enemyIndex], Random.insideUnitSphere * 3, transform.rotation);
    }

    //public Vector3 RandomPos()

}
