using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class blockController : MonoBehaviour
{
    #region DATA
        #region STRING
            public string name;
        #endregion

        #region INT
            public int startPrice;
            public int endPrice;

            public int levelBlock;
        #endregion

        #region FLOAT
            public float speed;
        #endregion

        #region INTERFACE 
            [SerializeField]
            public blockMovement BM;
        #endregion

        #region GAME OBJECTS
            public GameObject[] levelBlockObj;
        #endregion  
    #endregion



    void FixedUpdate()
    {
        (BM as Imovement).moveBlock(name);
    }

    void Start()
    {
        GameObject gameManagerObj = GameObject.FindGameObjectWithTag("gameManager");
        startPrice = gameManagerObj.GetComponent<gameManager>().startPriceBlock;
        
        endPrice = startPrice;
    }

    public void contactMachine()
    {
        levelBlockObj[levelBlock].SetActive(false);
        levelBlock++;
        levelBlockObj[levelBlock].SetActive(true);

        endPrice *= 2;
    }
}

public interface Imovement
{
    public void moveBlock(string name);
}