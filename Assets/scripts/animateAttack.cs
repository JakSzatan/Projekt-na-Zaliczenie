using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateAttack : MonoBehaviour
{
    public Animator animator;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0)&& animator.GetCurrentAnimatorStateInfo(0).IsName("Rest"))
        {
            Vector3 mousePositon = Input.mousePosition;
            mousePositon = Camera.main.ScreenToWorldPoint(mousePositon);
            if (mousePositon.x > transform.position.x)
            {
                animator.Play("Attack", -1, 0f);
            }
            else
            {
                animator.Play("AttackReverse", -1, 0f);
            }
                
        }
    }
}
