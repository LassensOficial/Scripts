using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class body : MonoBehaviour
{
    #region DATA
        #region CONNECT
            public animationController AC;
        #endregion

        #region GAME OBJECTS
            public GameObject[] allBody;
        #endregion

        #region INT
            public int maxBody;

            int indexBody;
        #endregion
    #endregion

    void Awake()
    {
        animationController.initializationBody += loadAllBody;

        AC = GameObject.FindGameObjectWithTag("AC").GetComponent<animationController>();
    }

    void Start()
    {
        AC = GameObject.FindGameObjectWithTag("AC").GetComponent<animationController>();
    }

    #region VOID and IE
        public void loadAllBody()
        {
            if(gameObject.name != "idle")
            {
                gameObject.SetActive(false);
            }

            allBody = AC.body;
        }
    #endregion

    void OnEnable()
    {
        indexBody = 0;

        if(AC != null)
            destroyBody();
    }
    void destroyBody()
    {
        if(indexBody < maxBody)
        {
            if(gameObject.name != allBody[indexBody].name)
            {
                allBody[indexBody].SetActive(false);

                indexBody++;

                destroyBody();
            }
            else
            {
                indexBody++;

                destroyBody();
            }
        }
    }
}