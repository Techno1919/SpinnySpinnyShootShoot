using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float speed = 2;
    public float lifetime = 1;

    public List<Vector3> transforms;

    void Start()
    {
        Destroy(gameObject, lifetime);
        transforms.Add(transform.up);
        transforms.Add(transform.right);
        transforms.Add(transform.forward);
    }

    private void Update()
    {
        Vector3 vec3 = transforms[Random.Range(0, 3)];
        transform.Translate(vec3 * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
