using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int FireRate = 2;
    private bool reload = true;
    public bool isTrigerred=false;
    // Update is called once per frame
    void Update()
    {
        if (reload && isTrigerred)
        {
            reload = false;
            StartCoroutine(Reload());
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(FireRate);
        reload = true;
    }
}
