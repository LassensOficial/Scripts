using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiGameManager : MonoBehaviour
{
    #region DATA
        #region INT
            public int audioIsActive; // 0 - true 1 - false
        #endregion

        #region GAME OBJECTS
            public GameObject audio;

            public GameObject iconAudio;
            public GameObject iconDestroyAudio;
        #endregion
    #endregion

    void Start()
    {
        audioIsActive = PlayerPrefs.GetInt("audioIsActive");

        if(audioIsActive == 0)
        {
            audio.GetComponent<AudioSource>().volume = 0.55f;

            iconAudio.SetActive(true);
            iconDestroyAudio.SetActive(false);
        }
        if(audioIsActive == 1)
        {
            audio.GetComponent<AudioSource>().volume = 0;

            iconAudio.SetActive(false);
            iconDestroyAudio.SetActive(true);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            clickAudio();
    }

    #region VOID and IE
        public void clickAudio()
        {
            if(audioIsActive == 0)
            {
                audioIsActive = 1;
                
                audio.GetComponent<AudioSource>().volume = 0;

                iconAudio.SetActive(false);
                iconDestroyAudio.SetActive(true);

                PlayerPrefs.SetInt("audioIsActive", audioIsActive);

                return;
            }
            if(audioIsActive == 1)
            {
                audioIsActive = 0;

                audio.GetComponent<AudioSource>().volume = 0.55f;

                iconAudio.SetActive(true);
                iconDestroyAudio.SetActive(false);

                PlayerPrefs.SetInt("audioIsActive", audioIsActive);
            }
        }
    #endregion
}
