using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlUp : MonoBehaviour
{
    #region DATA
        #region CONNECT
            public gameManager GM;
        #endregion
    #endregion

    private void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            
        }
    }
}
