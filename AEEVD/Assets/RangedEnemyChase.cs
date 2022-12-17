using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyChase : MonoBehaviour
{
    
    public GameObject EnemyBullet;
    public Transform player;
    public Transform rangedFirePoint;
    public Transform enemyWeapon;

    public float speed;
    private bool inRange;
    public float attackRange;
    public float cdTime;
    private float atkCD;
  
    void Update()
    {
        Vector3 difference = player.position - enemyWeapon.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        enemyWeapon.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if(Vector2.Distance(transform.position, player.position) > attackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if(Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            if(atkCD <= 0)
            {
                Instantiate(EnemyBullet, rangedFirePoint.position, rangedFirePoint.transform.rotation);
                atkCD = cdTime;
            }
            else
            {
                atkCD -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        if(inRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
