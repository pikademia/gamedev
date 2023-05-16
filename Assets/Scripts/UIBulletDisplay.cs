using UnityEngine;
using UnityEngine.UI;

public class UIBulletDisplay : MonoBehaviour
{
    [SerializeField] Image imgMagAmmo;
    [SerializeField] Image imgTotalAmmo;
    
    public void DisplayBullets(int magAmount, int fillAmmo)
    {
        imgMagAmmo.fillAmount = magAmount / 50f;
        imgTotalAmmo.fillAmount = fillAmmo / 50f;
    }
}
