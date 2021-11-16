using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject shootPoint;
    public GameObject shootPoint2;
    public GameObject shootPoint3;
    public bool isShotgun;
    

    public void Rotate(Vector2 input)
    {
        float angle = Mathf.Atan2(-input.x, input.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
