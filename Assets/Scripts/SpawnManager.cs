using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //�������飺���ڴ�Ÿ��ֵ���
    public GameObject[] spawnList;
    //�������飺���鳤��Ϊ����������ÿ��Ԫ�ص�ֵΪ�������ɵ�����
    public int[] wave;
    public int enemyCount;//��ʾ��ǰʵʱ��������
    public int currentWave;//��¼��ǰ����

    void Start()
    {
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //iΪ����
        
            if (enemyCount == 0&& currentWave<wave.Length)
            {
                for (int i = 0; i < wave[currentWave]; i++)
                {
                    SpawnEnemy();  
                }
                currentWave++;
            }
        
    }

    //���ɵ���
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


