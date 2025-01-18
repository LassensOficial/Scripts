using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPumping : MonoBehaviour
{
    #region DATA
        #region CONNECT
            public gameManager GM;
        #endregion

        #region INT
            public int numberLocationMe;
        #endregion
    #endregion

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();

        numberLocationMe = PlayerPrefs.GetInt("buttonPumpingNumber");

        transform.position = GM.pumpingButtonTnf[numberLocationMe].position;
    }
    
    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            int numberPumpingGameManager1 = GM.numberPumping;
            GM.buyPump();
            int numberPumpingGameManager2 = GM.numberPumping;

            if((numberPumpingGameManager2 - numberPumpingGameManager1) != 0)
            {
                numberLocationMe++;

                PlayerPrefs.SetInt("buttonPumpingNumber", numberLocationMe);

                #region TELEPORT ME
                    transform.position = GM.pumpingButtonTnf[numberLocationMe].position;
                #endregion
            }

            
        }
    }
}