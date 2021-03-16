using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;

public class Switch : MonoBehaviour
{

    public GameObject CamPlayer;
    public GameObject CamGracz2;
    
    public GameObject CamGracz3;
    
    AudioListener CamPlayerAudioLis;
    AudioListener CamGracz2AudioLis;
    
    AudioListener CamGracz3AudioLis;
    
    void Start()
    {
        CamPlayerAudioLis = CamPlayer.GetComponent<AudioListener>();
        CamGracz2AudioLis = CamGracz2.GetComponent<AudioListener>();
        
        CamGracz3AudioLis = CamGracz3.GetComponent<AudioListener>();
        
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
            cameraPositionCounter++;
            cameraPositionChange(cameraPositionCounter);
           
        } else if(Input.GetKeyDown(KeyCode.Alpha2)) {

            int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
            cameraPositionCounter++;
            cameraPositionChange(cameraPositionCounter);
            
        }else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
            cameraPositionCounter++;
            cameraPositionChange(cameraPositionCounter);
        }


    }
    
    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 2)
        {
            camPosition = 0;
        }

        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //ustawiam cam1 
        if (camPosition == 0)
        {
            CamPlayer.SetActive(true);
            CamPlayerAudioLis.enabled = true;

            CamGracz2AudioLis.enabled = false;
            CamGracz2.SetActive(false);
            
            CamGracz3.SetActive(false);
            CamGracz3AudioLis.enabled = false;
        }

        //ustawiam cam2
        if (camPosition == 1)
        {
            CamGracz2.SetActive(true);
            CamGracz2AudioLis.enabled = true;

            CamPlayerAudioLis.enabled = false;
            CamPlayer.SetActive(false);
            
            CamGracz3.SetActive(false);
            CamGracz3AudioLis.enabled = false;
        }
        
        //ustawiam cam3
        if (camPosition == 2)
        {
            CamGracz3.SetActive(true);
            CamGracz3AudioLis.enabled = true;

            CamPlayerAudioLis.enabled = false;
            CamPlayer.SetActive(false);
            
            CamGracz2AudioLis.enabled = false;
            CamGracz2.SetActive(false);
            
        }

    }
}
