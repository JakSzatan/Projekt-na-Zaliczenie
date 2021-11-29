using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public SpriteRenderer SR;

    private void Update()
    {
        Vector3 mousePositon = Input.mousePosition;
        mousePositon = Camera.main.ScreenToWorldPoint(mousePositon);
        Vector2 direction = new Vector2(mousePositon.x - transform.position.x, mousePositon.y - transform.position.y);
        transform.up = direction;

        if (mousePositon.x < transform.position.x)
        {
            SR.flipY = true;
        }
        else
        {
            SR.flipY = false;
        }
    }
}
