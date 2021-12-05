using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
       if(tag == "FullHeartPickup")
            {
                if (Player.Instance.health[2].sprite.name == "HalfHeart")
                {
                    Player.Instance.health[2].sprite = Player.Instance.FullHeart;
                    Player.Instance.health[1].sprite = Player.Instance.halfHeart;
                    Player.Instance.index = 2;
                    Destroy(gameObject);
                }
                else if (Player.Instance.health[1].sprite.name == "HalfHeart")
                {
                    Player.Instance.health[1].sprite = Player.Instance.FullHeart;
                    Player.Instance.health[0].sprite = Player.Instance.halfHeart;
                    Player.Instance.index = 2;
                    Destroy(gameObject);
                }
                else if (Player.Instance.health[0].sprite.name == "HalfHeart")
                {
                    Player.Instance.health[0].sprite = Player.Instance.FullHeart;
                    Player.Instance.index = 1;
                    Destroy(gameObject);
                }
                else if (Player.Instance.health[2].sprite.name == "EmptyHeart")
                {
                    Player.Instance.health[2].sprite = Player.Instance.FullHeart;
                    Player.Instance.index = 2;
                    Destroy(gameObject);
                }
                else if (Player.Instance.health[1].sprite.name == "EmptyHeart")
                {
                    Player.Instance.health[1].sprite = Player.Instance.FullHeart;
                    Player.Instance.index = 1;
                    Destroy(gameObject);
                }
                
                else if(Player.Instance.health[0].sprite.name == "EmptyHeart")
                {
                    Player.Instance.health[0].sprite = Player.Instance.FullHeart;
                    Player.Instance.index = 0;
                    Destroy(gameObject);
                }
            }
           else if(tag == "HalfHeartPickup")
            {
                if (Player.Instance.health[2].sprite.name == "HalfHeart")
                {
                    Player.Instance.health[2].sprite = Player.Instance.FullHeart;
                    Player.Instance.index = 2;
                    Destroy(gameObject);
                }
                else if (Player.Instance.health[1].sprite.name == "HalfHeart")
                {
                    Player.Instance.health[1].sprite = Player.Instance.FullHeart;
                    Player.Instance.index = 1;
                    Destroy(gameObject);
                }
                else if (Player.Instance.health[0].sprite.name == "HalfHeart")
                {
                    Player.Instance.health[0].sprite = Player.Instance.FullHeart;
                    Player.Instance.index = 0;
                    Destroy(gameObject);
                }
                else if(Player.Instance.health[2].sprite.name == "EmptyHeart")
                {
                    Player.Instance.health[2].sprite = Player.Instance.halfHeart;
                    Player.Instance.index = 2;
                    Destroy(gameObject);
                }
                else if (Player.Instance.health[1].sprite.name == "EmptyHeart")
                {
                    Player.Instance.health[1].sprite = Player.Instance.halfHeart;
                    Player.Instance.index = 1;
                    Destroy(gameObject);
                }
                else if (Player.Instance.health[0].sprite.name == "EmptyHeart")
                {
                    Player.Instance.health[0].sprite = Player.Instance.halfHeart;
                    Player.Instance.index = 0;
                    Destroy(gameObject);
                }
            }
        }
    }
}
