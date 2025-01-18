using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class textPriceButton : MonoBehaviour
{
    #region DATA
        #region  TRANSFORM
            public Transform player;
        #endregion

        #region UI
            public TMP_Text textPriceButtonTxt;
        #endregion

        #region INT
            public float price;

            public int priceInt;
        #endregion

        #region CONNECT
            public gameManager GM;
        #endregion
    #endregion  

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        GM = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();

        price = PlayerPrefs.GetFloat("price");

        if(price == 0)
            price = 10;

        GM.price = price;
        GM.currentPrice = (price / 1.6f);

        setPrice(price);
    }

    public void setPrice(float price)
    {
        priceInt = (int)price;

        textPriceButtonTxt.text = priceInt.ToString();

        PlayerPrefs.SetFloat("price", price);
    }

    void Update()
    {
        transform.LookAt(player);
    }
}