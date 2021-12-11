using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
   
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCoreectAnswer = 10f;


    public bool loadNextQuestion;
    public float fillFraction;
    public bool isAnsweringQuestion;
    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer(){

        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion){

            if(timerValue > 0) {

                fillFraction = timerValue / timeToCompleteQuestion;

            } else {

                isAnsweringQuestion = false;
                timerValue = timeToShowCoreectAnswer;

            }

        } else {

                
       

            if(timerValue > 0) {

                fillFraction = timerValue / timeToShowCoreectAnswer;

            } else {

                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;

        }

        }}
        
        public void CancelTimer() {
            timerValue = 0;
        }
        

         //end of main

        }

   
