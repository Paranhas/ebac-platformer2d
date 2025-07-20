using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using RPStudio.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coin;
    public TextMeshProUGUI uiTextCoins;
    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coin.value = 0;
        UpdateUI();
    }
    public void AddCoins(int amount = 1) 
    {
        coin.value += amount;
        UpdateUI();
    }
    private void UpdateUI()
    {
        //uiTextCoins.text = coin.ToString();
    }
}
