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
    public GameObject[] levelSpawn3;
    //波次数组：数组长度为波次数量，每个元素的值为本波生成的数量
    public int[] wave;
    public int enemyCount;//显示当前实时敌人数量
    public int currentWave;//记录当前波次

    //随机生成范围
    public float spawnRangeX = 8;

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
                case 2:
                    SpawnEnemy(levelSpawn3);
                    currentWave++;
                    break;
            }
        }
    }

    //根据数组元素生成敌人或Powerup
    void SpawnEnemy(GameObject[] currentLevelSpawn)
    {
        Debug.Log("SpawnEnemy");
        
        for (int i = 0; i < currentLevelSpawn.Length; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeX, spawnRangeX));
            Instantiate(currentLevelSpawn[i],spawnPos , transform.rotation);
        }
    }
}


