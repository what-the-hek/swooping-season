using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
// TODO edit to suit this game
// taken from this site: https://gt3000.medium.com/juice-it-adding-camera-shake-to-your-game-e63e1a16f0a6
public class CameraShakeScript : MonoBehaviour
{
    public static CameraShakeScript Instance;
    
    [SerializeField] private Transform cameraTransform;         //Holds camera's transform
    private float shakeAmount;                                  //How much it will shake
    private float shakeDuration;                                //How long it will shake for
    private float shakeSlopeOff;                                //How quickly the shaking will stop
    private Vector3 originalPos;                                //Returns camera back to it's original position

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    private void OnEnable()
    {
        //Saves camera's original positon as soon as it's enabled
        originalPos = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        ShakeControl();
    }

    //This governs the camera shake control
    private void ShakeControl()
    {
        if (shakeDuration > 0)
        {
            //while the shakeduration is greater than zero the local positon of the camera is randomly inside a sphere plus
            //the original positon multiplied by the shake amount. The greater the shake amount the greater the deviation
            cameraTransform.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * shakeAmount;
            
            //the shakeduration drops to below 0 the higher the shakeSlopeOff
            shakeDuration -= Time.deltaTime * shakeSlopeOff;
        }
        else
        {
            //Otherwise the shakeDuration is zero and camera is set to the original position
            shakeDuration = 0f;
            cameraTransform.localPosition = originalPos;
        }
    }
    
    //Takes in the amount you want shaken, how quickly the shaking slopes off over time, and how long it shakes for
    //As soon as these values are greater than zero the camera will begin shaking
    public void Shake(float totalShake, float shakeDecrease, float shakeTime)
    {
        shakeDuration = shakeTime;
        shakeSlopeOff = shakeDecrease;
        shakeAmount = totalShake;
    }
}