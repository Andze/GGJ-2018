using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPosition : MonoBehaviour
{
    Vector3 mousePos;
    public Vector3 MousePos
    {
        get { return mousePos; }
    }
    float angle;
    public float Angle
    {
        get { return angle; }
    }

	void Update ()
    {
        CalculateRotation();
        transform.localRotation = Quaternion.Euler(Vector3.forward * angle);
	}

    void CalculateRotation()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 0f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        angle = ((Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg) - (1.5f * Mathf.Rad2Deg));
    }
}
