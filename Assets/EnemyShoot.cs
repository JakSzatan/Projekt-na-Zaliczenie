using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int FireRate = 120;
    private int reload = 0;
    public bool isTrigerred=false;
    // Update is called once per frame
    void Update()
    {
        if (reload < 0&& isTrigerred)
        {
            reload = FireRate;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        reload--;
    }
}
