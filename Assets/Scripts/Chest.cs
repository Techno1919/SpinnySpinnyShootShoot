using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openedSprite;
    public Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Game.Instance.fireButton.SetActive(false);
            Game.Instance.actionButton.SetActive(true);
            Player.Instance.nearChest = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Game.Instance.actionButton.SetActive(false);
            Game.Instance.fireButton.SetActive(true);
            Player.Instance.nearChest = null;
        }
    }
}
