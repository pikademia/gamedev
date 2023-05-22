using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform aim;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int bulletSpeed = 10;
    [SerializeField] int bulletDamage = 1;
    GunAnimator gunAnimator;
    GunSound gunSound;

    private void Awake()
    {
        gunAnimator = GetComponent<GunAnimator>();
        gunSound = GetComponent<GunSound>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            gunAnimator.SetAnimation("shoot");
            PlaySound(0);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Reload();
            gunAnimator.SetAnimation("reload");
            PlaySound(1);
        }
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, aim.position, aim.rotation);
        bullet.GetComponent<Bullet>().Init(transform.right * bulletSpeed, bulletDamage);
    }

    void Reload()
    {
        //
    }

    void PlaySound(int soundIndex)
    {
        gunSound.PlayGunSound(soundIndex);
    }

}
