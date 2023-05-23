using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    int damage = 1;
    Transform parentHolder;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        parentHolder = transform.parent;
    }
    public void Init(Vector2 dir, int damage)
    {
        rb.velocity = dir;
        this.damage = damage;
    }
    void OnEnable()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        StartCoroutine(ReturnBulletToPool(2f));
    }

    IEnumerator ReturnBulletToPool(float time)
    {
        yield return new WaitForSeconds(time);
        transform.SetParent(parentHolder);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.Damage(damage);
        }
        StartCoroutine(ReturnBulletToPool(0.0f));
    }
}
