using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textGetMoney : MonoBehaviour
{
    #region DATA
        #region GAME OBJECTS
            public GameObject player;
        #endregion
    #endregion

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(player.transform);
    }
}
