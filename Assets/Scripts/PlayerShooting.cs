using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] UIBulletDisplay uIBulletDisplay;

    [SerializeField] Transform aim;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] int ammoTotal = 60;
    [SerializeField] int magCap = 10;

    AudioSource audioSource;

    int magTemp;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        magTemp = magCap;
        DisplayAmmoInfo();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Reload();
        }
    }

    void Shoot()
    {
        if(magTemp > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, aim.position, aim.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            audioSource.Play();
            magTemp--;
            DisplayAmmoInfo();
        }
    }

    void Reload()
    {
        int reloadAmount = magCap - magTemp;
        if(reloadAmount <= ammoTotal)
        {
            magTemp += reloadAmount;
            ammoTotal -= reloadAmount;
        }
        else
        {
            magTemp += ammoTotal;
            ammoTotal = 0;
        }
        DisplayAmmoInfo();
    }

    void DisplayAmmoInfo()
    {
        uIBulletDisplay.DisplayBullets(magTemp, ammoTotal);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AmmoCollect ammoCollect = collision.gameObject.GetComponent<AmmoCollect>();
        if(ammoCollect != null)
        {
            ammoTotal += ammoCollect.Collect();
            DisplayAmmoInfo();
            Destroy(collision.gameObject);
        }
    }
}
