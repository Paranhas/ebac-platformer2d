using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using RPStudio.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public int coin;
    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coin = 0;
    }
    public void AddCoins(int amount = 1) 
    {
        coin += amount;
    }
}
