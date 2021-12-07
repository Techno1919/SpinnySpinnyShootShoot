using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float speed = 2;
    public float lifetime = 1;
    public Vector2 targetPos;

    public List<Vector3> transforms;

    void Start()
    {

        FindPostion();
        lifetime = 5;
        //Destroy(gameObject, lifetime);
        //transforms.Add(transform.up);
        //transforms.Add(transform.right);
        //transforms.Add(transform.forward);
    }

    private void Update()
    {
        
        MoveToPlayer(targetPos);

        lifetime -= Time.deltaTime;
        if(lifetime <0)
        {
            Destroy(gameObject);
        }

        //Vector3 vec3 = transforms[Random.Range(0, 3)];
        //transform.Translate(vec3 * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


    public void MoveToPlayer(Vector2 playerPrevPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPrevPosition * 100, speed * Time.deltaTime);
    }

    public void FindPostion()
    {
        Debug.Log("Position Found");
        targetPos = FindObjectOfType<Player>().transform.position;
    }
}
