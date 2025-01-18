using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class animationController : MonoBehaviour
{
    #region DATA
        #region GAME OBJECTS
            public GameObject[] body;
        #endregion

        #region BOOL
            public bool isRun;
        #endregion

        #region CONNECT
            public static event Action initializationBody;
        #endregion  
    #endregion  

    void Start()
    {
        body[0] = GameObject.FindGameObjectWithTag("run");
        body[1] = GameObject.FindGameObjectWithTag("idle");

        initializationBody?.Invoke();
    }

    void Update()
    {
        if(body[1] != null)
        {
            if(isRun)
                body[0].SetActive(true);
            else
                body[1].SetActive(true);
        }
    }
}
