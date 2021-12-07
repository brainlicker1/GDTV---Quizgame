using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[]  answerButtons;

    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite wrongAnswerSprite;
    void Start()
    {
         DisplayQuestion();
    }

    public void OnAnswerSelected( int index){
         Image buttonImage;
        if(index == question.GetCorrectAnswerIndex()){

            questionText.text = "Yay bitch";

            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;    


        }  else {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Wrong!  the right answer is;\n " + correctAnswer;

           
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            
        }
        SetButtonState(false);
    }
    
    void GetNextQuestion(){

        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void  SetDefaultButtonSprites(){

        for(int i = 0; i < answerButtons.Length; i++){

            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
                    }


    }
    void DisplayQuestion(){
        questionText.text = question.GetQuestion();
        for(int i = 0; i <  answerButtons.Length; i++){

         TextMeshProUGUI butttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            butttonText.text = question.GetAnswer(i); 
        }

    }
   void SetButtonState(bool state){
       for(int i = 0; i < answerButtons.Length; i++){


           Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;


       }
   }
//end of main
}
