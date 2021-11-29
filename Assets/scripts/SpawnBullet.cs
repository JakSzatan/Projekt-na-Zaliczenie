using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform weapon;
    public int FireRate = 5;
    private int reload=0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)&&reload<0)
        {
            reload = FireRate;
            Instantiate(bulletPrefab, weapon.transform.position, transform.rotation);
        }
        reload--;
    }
}
