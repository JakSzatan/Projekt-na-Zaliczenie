using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    SpawnBullet SB;
    public bool incFireRate;
    public bool incDmage;
    public bool incBulletNumer;

    void Start()
    {
        SB = GameObject.Find("Weapon").GetComponent<SpawnBullet>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (incFireRate)
                SB.FireRate -= 0.1f;

            if(incBulletNumer)
                SB.BulletNumber += 1;

            if (incDmage)
                SB.BulletDamage += 1;

            GameObject.Destroy(gameObject);
        }
    }
}
