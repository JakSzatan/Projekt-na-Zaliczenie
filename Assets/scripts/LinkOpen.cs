using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkOpen : MonoBehaviour
{
    public string Link;
    public void OpenLink()
    {
        Application.OpenURL(Link);
    }
}
