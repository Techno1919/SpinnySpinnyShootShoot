using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class MiniBoss : MonoBehaviour
{
    public float maxHP = 175;
    public GameObject eyeLazer;
    public GameObject spike1;
    public GameObject spike2;
    public GameObject spike3;
    public GameObject SpikeProjectile;
    public GameObject EyeLazer;
    float timer = 3;
    SkeletonAnimation sa;
    float HP;
    int shotNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        shotNum = 0;
        HP = maxHP;
        sa = GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && shotNum < 4)
        {
            Debug.Log("fire!");
            fireSpikes();
            timer = 5;
            shotNum++;
        }else if(timer < 0 && shotNum >= 4)
        {
            fireLazer();
            shotNum = 0;
            timer = 15;
        }
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void fireLazer()
    {
        for(int i = 0; i < 75; i++)
        {
            Instantiate(EyeLazer, eyeLazer.transform);
        }
    }

    public void fireSpikes()
    {
        Instantiate(SpikeProjectile, spike1.transform);
        Instantiate(SpikeProjectile, spike2.transform);
        Instantiate(SpikeProjectile, spike3.transform);
    }
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Shot")
        {
            HP -= 25;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Shot")
        {
            HP -= 25;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            HP -= 25;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            HP -= 25;
            Destroy(collision.gameObject);
        }
    }
}
