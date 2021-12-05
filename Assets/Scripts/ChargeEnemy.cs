using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class ChargeEnemy : MonoBehaviour
{
    public float maxHP = 25;
    public float shootTimer = 5;
    public EnemyShot shot;
    public float speed = 5;
    public float moveTimer = 3;

    //public 

    float HP;

    //You may consider adding a rigid body to the zombie for accurate physics simulation
    public GameObject wayPoint;
    public Vector2 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    public float enemyspeed = 6.0f;
    SkeletonAnimation sa;

    Vector2 targetPos;
    public MeshRenderer meshRenderer;
    //public Material ogTex;
    //public Material flashTex;
    //public Renderer ren;
    //public Material[] mat;



    void Start()
    {
        HP = maxHP;
        sa = GetComponent<SkeletonAnimation>();
        //meshRenderer = GetComponent<Material>();
        //meshRenderer.materials[0] = flashTex;
        //ren = GetComponent<Renderer>();
        //mat = ren.materials;
        //mat[0] = flashTex   ;
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
                FindPostion();
                StartCoroutine(ChargeAttack());
            }
        }

        if (HP <= 0)
        {
            sa.AnimationName = "<None>";
            StartCoroutine(PlayDeath());        
        }

    }

    IEnumerator ChargeAttack()
    {

        Debug.Log("Commence Charge");
        sa.AnimationName = "Attack";
        yield return new WaitForSeconds(1f);

        sa.AnimationName = "Walk";
        sa.loop = false;
        enemyspeed = 7f;
        wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
       
        transform.position = Vector2.MoveTowards(transform.position, targetPos, enemyspeed * Time.deltaTime);
        yield return new WaitForSeconds(.5f);

        sa.AnimationName = "Idle";
        sa.loop = true;
        shootTimer = 5;
    }
    
    IEnumerator PlayDeath()
    {
        sa.AnimationName = "Dead";
        shootTimer = 100;
        enemyspeed = 0;
        sa.loop = false;
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
        //StartCoroutine(FlashEffect());

        if (collision.gameObject.tag == "Shot")
        {
            HP -= Player.Instance.weapon.damage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
           // StartCoroutine(FlashEffect());

            HP -= Player.Instance.weapon.damage;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            StartCoroutine(FlashEffect());

            HP -= Player.Instance.weapon.damage;
        }
    }

    public void FindPostion()
    {
        targetPos = FindObjectOfType<Player>().transform.position;
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
