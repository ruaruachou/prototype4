using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20;
    public GameObject focalPoint;
    public GameObject powerupIndicator;
    public GameObject powerupShotIndicator;
    public GameObject bulletPrefab;
    private Bullet bullet;

    public bool hasPowerup = false;
    public bool hasPowerupShot = false;
    private bool canShot = true;
    public float shotInterval = 1f;

    public float powerupForce = 20;
    public float powerDur = 20;

    private Rigidbody playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");

    }

    void Update()
    {
        float ver = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * moveSpeed * ver);
        powerupIndicator.gameObject.transform.position = transform.position;
        powerupShotIndicator.gameObject.transform.position = transform.position;

        if (hasPowerupShot && canShot)
        {
            Shot();
            StartCoroutine(ShotRoutine());
        }
    }

    //ע������trigger��collision��д��
    //Trigger��other,Collision��collision

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);

            StartCoroutine(PowerupCountdownRoutine());
        }

        if (other.name == "PowerupShot"||other.name== "PowerupShot(Clone)")
        {
            hasPowerupShot = true;
            Destroy(other.gameObject);
            powerupShotIndicator.gameObject.SetActive(true);


            StartCoroutine(PowerupShotCountdownRoutine());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //ע�⣺�����������Enemy��ǩ������ʱִ��if���
        //PowerupЧ��
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log(collision.gameObject.name);
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerupForce, ForceMode.Impulse);

        }

    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerDur);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    IEnumerator PowerupShotCountdownRoutine()
    {
        yield return new WaitForSeconds(powerDur);
        hasPowerupShot = false;
        powerupShotIndicator.gameObject.SetActive(false);
    }

    IEnumerator ShotRoutine()
    {
        canShot = false;
        yield return new WaitForSeconds(shotInterval);
        Shot();
        yield return new WaitForSeconds(shotInterval);
        Shot();
        yield return new WaitForSeconds(shotInterval);
        Shot();
        canShot = true;
    }
    void Shot()
    {
        List<Enemy> enemies = new List<Enemy>(FindObjectsOfType<Enemy>());

        // ���������б�Ϊÿ�����������ӵ�
        for (int i = 0; i < enemies.Count; i++)
        {
            Enemy enemy = enemies[i];

            // ʵ�����ӵ�Ԥ����
            GameObject bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet bullet = bulletObj.GetComponent<Bullet>();

            // �����ӵ���Ŀ�����
            bullet.targetEnemy = enemy;
        }
    }
}
