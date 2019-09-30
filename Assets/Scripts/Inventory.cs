﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour
{
    FirstPersonController firstPersonController;
    [SerializeField] Canvas inventory;
    bool currentlyActive;

    private void Start()
    {
        firstPersonController = FindObjectOfType<FirstPersonController>();
        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = true;
        }
        inventory.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentlyActive)
            {
                DisableInventory();
            }
            else
            {
                EnableInventory();
            }
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        DisableInventory();
        Start();
    }

    private void EnableInventory()
    {
        inventory.gameObject.SetActive(true);
        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        currentlyActive = true;
    }

    public void DisableInventory()
    {
        inventory.gameObject.SetActive(false);
        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = true;
        }
        if (FindObjectOfType<SceneInformation>().sceneType == SceneType.Room)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
        Time.timeScale = 1;
        currentlyActive = false;
    }
}