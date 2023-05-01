using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;

    [SerializeField] Text countdownText;
    void Start()
    {
        currentTime = 0f;
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        countdownText.text = currentTime.ToString();

        
    }
}

//if (currentTime <= 0)
        //{
            //currentTime = 0;
            
            
        //}