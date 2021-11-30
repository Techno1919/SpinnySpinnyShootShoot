using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float timeRemaining;


    public Player wimzard;
    //public PlayerShot bullet;
    int scaleX = 2;
    int scaleY = 2;
    int scaleZ = 2;

    public AudioSource pickUpNoise;
    public AudioSource powerDown;

    public string powerupName;

    public void Start()
    {
        wimzard = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (wimzard.powerActive)
        {
            if (wimzard.timeRemaining > 0)
            {
                //timeRemaining -= Time.deltaTime;
                wimzard.timeRemaining -= Time.deltaTime;
            }
            else if (wimzard.timeRemaining <= 0)
            {
                powerDown.Play();
                wimzard.timeRemaining = 0;
                wimzard.shot.speed = 7;
                wimzard.shotTimer = 0.5f;
                wimzard.shot.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                wimzard.invincible = false;
                wimzard.powerActive = false;

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            wimzard.shot.speed = 7;
            wimzard.shot.damage = 25;
            wimzard.shot.lifetime = 5;
            wimzard.particleSystem.Play();
            wimzard.shot.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            switch (powerupName)
            {
                case "FastFire":
                    wimzard.powerActive = true;
                    wimzard.shotTimer = 0.1f;
                    wimzard.shot.speed = 100;
                    wimzard.timeRemaining = 5;
                    timeRemaining = 5;

                    break;
                case "BiggerBullet":
                    wimzard.powerActive = true;
                    wimzard.shot.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                    timeRemaining = 6;
                    wimzard.timeRemaining = 6;

                    break;
                case "MarioStarRipoff":
                    wimzard.powerActive = true;
                    wimzard.invincible = true;
                    wimzard.timeRemaining = 10;

                    timeRemaining = 10;
                    break;
            }
            PlayPowerUp();
            Debug.Log("Pickup");
            Destroy(gameObject);
            }
        }

    public void PlayPowerUp()
    {
        pickUpNoise.Play();
        Debug.Log("Pickup noise played");
    }

}

 

