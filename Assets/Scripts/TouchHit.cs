using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchHit : MonoBehaviour
{
    private void OnEnable()
    {
        TouchManager.Instance.touchStartEvent += Touch;
    }

    private void OnDisable()
    {
        if (TouchManager.Instance == null) return;

        TouchManager.Instance.touchStartEvent -= Touch;
    }

    void Touch(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        
        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if(raycastHit.collider.gameObject == gameObject)
            {
                if(raycastHit.collider.gameObject.tag == "Play")
                {
                    SceneManager.LoadScene("BeginingRoom");
                }
                if(raycastHit.collider.gameObject.tag == "Quit")
                {
                    Application.Quit();
                }

            }
        }
    }
}
