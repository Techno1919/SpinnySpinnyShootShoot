using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Enemy : MonoBehaviour
{
    public float maxHP;
    public float shootTimer;
    public float prevShoottimer;
    public EnemyShot shot;
    public float speed;
    public float moveTimer;
    public bool chasePlayer;

    public Vector2 targetTransform;

    float HP;

    //You may consider adding a rigid body to the zombie for accurate physics simulation
    public GameObject wayPoint;
    public  Vector2 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    public float enemyspeed = 6.0f;

    public MeshRenderer meshRenderer;
    SkeletonAnimation sa;


    void Start()
    {
        HP = maxHP;
        sa = GetComponent<SkeletonAnimation>();
        meshRenderer = GetComponent<MeshRenderer>();
        targetTransform = Game.Instance.player.transform.position;
    }

    void Update()
    {
        if(Time.timeScale != 0)
        {
            wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
            //Here, the zombie's will follow the waypoint.
            if(chasePlayer)
            {
                transform.position = Vector2.MoveTowards(transform.position, wayPointPos, enemyspeed * Time.deltaTime);
            }

        }

        if(chasePlayer)
        {
            shootTimer -= Time.deltaTime;


            if (shootTimer <= 0)
            {
                targetTransform = wayPoint.transform.position;

                if (shot != null)
                {
                    EnemyShot spawnedShot = Instantiate(shot, transform.position, Quaternion.identity);
                    spawnedShot.transform.position = transform.position = Vector2.MoveTowards(transform.position, targetTransform * 100, speed * Time.deltaTime);
                }


                shootTimer = prevShoottimer;
            }
        }

        if(HP <= 0)
        {
            
            StartCoroutine(EnemyDies());
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Shot")
        {

            StartCoroutine(FlashEffect());

            HP -= Player.Instance.weapon.damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Shot")
        {
            StartCoroutine(FlashEffect());

            HP -= Player.Instance.weapon.damage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            chasePlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            chasePlayer = false;
        }
    }

    IEnumerator EnemyDies()
    {
        speed = 0;
        enemyspeed = 0;
        sa.AnimationName = "Dead";
        yield return new WaitForSeconds(1.2f);
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

    IEnumerator FlashEffect()
    {
        meshRenderer.enabled = false;

        yield return new WaitForSeconds(.05f);

        meshRenderer.enabled = true;

        yield return new WaitForSeconds(.05f);

        meshRenderer.enabled = false;

        yield return new WaitForSeconds(.05f);

        meshRenderer.enabled = true;

        yield return new WaitForSeconds(.05f);

        meshRenderer.enabled = true;

        yield return new WaitForSeconds(.05f);

        meshRenderer.enabled = false;

        yield return new WaitForSeconds(.05f);

        meshRenderer.enabled = true;

        yield return new WaitForSeconds(.05f);


        meshRenderer.enabled = true;

        yield return new WaitForSeconds(.05f);

        meshRenderer.enabled = false;

        yield return new WaitForSeconds(.05f);

        meshRenderer.enabled = true;

        yield return new WaitForSeconds(.05f);
    }
}
