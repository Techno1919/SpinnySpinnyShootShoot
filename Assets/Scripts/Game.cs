using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

public class Game : MonoBehaviour
{
    public GameObject closedDoor;
    public GameObject openedDoor;
    public bool gameOver = false;
    public bool gameWin = false;
    public int score = 0;
    public Text scoreText;
    public GameObject youWin;
    public GameObject youLose;
    public GameObject playAgain;
    public PlayerShot fireball;
    public Player player;
    public bool startGame = false;
    public GameObject fireButton;
    public GameObject actionButton;

    public GameObject gameChoose2;
    public GameObject UIScreen;
    public GameObject weaponChooseScreen;

    public Weapon sword;
    public Weapon staff;
    public Weapon shotgun;
    public Weapon pistol;

    public Powerup fastFire;
    public Powerup biggerBullet;
    public Powerup marioStarRipoff;
    List<Weapon> weapons = new List<Weapon>();

    static Game instance;
    static public Game Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Game>();
            }
            return instance;
        }
    }

    Enemy[] enemies;

    private void Awake()
    {
        var json = Resources.Load<TextAsset>("Weapons");
        var array = JArray.Parse(json.text);

        foreach (var item in array)
        {
            try
            {
                weapons.Add(item.ToObject<Weapon>());
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }
    }

    private void Start()
    {
        fireball.speed = 7;
        fireball.damage = 25;
        fireball.lifetime = 5;
        fireball.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        youWin.SetActive(false);
        youLose.SetActive(false);
        playAgain.SetActive(false);
        Time.timeScale = 0;

        foreach (var weapon in weapons)
        {
            switch (weapon.weaponType)
            {
                case WeaponType.Staff:
                    staff.damage = weapon.damage;
                    staff.weaponType = weapon.weaponType;
                    staff.rotateAttack = weapon.rotateAttack;
                    break;
                case WeaponType.Shotgun:
                    shotgun.damage = weapon.damage;
                    shotgun.weaponType = weapon.weaponType;
                    shotgun.rotateAttack = weapon.rotateAttack;
                    break;
                case WeaponType.Pistol:
                    pistol.damage = weapon.damage;
                    pistol.weaponType = weapon.weaponType;
                    pistol.rotateAttack = weapon.rotateAttack;
                    break;
                case WeaponType.Sword:
                    sword.damage = weapon.damage;
                    sword.weaponType = weapon.weaponType;
                    sword.rotateAttack = weapon.rotateAttack;
                    break;
            }
        }
    }

    void Update()
    {
        if (startGame)
        {
            Time.timeScale = 1;
        }
        else
        {
            return;
        }

        scoreText.text = $"Score: {score}";

        enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length <= 0)
        {
            gameWin = true;

            /*closedDoor.SetActive(false);
            openedDoor.SetActive(true);*/
        }

        if(gameWin)
        {
            youWin.SetActive(true);
            playAgain.SetActive(true);
        }
        if(gameOver)
        {
            youLose.SetActive(true);
            playAgain.SetActive(true);
        }
    }
}
