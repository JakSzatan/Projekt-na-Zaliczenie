using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParalax : MonoBehaviour
{
    RectTransform rt;
    bool moveup=false;
    public float ScrollRate;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rt.localPosition.y > 228)
        {
            moveup = true;
        }
        if (rt.localPosition.y < -228)
        {
            moveup = false;
        }

        if (moveup)
        {
            rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y + (-ScrollRate * Time.deltaTime), rt.localPosition.z);
        }
        else
        {
            rt.localPosition = new Vector3(rt.localPosition.x, rt.localPosition.y + (ScrollRate * Time.deltaTime), rt.localPosition.z);
        }
        

    }
}
