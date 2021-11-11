using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables
    public float speed = 2;
    public PlayerShot shot;
    public Weapon weapon;
    public float shotTimer = 0;
    public Image[] health;
    public int index = 0;
    public bool halfHeartLeft = false;
    public Sprite halfHeart;
    public Sprite emptyHeart;

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
        Gamepad gamepad = Gamepad.current;

        transform.Translate(input * speed * Time.deltaTime);

        if(health[health.Length-1].sprite == emptyHeart)
        {
            Game.Instance.gameOver = true;
        }

        if (gamepad == null) return;
        //input = gamepad.leftStick.ReadValue();
        if (shotTimer <= .5f) shotTimer -= Time.deltaTime;
        if (gamepad.buttonSouth.wasPressedThisFrame) OnFire();

    }

    public void OnFire()
    {
       if(shotTimer <= 0)
       {
           shotTimer = .5f;
           Instantiate(shot, weapon.shootPoint.transform.position, Quaternion.identity);
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
        if(collision.gameObject.tag == "EnemyShot")
        {
            if(halfHeartLeft)
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
