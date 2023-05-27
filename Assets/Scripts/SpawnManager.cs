using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //�������飺���ڴ�Ÿ��ֵ���
    public GameObject[] enemyLst;
    //�������飺���鳤��Ϊ����������ÿ��Ԫ�ص�ֵΪ�������ɵ�����
    public int[] wave;

    public int enemyCount;//��ʾ��ǰʵʱ��������

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


