using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBullet : MonoBehaviour
{
    public float bulletSpeed;
    private int damage = 1;

    void Start()
    {
        Invoke("DestoryProjectile", 0.7f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        Destroy(gameObject);
    }

    void DestoryProjectile()
    {
        Destroy(gameObject);
    }
}
