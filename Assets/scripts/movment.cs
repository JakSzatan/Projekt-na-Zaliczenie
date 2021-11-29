using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    Rigidbody2D body;
    SpriteRenderer SR;
    public Animator animator;
    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 mousePositon = Input.mousePosition;
        mousePositon = Camera.main.ScreenToWorldPoint(mousePositon);
 
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        //body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        if (!GetComponent<PlayerColisions>().isInvincible)
            transform.Translate(horizontal * runSpeed * Time.deltaTime, vertical * runSpeed * Time.deltaTime, 0);

        //Sprite and animations
        if (mousePositon.x < transform.position.x)
            SR.flipX = true;
        else
            SR.flipX = false;

        if (horizontal != 0 || vertical != 0)
            animator.SetFloat("Speed", 1f);
        else
            animator.SetFloat("Speed", 0f);

    }

}
