using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemy : MonoBehaviour
{
    public float maxHP = 25;
    public float shootTimer = 5;
    //public EnemyShot shot;
    public float speed = 5;
    public float moveTimer = 3;

    //public 

    float HP;

    //You may consider adding a rigid body to the zombie for accurate physics simulation
    public GameObject wayPoint;
    public Vector2 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    public float enemyspeed = 6.0f;


    void Start()
    {
        HP = maxHP;
    }



    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (Time.timeScale != 0)
        {
            if (shootTimer <= 0)
            {
                Debug.Log("Timer less than zero");
                //Instantiate(shot, transform.position + new Vector3(1, 0), Quaternion.identity);
                StartCoroutine(ChargeAttack());
            }
            //Here, the zombie's will follow the waypoint.
        }




        if (HP <= 0)
        {
            System.Random rnd = new System.Random();
            int itemDropRate = rnd.Next(0, 50);
            if (itemDropRate > 25 && itemDropRate <= 35)
            {
                Powerup powerup = Instantiate(Game.Instance.biggerBullet);
                powerup.wimzard = Game.Instance.player;
                powerup.transform.localPosition = transform.localPosition;
            }
            else if (itemDropRate > 35 && itemDropRate <= 45)
            {
                Powerup powerup = Instantiate(Game.Instance.fastFire);
                powerup.wimzard = Game.Instance.player;
                powerup.transform.localPosition = transform.localPosition;
            }
            else if (itemDropRate > 45 && itemDropRate <= 50)
            {
                Powerup powerup = Instantiate(Game.Instance.marioStarRipoff);
                powerup.wimzard = Game.Instance.player;
                powerup.transform.localPosition = transform.localPosition;
            }
            Game.Instance.score += 10;
            Destroy(gameObject);
        }

    }

    IEnumerator ChargeAttack()
    {
        Debug.Log("Commence Charge");
        wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, wayPointPos, enemyspeed * Time.deltaTime);
        yield return new WaitForSeconds(2f);
        shootTimer = 5;
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
