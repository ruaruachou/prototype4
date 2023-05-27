using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //敌人数组：用于存放各种敌人
    public GameObject[] enemyLst;
    //波次数组：数组长度为波次数量，每个元素的值为本波生成的数量
    public int[] wave;

    public int enemyCount;//显示当前实时敌人数量

    void Start()
    {

    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        for (int i = 0; i < wave.Length; )
        {
                for (int j = 0; j < 5; j++)
                {
                    Spawn();
                if (enemyCount == 0)
                    i++;
                }
        }
    }

    void Spawn()
    {
        int enemyIndex = Random.Range(0, enemyLst.Length - 1);

        Instantiate(enemyLst[enemyIndex], Random.insideUnitSphere * 3, transform.rotation);
    }
}


