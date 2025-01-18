using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using YG;

public class gameManager : MonoBehaviour
{
    #region DATA
        #region INT
            public int currentBalancePlayer;

            public int currentMoneyInBank;

            #region DROPER and MACHINE
                public int currentQuantityDroper;
                public int maxQuantityDroper;

                public int currentQuantityMachine;
                public int maxQuantityMachine;

                public int currentQuantityConveier;

                public int numberPumping = -1;

                public float price;

                [SerializeField]
                public float currentPrice;

                #region INT
                    public int startPriceBlock;
                #endregion
            #endregion
        #endregion

        #region GAME OBJECTS
            public GameObject[] dropersAndMachinesAndConveier;

            public Transform[] pumpingButtonTnf;

            public GameObject buttonBuy;

            public Transform mobilePlayer;
            public Transform Player;
        #endregion

        #region UI
            public TMP_Text textBalanceBank;

            public Text textBalanncePlayer;

            public GameObject mobileController;
            public GameObject PCController;
        #endregion

        #region ACTION            
            public static event Action actionSpawnProduct;
        #endregion

        #region float
            public float timer;
        #endregion

        #region CONNECT
            public buttonPumping BP;
        #endregion
        
        #region STRING
            public string device;
        #endregion
   
        #region BOOL
            public bool test;
        #endregion
    #endregion

    void Awake()
    {
        checkDevice();
    }

    void Start()
    {
        BP = GameObject.Find("buttonPumping").GetComponent<buttonPumping>();

        StartCoroutine(spawnObj());

        numberPumping = PlayerPrefs.GetInt("numberPumping");
        startPriceBlock = PlayerPrefs.GetInt("startPriceBlock");

        if(currentPrice == 0)
            currentPrice = 10 / 1.6f;

        currentBalancePlayer = PlayerPrefs.GetInt("currentBalancePlayer");
        currentMoneyInBank = PlayerPrefs.GetInt("currentMoneyInBank");
        if(currentBalancePlayer == 0)
            currentBalancePlayer = 50;

        updateTxtPlayer();
    } 

    #region BUY PUMP, CONVEIER, MACHINE

        public void buyNext()
        {
            price = currentPrice;
            price = price * 1.6f;

            if(currentBalancePlayer >= (int)price)
                removeMoney(price);
            else
                return;

            currentPrice = price;

            float nextPrice = price * 1.6f;

            dropersAndMachinesAndConveier[numberPumping].SetActive(true);

            if(dropersAndMachinesAndConveier[numberPumping].GetComponent<saveObj>() != null)
                dropersAndMachinesAndConveier[numberPumping].GetComponent<saveObj>().buyMe();
            else
                dropersAndMachinesAndConveier[numberPumping].GetComponent<doorSave>().buyMe();

            buttonBuy.GetComponent<textPriceButton>().setPrice(nextPrice);

            numberPumping++;
            currentQuantityConveier++;  
            startPriceBlock++;       

            if(numberPumping == 8)
                dropersAndMachinesAndConveier[7].SetActive(false);
            if(numberPumping == 19)
                dropersAndMachinesAndConveier[18].SetActive(false);

            PlayerPrefs.SetInt("numberPumping", numberPumping);
            PlayerPrefs.SetInt("startPriceBlock", startPriceBlock);
        }

        public void buyPump()
        {
            buyNext();
        }
    #endregion

    #region VOID and IE
        public void addMoney(int endPrice)
        {
            currentMoneyInBank += endPrice;

            updateTxtPlayer();
        }
        public void removeMoney(float price)
        {
            currentBalancePlayer -= (int)price;

            updateTxtPlayer();
        }
        public void takeMoney()
        {
            currentBalancePlayer += currentMoneyInBank;

            currentMoneyInBank = 0;

            updateTxtPlayer();
        }
        public void updateTxtPlayer()
        {
            textBalanncePlayer.text = currentBalancePlayer.ToString() + "$";

            textBalanceBank.text = currentMoneyInBank.ToString() + "$";

            PlayerPrefs.SetInt("currentBalancePlayer", currentBalancePlayer);
            PlayerPrefs.SetInt("currentMoneyInBank", currentMoneyInBank);
        }

        public void checkDevice()
        {
            device = YandexGame.EnvironmentData.deviceType;

            #region  DELETEEEEEEEEEEEEEEEEEEEEEEEE
            if(test)
                device = "mobile";

            #endregion

            if(device == "mobile")
            {
                Player.SetParent(mobilePlayer);
                Player.GetComponent<PlayerMovement>().enabled = false;

                PCController.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                mobileController.SetActive(false);

                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        IEnumerator spawnObj()
        {
            yield return new WaitForSeconds(timer);

            actionSpawnProduct?.Invoke();

            StartCoroutine(spawnObj());
        }
    #endregion

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}