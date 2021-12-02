using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP;
    public float shootTimer;
    public float prevShoottimer;
    public EnemyShot shot;
    public float speed;
    public float moveTimer;

    public Vector2 targetTransform;

    //public 

    float HP;

    //You may consider adding a rigid body to the zombie for accurate physics simulation
    public GameObject wayPoint;
    public  Vector2 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    public float enemyspeed = 6.0f;


    void Start()
    {

        HP = maxHP;
    }

    void Update()
    {
        if(Time.timeScale != 0)
        {
            wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
            //Here, the zombie's will follow the waypoint.
            transform.position = Vector2.MoveTowards(transform.position, wayPointPos, enemyspeed * Time.deltaTime);
        }


        shootTimer -= Time.deltaTime;


        if(shootTimer <= 0)
        {
            targetTransform = wayPoint.transform.position;
            
            if(shot != null)
            {
                Instantiate(shot, transform.position, Quaternion.identity);
            }
            
           
            shootTimer = prevShoottimer;
        }


        if(HP <= 0)
        {
            System.Random rnd = new System.Random();
            int itemDropRate = rnd.Next(0, 50);
            if(itemDropRate > 25 && itemDropRate <= 35)
            {
                Powerup powerup = Instantiate(Game.Instance.biggerBullet);
                powerup.wimzard = Game.Instance.player;
                powerup.transform.localPosition = transform.localPosition;
            }
            else if(itemDropRate > 35 && itemDropRate <= 45)
            {
                Powerup powerup = Instantiate(Game.Instance.fastFire);
                powerup.wimzard = Game.Instance.player;
                powerup.transform.localPosition = transform.localPosition;
            }
            else if(itemDropRate > 45 && itemDropRate <= 50)
            {
                Powerup powerup = Instantiate(Game.Instance.marioStarRipoff);
                powerup.wimzard = Game.Instance.player;
                powerup.transform.localPosition = transform.localPosition;
            }
            Game.Instance.score += 10;
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Shot")
        {
            HP -= Player.Instance.weapon.damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Shot")
        {
            HP -= Player.Instance.weapon.damage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            HP -= Player.Instance.weapon.damage;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            HP -= Player.Instance.weapon.damage;
        }
    }


}
