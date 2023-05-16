using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBulletDisplay : MonoBehaviour
{
    [SerializeField] Image imgTotalAmmo;
    
    public void DisplayBullets(int fillAmmo)
    {
        imgTotalAmmo.fillAmount = fillAmmo / 50f;
    }
}
