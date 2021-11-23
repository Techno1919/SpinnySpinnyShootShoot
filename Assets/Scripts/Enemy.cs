using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 25;
    public float shootTimer = 5;
    public EnemyShot shot;
    public float speed = 2;
    public float moveTimer = 3;

    //public 

    float HP;

    void Start()
    {
        HP = maxHP;
    }

    void Update()
    {

        shootTimer -= Time.deltaTime;

        if(shootTimer <= 0)
        {
            Instantiate(shot, transform.position + new Vector3(1, 0), Quaternion.identity);
            shootTimer = 5;
        }

        if(HP <= 0)
        {
            System.Random rnd = new System.Random();
            int itemDropRate = rnd.Next(0, 50);
            if(itemDropRate > 25 && itemDropRate <= 35)
            {
                Powerup powerup = Instantiate(Game.Instance.biggerBullet);
                powerup.wimzard = Game.Instance.player;
            }
            else if(itemDropRate > 35 && itemDropRate <= 45)
            {
                Powerup powerup = Instantiate(Game.Instance.fastFire);
                powerup.wimzard = Game.Instance.player;
            }
            else if(itemDropRate > 45 && itemDropRate <= 50)
            {
                Powerup powerup = Instantiate(Game.Instance.marioStarRipoff);
                powerup.wimzard = Game.Instance.player;
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
