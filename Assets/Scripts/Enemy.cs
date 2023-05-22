using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform aim;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Collider2D triggerColider;

    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float shootDelay = 1f;

    private void OnEnable()
    {
        UIManager.Instance.UpdateEnemy(1);
    }

    private void OnDisable()
    {
        UIManager.Instance.UpdateEnemy(-1);
    }

    private void Awake()
    {

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, aim.position, aim.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("Shoot", 0f, shootDelay);
            triggerColider.enabled = false;
        }
    }
}
