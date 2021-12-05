using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject shootPoint;
    public GameObject shootPoint2;
    public GameObject shootPoint3;
    public WeaponType weaponType;
    public bool rotateAttack;
    public Quaternion originalRotation;
    public int damage;

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    public void Update()
    {
        if(rotateAttack)
        {
            transform.Rotate(Vector3.back * (250 * Time.deltaTime));
            if(transform.rotation == originalRotation)
            {
                rotateAttack = false;
                tag = "Untagged";
            }
        }
    }

    public void Rotate(Vector2 input)
    {
        if(weaponType != WeaponType.Sword)
        {
            float angle = Mathf.Atan2(-input.x, input.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }
}

public enum WeaponType
{ 
    None,
    Staff,
    Shotgun,
    Pistol,
    Sword
}