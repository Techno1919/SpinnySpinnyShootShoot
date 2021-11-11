using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    public delegate void touchDelegate(Vector2 position);

    public event touchDelegate touchStartEvent;
    public event touchDelegate touchStopEvent;
    public event touchDelegate touchUpdateEvent;

    TouchControls touchControls;
    bool touched = false;

    static TouchManager instance;
    static public TouchManager Instance 
    { 
        get 
        {
            if(instance == null)
            {
                instance = FindObjectOfType<TouchManager>();
            }
            return instance; 
        } 
    }

    public Vector2 position { get => touchControls.Touch.TouchPosition.ReadValue<Vector2>(); }

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    void Start()
    {
        touchControls.Touch.TouchPress.started += context => TouchPressStart(context);
        touchControls.Touch.TouchPress.canceled += context => TouchPressStop(context);
    }

    void Update()
    {
        if(touched)
        {
            touchUpdateEvent?.Invoke(position);
        }
    }

    void TouchPressStart(InputAction.CallbackContext context)
    {
        //Debug.Log($"Start: {position}");
        touchStartEvent?.Invoke(position);
        touched = true;
    }

    void TouchPressStop(InputAction.CallbackContext context)
    {
        //Debug.Log($"Stop: {position}");
        touchStopEvent?.Invoke(position);
        touched = false;
    }
}
