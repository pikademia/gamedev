using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] UIHealthBar healthBar;
    [SerializeField] int maxHp = 1;
    int hp;

    void Start()
    {
        hp = maxHp;
        DisplayHP();
    }
    
    public void Damage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        DisplayHP();
    }

    void DisplayHP()
    {
        if(healthBar != null)
        {
            healthBar.DisplayHP((float)hp / maxHp);

        }
    }

}
