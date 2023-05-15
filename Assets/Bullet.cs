using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int attack = 1;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(attack);
        }
        Destroy(gameObject);
    }
}
