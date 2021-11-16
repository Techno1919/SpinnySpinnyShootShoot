using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{


    public Player wimzard;
    //public PlayerShot bullet;
    int scaleX = 2;
    int scaleY = 2;
    int scaleZ = 2;

    public string powerupName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            wimzard.shot.speed = 7;
            wimzard.shot.damage = 25;
            wimzard.shot.lifetime = 5;
            wimzard.shot.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            switch (powerupName)
            {
                case "FastFire":
                    wimzard.shotTimer = 0.1f;
                    wimzard.shot.speed = 100;
                    break;
                case "BiggerBullet":
                   
                    //fireball.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    wimzard.shot.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                    break;
                case "MarioStarRipoff":
                    break;
            }
            Debug.Log("Pickup");
            Destroy(gameObject);
        }
    }
       

}
