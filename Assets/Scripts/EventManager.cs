﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager eventManagerInstance = null;

    public delegate void ClickAction();
    public static event ClickAction OnClicked;
    public static event ClickAction OnClick;
    public static event ClickAction OnClickMovement;

    private Vector3 oldMousePos;

    void Awake()
    {
        //Check if instance already exists
        if (eventManagerInstance == null)
            //if not, set instance to this
            eventManagerInstance = this;

        //If instance already exists and it's not this:
        else if (eventManagerInstance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (OnClick != null)
            {
                OnClick();
            }

            
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (oldMousePos != Input.mousePosition)
            {
                if (OnClickMovement != null)
                {
                    OnClickMovement();
                }
                oldMousePos = Input.mousePosition;
            }
        }


        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            CancelInvoke();
            if(OnClicked != null)
                OnClicked();
        }
    }
}
