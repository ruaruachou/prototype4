using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //敌人数组：用于存放各种敌人
    public GameObject[] levelSpawn1;
    public GameObject[] levelSpawn2;
    //波次数组：数组长度为波次数量，每个元素的值为本波生成的数量
    public int[] wave;
    public int enemyCount;//显示当前实时敌人数量
    public int currentWave;//记录当前波次

    //随机生成范围
    public float spawnRangeX = 8;

    void Start()
    {
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //i为波次

        if (enemyCount == 0)
        {
            switch (currentWave)
            {
                case 0:
                    SpawnEnemy(levelSpawn1);
                    currentWave++;
                    break;
                case 1:
                    SpawnEnemy(levelSpawn2);
                    currentWave++;
                    break;
            }
        }
    }

    //生成敌人
    void SpawnEnemy(GameObject[] currentLevelSpawn)
    {
        Debug.Log("SpawnEnemy");
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeX, spawnRangeX));
        for (int i = 0; i < currentLevelSpawn.Length; i++)
        {
            Instantiate(currentLevelSpawn[i],spawnPos , transform.rotation);
        }

    }
}


