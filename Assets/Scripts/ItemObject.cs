﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ItemObject : MessageObject
{
    [SerializeField] int[] items;
    FirstPersonController firstPersonController;
    Canvas canvas;
    Image image;
    Text[] texts;

    public override Color GetColor()
    {
        return Color.blue;
    }

    public override void Highlight()
    {
        //Play an animation
    }

    public override void Execute()
    {
        if (!PlayerData.currentlyInMenu)
        {
            StartCoroutine(ObjectAction());
        }
    }

    public override IEnumerator ObjectAction()
    {
        foreach (int i in items)
        {
            if(Inventory.items.Length > i) Inventory.items[i].amount++;
        }

        PlayerData.currentlyInMenu = true;
        yield return StartCoroutine(DisplayMessage());
        PlayerData.currentlyInMenu = false;
    }
}
