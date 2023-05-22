using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 1;

    public void Init(Vector2 dir, int damage)
    {
        GetComponent<Rigidbody2D>().velocity = dir;
        this.damage = damage;
    }
    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.Damage(damage);
        }
        Destroy(gameObject);
    }
}
