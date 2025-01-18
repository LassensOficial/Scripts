using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSave : MonoBehaviour
{
    #region  DATA
        #region INT
            [SerializeField]
            int imBuy; // 0 - false, 1 - true
        #endregion
    #endregion
    void Awake()
    {
        imBuy = PlayerPrefs.GetInt(gameObject.name + "IsBuy");

        if(imBuy == 1)
            gameObject.SetActive(false);
    }

    public void buyMe()
    {
        imBuy = 1;
        
        PlayerPrefs.SetInt(gameObject.name + "IsBuy", imBuy);
    }
}