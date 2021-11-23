using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponChoose : MonoBehaviour
{
    public GameObject sword;
    public GameObject staff;
    public GameObject shotgun;
    public GameObject pistol;
    public GameObject UIScreen;
    public GameObject weaponChooseScreen;

    public void WeaponChooseButton()
    {
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "SwordButton":
                GameObject weapon = Instantiate(sword);
                weapon.transform.SetParent(Game.Instance.player.transform);
                Game.Instance.player.weapon = weapon.GetComponent<Weapon>();
                weapon.transform.localPosition = new Vector3(-0.135f, -0.822f, 0);
                UIScreen.SetActive(true);
                weaponChooseScreen.SetActive(false);
                Game.Instance.startGame = true;
                break;
            case "StaffButton":
                weapon = Instantiate(staff);
                weapon.transform.SetParent(Game.Instance.player.transform);
                Game.Instance.player.weapon = weapon.GetComponent<Weapon>();
                weapon.transform.localPosition = new Vector3(0.1f, -0.18f, 0);
                UIScreen.SetActive(true);
                weaponChooseScreen.SetActive(false);
                Game.Instance.startGame = true;
                break;
            case "PistolButton":
                weapon = Instantiate(pistol);
                weapon.transform.SetParent(Game.Instance.player.transform);
                Game.Instance.player.weapon = weapon.GetComponent<Weapon>();
                weapon.transform.localPosition = new Vector3(0.05f, -0.38f, 0);
                UIScreen.SetActive(true);
                weaponChooseScreen.SetActive(false);
                Game.Instance.startGame = true;
                break;
            case "ShotgunButton":
                weapon = Instantiate(shotgun);
                weapon.transform.SetParent(Game.Instance.player.transform);
                Game.Instance.player.weapon = weapon.GetComponent<Weapon>();
                weapon.transform.localPosition = new Vector3(0.03f, -0.7f, 0);
                UIScreen.SetActive(true);
                weaponChooseScreen.SetActive(false);
                Game.Instance.startGame = true;
                break;
        }
    }
}
