using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
//<<<<<<< Updated upstream
    public bool powerActive;
    public bool invincible;
    public float timeRemaining;
    public ParticleSystem particleSystem;
    

    public GameObject wayPoint;
    //This is how often your waypoint's position will update to the player's position
    private float followtimer = 0.5f;
//=======
//>>>>>>> Stashed changes

    #region Variables
    public float speed = 2;
    public PlayerShot shot;
    public Weapon weapon;
    public Weapon weapon2;
    public float shotTimer = 0;
    public Image[] health;
    public int index = 0;
    public bool halfHeartLeft = false;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public Sprite FullHeart;
    public Chest nearChest;
    public bool firstWeaponActive = true;

    public HealthPickup fullHeartPickup;
    public HealthPickup halfHeartPickup;
    public GameObject coin;

    static Player instance;
    static public Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    Vector2 input;
    #endregion

    void Start()
    {
        GetComponent<PlayerInput>().onActionTriggered += HandleAction;
        instance = this;
    }

    void Update()
    {

        if (followtimer > 0)
        {
            followtimer -= Time.deltaTime;
        }
        if (followtimer <= 0)
        {
            //The position of the waypoint will update to the player's position
            UpdatePosition();
            followtimer = 0.5f;
        }

        Gamepad gamepad = Gamepad.current;

        transform.Translate(input * speed * Time.deltaTime);

        if (health[health.Length - 1].sprite == emptyHeart)
        {
            Game.Instance.gameOver = true;
        }

        if (gamepad == null) return;
        //input = gamepad.leftStick.ReadValue();
        if (shotTimer <= .5f) shotTimer -= Time.deltaTime;
        if (gamepad.buttonSouth.wasPressedThisFrame) OnFire();
        if (gamepad.buttonNorth.wasPressedThisFrame) ActionButton();

    }

    public void SwapWeapons()
    {
        if(firstWeaponActive)
        {
            weapon.gameObject.SetActive(false);
            weapon2.gameObject.SetActive(true);
            firstWeaponActive = false;
        }
        else
        {
            weapon.gameObject.SetActive(true);
            weapon2.gameObject.SetActive(false);
            firstWeaponActive = true;
        }
    }

    void UpdatePosition()
    {
        //The wayPoint's position will now be the player's current position.
        wayPoint.transform.position = transform.position;
    }

    public void OnFire()
    {
        if (shotTimer <= 0)
        {
            shotTimer = .5f;
            if(firstWeaponActive)
            {
                switch (weapon.weaponType)
                {
                    case WeaponType.Staff:
                        PlayerShot spawnedShot = Instantiate(shot, weapon.shootPoint.transform.position, Quaternion.identity);
                        spawnedShot.test = weapon.transform.up;
                        break;
                    case WeaponType.Sword:
                        weapon.rotateAttack = true;
                        weapon.tag = "Shot";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (weapon2.weaponType)
                {
                    case WeaponType.Shotgun:
                        PlayerShot spawnedShot = Instantiate(shot, weapon2.shootPoint.transform.position, Quaternion.identity);
                        spawnedShot.test = weapon2.transform.up;
                        spawnedShot = Instantiate(shot, weapon2.shootPoint2.transform.position, Quaternion.identity);
                        spawnedShot.test = weapon2.transform.up;
                        spawnedShot = Instantiate(shot, weapon2.shootPoint3.transform.position, Quaternion.identity);
                        spawnedShot.test = weapon2.transform.up;
                        break;
                    case WeaponType.Pistol:
                        spawnedShot = Instantiate(shot, weapon2.shootPoint.transform.position, Quaternion.identity);
                        spawnedShot.test = weapon2.transform.up;
                        break;
                }
            } 

        }
    }

    public void ActionButton()
    {
        nearChest.spriteRenderer.sprite = nearChest.openedSprite;
        int rand = Random.Range(0, 100);
        if (rand <= 50)
        {
            Instantiate(coin, nearChest.spawnPoint);
        }
        else if (rand >= 51 || rand <= 85)
        {
            Instantiate(halfHeartPickup, nearChest.spawnPoint);
        }
        else if (rand >= 86 || rand <= 100)
        {
            Instantiate(fullHeartPickup, nearChest.spawnPoint);
        }
    }

    public void OnMove(InputValue inputValue)
    {
        input = inputValue.Get<Vector2>();
        weapon.Rotate(input);
    }

    public void OnMove(InputAction.CallbackContext contenxt)
    {
        input = contenxt.ReadValue<Vector2>();
        weapon.Rotate(input);
    }

    private void HandleAction(InputAction.CallbackContext context)
    {
        if (context.action.name == "Fire")
        {
            OnFire();
        }
        if (context.action.name == "Move")
        {
            OnMove(context);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyShot")
        {
            if (!invincible)
            {
                if (halfHeartLeft)
                {
                    health[index].sprite = emptyHeart;
                    halfHeartLeft = false;
                    index++;
                }
                else
                {
                    health[index].sprite = halfHeart;
                    halfHeartLeft = true;
                }
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Game.Instance.score += 100;
            Destroy(collision.gameObject);
        }
    }
}