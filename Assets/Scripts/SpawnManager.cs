using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //�������飺���ڴ�Ÿ��ֵ���
    public GameObject[] levelSpawn1;
    public GameObject[] levelSpawn2;
    //�������飺���鳤��Ϊ����������ÿ��Ԫ�ص�ֵΪ�������ɵ�����
    public int[] wave;
    public int enemyCount;//��ʾ��ǰʵʱ��������
    public int currentWave;//��¼��ǰ����

    //������ɷ�Χ
    public float spawnRangeX = 8;

    void Start()
    {
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //iΪ����

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

    //���ɵ���
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


