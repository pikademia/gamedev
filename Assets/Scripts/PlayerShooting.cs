using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] UIBulletDisplay uIBulletDisplay;

    [SerializeField] Transform aim;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] int ammoTotal = 10;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        uIBulletDisplay.DisplayBullets(ammoTotal);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(ammoTotal > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, aim.position, aim.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            audioSource.Play();
            ammoTotal--;
            uIBulletDisplay.DisplayBullets(ammoTotal);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AmmoCollect ammoCollect = collision.gameObject.GetComponent<AmmoCollect>();
        if(ammoCollect != null)
        {
            ammoTotal += ammoCollect.Collect();
            uIBulletDisplay.DisplayBullets(ammoTotal);
        }
        Destroy(collision.gameObject);
    }
}
