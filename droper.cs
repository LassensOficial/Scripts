using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droper : MonoBehaviour
{
    #region DATA
        #region FLOAT
            public float timer;
            private float dedaultTimer = 5f;
        #endregion  

        #region INT
            public int idDroper;
        #endregion

        #region GAME OBJECTS
            public GameObject currentObjSpawn;
        #endregion
    #endregion

    public void OnEnable()
    {
        gameManager.actionSpawnProduct += blockSpawner;
    }
    public void OnDisable()
    {
        gameManager.actionSpawnProduct -= blockSpawner;
    }

    public void blockSpawner()
    {
        Instantiate(currentObjSpawn).transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y - 1.2f,gameObject.transform.position.z);
    }
    // IEnumerator blockSpawner()
    // {
        
    //     Instantiate(currentObjSpawn).transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y - 1.2f,gameObject.transform.position.z);
    //     StartCoroutine(blockSpawner());
    // }
}
