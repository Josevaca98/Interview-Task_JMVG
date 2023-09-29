using System;
using System.Collections;
using System.Collections.Generic;
using ClipperLib;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public int[,] shopItems = new int[6,6];
    public float coins;
    public TextMeshProUGUI coinsTxt;
    void Start()
    {
        coinsTxt.text = "Coins: " + coins.ToString();

        //ID
        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;
        shopItems[1,5] = 5;

        //Price
        shopItems[2,1] = 10;
        shopItems[2,2] = 15;
        shopItems[2,3] = 50;
        shopItems[2,4] = 100;
        shopItems[2,5] = 20;

        //Quantity
        shopItems[3,1] = 0;
        shopItems[3,2] = 0;
        shopItems[3,3] = 0;
        shopItems[3,4] = 0;
        shopItems[3,5] = 0;
    }

    public void Buy()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(coins >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID])
        {
            coins -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID];

            shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID]++;

             coinsTxt.text = "Coins: " + coins.ToString();
             buttonRef.GetComponent<ButtonInfo>().quantityText.text = shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID].ToString();
        }
    }

public void Sell()
{
    GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

    int itemID = buttonRef.GetComponent<ButtonInfo>().itemID;

    // Check if ther is at least on object to sell
    if (shopItems[3, itemID] > 0)
    {
        //Obtain the price of the object in sale
        int sellPrice = shopItems[2, itemID];

        //Increase the coins
        coins += sellPrice;

        //Decrease the objects on the inventory
        shopItems[3, itemID]--;

        //Update the UI
        coinsTxt.text = "Coins: " + coins.ToString();
        buttonRef.GetComponent<ButtonInfo>().quantityText.text = shopItems[3, itemID].ToString();
    }
}
}
