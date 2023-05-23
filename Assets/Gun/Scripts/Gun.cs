using System.Collections.Generic;
using UnityEngine;


public abstract class Gun : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform aim;
    Animator animator;
    GunSound gunSound;

    abstract public int bulletSpeed { get; set; } // in m/s
    abstract public int bulletEnergy { get; set; } //in joules
    abstract public int magCap { get; set; }
    public int bulletsInMag { get; set; }

    List<GameObject> ammoPool = new List<GameObject>();
    GameObject bullet;

    private void Awake() 
    {
        gunSound = GetComponent<GunSound>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        bulletsInMag = magCap;
        CreateBulletPool();
    }

    public void Shoot()
    {
        if (bulletsInMag == 0) return;

        bullet = GetPooledBullet();
        bullet.SetActive(true);
        bullet.transform.SetParent(null);
        bullet.transform.position = aim.position;
        bullet.transform.localRotation = aim.rotation;
        bullet.GetComponent<Bullet>().Init(bullet.transform.right * Mathf.RoundToInt(bulletSpeed/ 20.0f), Mathf.RoundToInt(bulletEnergy/100.0f));
        SetAnimationTrigger("shoot");
        PlaySound(0);
        bulletsInMag--;
        Debug.Log(bulletsInMag);
    }

    public int Reload(int ammoTotal)
    {
        if (ammoTotal == 0) return 0;

        int ammoToReload;
        int ammoNeeded = magCap - bulletsInMag;
        if (ammoNeeded >= ammoTotal)
        {
            ammoToReload = ammoTotal;
        }
        else
        {
            ammoToReload = ammoNeeded;
        }
        bulletsInMag += ammoToReload;
        SetAnimationTrigger("reload");
        PlaySound(1);
        return ammoToReload;
    }

    public void PlaySound(int soundIndex)
    {  
        gunSound.PlayGunSound(soundIndex);
    }

    public void SetAnimationTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }


    public bool IsReloadOrChangeAnimPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("GunReload") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("GunChange");
    }

    void CreateBulletPool()
    {
        for (int i = 0; i < magCap; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, aim);
            bullet.SetActive(false);
            ammoPool.Add(bullet);
        }    
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < ammoPool.Count; i++)
        {
            if (!ammoPool[i].activeInHierarchy)
            {
                return ammoPool[i];
            }
        }
        return null;
    }
}


