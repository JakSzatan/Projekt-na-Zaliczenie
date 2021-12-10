using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateAttack : MonoBehaviour
{
    public Animator animator;
    public bool reload=true;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0)&& animator.GetCurrentAnimatorStateInfo(0).IsName("Rest")&&reload)
        {
            
            reload = false;
            Vector3 mousePositon = Input.mousePosition;
            mousePositon = Camera.main.ScreenToWorldPoint(mousePositon);

            if (GetComponent<SpawnBullet>().FireRate<1)
            {
                animator.speed = 1 / GetComponent<SpawnBullet>().FireRate;
            }
            else
            {
                animator.speed = 1;
            }

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
