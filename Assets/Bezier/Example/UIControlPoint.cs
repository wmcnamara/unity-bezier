using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class is not required to use the bezier library, it simply just allows you to easily move the prefab "UI control point" with the mouse.
*/
public class UIControlPoint : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = -1;
        transform.position = newPos;
    }
}
