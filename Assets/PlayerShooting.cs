using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform aim;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 5f;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
        GameObject bullet = Instantiate(bulletPrefab, aim.position, aim.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        audioSource.Play();
    }
}
