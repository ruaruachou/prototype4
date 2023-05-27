using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //敌人数组：用于存放各种敌人
    public GameObject[] spawnList;
    //波次数组：数组长度为波次数量，每个元素的值为本波生成的数量
    public int[] wave;
    public int enemyCount;//显示当前实时敌人数量
    public int currentWave;//记录当前波次

    void Start()
    {
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //i为波次
        
            if (enemyCount == 0&& currentWave<wave.Length)
            {
                for (int i = 0; i < wave[currentWave]; i++)
                {
                    SpawnEnemy();  
                }
                currentWave++;
            }
        
    }

    //生成敌人
    void SpawnEnemy()
    {
        Debug.Log("SpawnEnemy");
        int enemyIndex = Random.Range(0, spawnList.Length );

         Instantiate(spawnList[enemyIndex], Random.insideUnitSphere * 3, transform.rotation);
    }

    void SpawnPowerup()
    {

    }
}


