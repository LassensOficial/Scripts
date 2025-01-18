using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockMovement : MonoBehaviour, Imovement
{
    #region DATA
        #region CONNECT
            public gameManager GM;
            public blockController BC;
        #endregion

        #region INT
            public int endPrice;
        #endregion
    #endregion

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();

        if(gameObject.GetComponent<blockController>() != null)
            BC = gameObject.GetComponent<blockController>();
    }

    public void moveBlock(string name)
    {
        if(transform.position.y <= 1.35f)
        {
            if(name == "directly")
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);

            if(name == "right")
                transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);

            if(name == "back")
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "endConveier")
        {
            endPrice = BC.endPrice;
            GM.currentMoneyInBank += endPrice;
            Destroy(gameObject);
        }

        if(obj.gameObject.tag == "productTernRight")
        {
            BC.name = "right"; 
        }

        if(obj.gameObject.tag == "productTernBack")
        {
            BC.name = "back"; 
        }

        if(obj.gameObject.tag == "productTernDirectly")
        {
            BC.name = "directly";
        }
    }
}