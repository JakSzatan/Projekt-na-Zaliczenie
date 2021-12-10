using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10;
    public float damage = 1;
    public float knockbackForce = 10;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        direction = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 0).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        DestroyObject(gameObject, 2);
    }
}
