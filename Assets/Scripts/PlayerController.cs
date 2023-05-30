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
    public GameObject PowerupSmashIndicator;
    private Bullet bullet;

    public bool hasPowerup = false;
    public bool hasPowerupShot = false;
    private bool canShot = true;
    public float shotInterval = 1f;
    public bool hasPowerupSmash = false;
    public float smashJumpForce = 10f;
    public bool isInAir = false;



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
        PowerupSmashIndicator.gameObject.transform.position = transform.position;

        if (hasPowerupShot && canShot)
        {
            Shot();
            StartCoroutine(ShotRoutine());
        }
        if (hasPowerupSmash)
        {
            Smash();

        }
    }

    //ע������trigger��collision��д��
    //Trigger��other,Collision��collision

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {//����Powerup
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);

            StartCoroutine(PowerupCountdownRoutine());
        }

        if (other.name == "PowerupShot" || other.name == "PowerupShot(Clone)")
        {//�������
            hasPowerupShot = true;
            Destroy(other.gameObject);
            powerupShotIndicator.gameObject.SetActive(true);

            StartCoroutine(PowerupShotCountdownRoutine());
        }
        if (other.name == "PowerupSmash" || other.name == "PowerupSmash(Clone)")
        {//����Smash
            hasPowerupSmash = true;
            Destroy(other.gameObject);
            PowerupSmashIndicator.gameObject.SetActive(true);

            StartCoroutine(SmashCountdownRoutine());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //ע�⣺�����������Enemy��ǩ������ʱִ��if���
        //PowerupЧ��
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            ForceAwayFromPlayer(collision.gameObject);
        }
        //SmashЧ��
        if (collision.gameObject.CompareTag("Ground") && hasPowerupSmash)
        {
            List<Enemy> enemies = new List<Enemy>(FindObjectsOfType<Enemy>());
            for (int i = 0; i < enemies.Count; i++)
            {
                ForceAwayFromPlayer(enemies[i].gameObject);
            }
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {//����Э��&ָʾ
        yield return new WaitForSeconds(powerDur);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    IEnumerator PowerupShotCountdownRoutine()
    //���ָʾ��Э��
    {
        yield return new WaitForSeconds(powerDur);
        hasPowerupShot = false;
        powerupShotIndicator.gameObject.SetActive(false);
    }

    IEnumerator ShotRoutine()
    //���Э��
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

    IEnumerator SmashCountdownRoutine()
    //Smashָʾ��Э��
    {
        yield return new WaitForSeconds(powerDur);
        hasPowerupSmash = false;
        PowerupSmashIndicator.gameObject.SetActive(false);
    }
    /*IEnumerator SmashRoutine()
    //SmashЭ��
    {
        canSmash = false;
        yield return new WaitForSeconds(shotInterval);
        Smash();
        yield return new WaitForSeconds(shotInterval);
        Smash();
        yield return new WaitForSeconds(shotInterval);
        Smash();
        canSmash = true;
    }*/

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
    void Smash()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && isInAir == false)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
            isInAir = true;
        }
  
        if (Input.GetKeyUp(KeyCode.Space) && isInAir)
        {
            playerRb.AddForce(Vector3.down * 300, ForceMode.Impulse);
            isInAir = false;
        }
    }

    void ForceAwayFromPlayer(GameObject collosionGameObj)
    {
        Debug.Log(collosionGameObj.name);
        Rigidbody enemyRb = collosionGameObj.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = collosionGameObj.transform.position - transform.position;
        enemyRb.AddForce(awayFromPlayer * powerupForce, ForceMode.Impulse);
    }
}
