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
        //i为波次
        for (int i = 0; i < wave.Length;)
        {
            Debug.Log("i"+i);
            //j为当前波次的敌人数量
            for (int j = 0; j < wave[i]; j++)
            {
                Debug.Log("j"+j);
                Spawn();
                if (enemyCount == 0)
                    i++;
            }
        }
    }

    //生成敌人
    void Spawn()
    {
        int enemyIndex = Random.Range(0, enemyLst.Length );

        Instantiate(enemyLst[enemyIndex], Random.insideUnitSphere * 3, transform.rotation);
    }
}


