using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agrro : MonoBehaviour { 
       
    private Transform target;
    public float speed;
    public float agroRange;
    public bool isAgrro;
    public GameObject WaringSprite;
    Animator animator;
    SpriteRenderer SR;
    enemy enemyscript;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        enemyscript = GetComponent<enemy>();
        animator = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAgrro)
        {
            
            if (Vector3.Distance(transform.position, target.position) < agroRange||enemyscript.Health<5) //Agro range
            {   //move towards the player
                isAgrro = true;
                GetComponent<EnemyShoot>().isTrigerred=true;
                animator.SetFloat("Speed", 1f);
                //create a waring sprite
                var sign = Instantiate(WaringSprite, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                sign.transform.parent = gameObject.transform;
                Destroy(sign, 1);
            }
        }

        if (isAgrro)
        {
            //flip sprite
            if (transform.position.x > target.transform.position.x)
                SR.flipX = true;
            else            
                SR.flipX = false;

            //move
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void SetAgrro()
    {
        isAgrro = true;
        GetComponent<EnemyShoot>().isTrigerred=true;
        animator.SetFloat("Speed", 1f);
        //create a waring sprite
        var sign = Instantiate(WaringSprite, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        sign.transform.parent = gameObject.transform;
        Destroy(sign, 1);
    }
}
