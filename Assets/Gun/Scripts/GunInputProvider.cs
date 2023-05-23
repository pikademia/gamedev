using UnityEngine;

public class GunInputProvider : MonoBehaviour
{
    public bool Shoot()
    {
        bool canExecute = Input.GetButtonDown("Fire1");
        return canExecute;
    }

    public bool Reload()
    {
        bool canExecute = Input.GetButtonDown("Fire2");
        return canExecute;
    }

    public bool ChangeGun()
    {
        bool canExecute = Input.GetButtonDown("Fire3");
        return canExecute;
    }

}
