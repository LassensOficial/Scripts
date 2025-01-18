using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineController : MonoBehaviour
{
    #region DATA
        #region GAME OBJECTS
            public GameObject machineObj;
        #endregion

        #region FLOAT
            public float coef;
        #endregion

        #region INT
            public int indexLevel;
        #endregion
    #endregion

    private void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "product")
        {
            obj.gameObject.GetComponent<blockController>().contactMachine();
            machineObj.GetComponent<Animator>().SetTrigger("machineAnim");
        }
    }
}