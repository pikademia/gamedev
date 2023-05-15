using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHp = 1;
    int hp;

    void Start()
    {
        hp = maxHp;    
    }
    
    public void Damage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
