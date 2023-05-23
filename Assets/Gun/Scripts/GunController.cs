using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [field:SerializeField]
    public int AmmoTotal { get; set; } = 40;
    GunInputProvider inputProvider;
    Gun[] guns;

    int activeGunIndex = 0;

    private void Awake()
    {
        inputProvider = GetComponent<GunInputProvider>();   
    }

    void Start()
    {
        guns = GetComponentsInChildren<Gun>(true);

        foreach (Gun gun in guns)
        {
            gun.gameObject.SetActive(false);
        }
        guns[activeGunIndex].gameObject.SetActive(true);
    }


    private void Update()
    {
        if (guns[activeGunIndex].IsReloadOrChangeAnimPlaying()) return;

        if (inputProvider.Shoot())
        {
            guns[activeGunIndex].Shoot();
        }

        if (inputProvider.Reload())
        {
            AmmoTotal -= guns[activeGunIndex].Reload(AmmoTotal);
        }

        if (inputProvider.ChangeGun())
        {
            ChangeGun();
        }
    }

    void ChangeGun()
    {
        guns[activeGunIndex].gameObject.SetActive(false);
        if(activeGunIndex < guns.Length - 1) { 
            activeGunIndex++;
        }
        else
        {
            activeGunIndex = 0;
        }
        guns[activeGunIndex].gameObject.SetActive(true);
    }


}
