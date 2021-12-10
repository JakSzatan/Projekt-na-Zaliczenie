using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform weapon;
    public float FireRate = 5;
    public bool reload=true;
    public int BulletNumber=1;
    public float BulletDamage=1;
    public AudioSource AttackSound;
    void Update()
    {
        if (Input.GetMouseButton(0)&&reload)
        {
            AttackSound.Play();
            reload = false;
            StartCoroutine(Reload());
            var bull =Instantiate(bulletPrefab, weapon.transform.position, transform.rotation);
            bull.GetComponent<bullet>().damage = BulletDamage;
            //dodatkowe pociski
            for (int i = 1; i < BulletNumber; i++)
            {
                Instantiate(bulletPrefab, weapon.transform.position, transform.rotation);
                var bullet1 = Instantiate(bulletPrefab, weapon.transform.position, transform.rotation);
                bullet1.GetComponent<bullet>().damage = BulletDamage;
                bullet1.GetComponent<bullet>().xyoffset = (-i, i);
                var bullet2 = Instantiate(bulletPrefab, weapon.transform.position, transform.rotation);
                bullet2.GetComponent<bullet>().xyoffset = (i, -i);
                bullet2.GetComponent<bullet>().damage = BulletDamage;
            }
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(FireRate);
        reload = true;
        GetComponent<animateAttack>().reload = true;
    }
}
