using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20;
    public GameObject focalPoint;
    public GameObject powerupIndicator;
    public bool hasPowerup = false;
    public float powerupForce = 20;
    public float powerDur = 7;

    private Rigidbody playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        //powerupIndicator = GameObject.Find("PowerupIndicator");
    }

    void Update()
    {
        float ver = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * moveSpeed * ver);
        powerupIndicator.gameObject.transform.position = transform.position;
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
    }
    private void OnCollisionEnter(Collision collision)
    {
        //ע�⣺���ﾡ������Enemy��ǩ������ʱִ��if���
        if (collision.gameObject.CompareTag("Enemy")&&hasPowerup)
        {
            Debug.Log(collision.gameObject.name);
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerupForce,ForceMode.Impulse);

        }

    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerDur);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
