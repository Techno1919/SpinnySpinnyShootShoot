using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public Rigidbody2D rb = new Rigidbody2D();
    public float fireSpeed = 2000;
    public float deathSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 nyoom = new Vector2(fireSpeed, 0);
        rb.AddForce(nyoom);
        Destroy(gameObject, deathSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("EnemyShot"))
        {
            Destroy(gameObject);
        }
    }
}
