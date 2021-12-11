using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{   [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
     QuestionSO currentQuestion;
     [SerializeField] List<QuestionSO> questions;
    
    [Header("Buttons")]
        [SerializeField] GameObject[]  answerButtons;

    [Header("Answers")]    
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite wrongAnswerSprite;
    bool hasAnsweredEarly = true; 

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;
    void Start()
    {    
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
         //DisplayQuestion();
    }

     void Update() {
        timerImage.fillAmount =  timer.fillFraction;
        if(timer.loadNextQuestion){
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion){

            DisplayAnswer(-1);
            SetButtonState(false);

        }

    }
    void DisplayAnswer(int index){

      Image buttonImage;
        if(index == currentQuestion.GetCorrectAnswerIndex()){

            questionText.text = "Yay bitch";

            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;    

            scoreKeeper.IncrementCorrectAnsweres();
        }  else {
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Wrong!  the right answer is;\n " + correctAnswer;

           
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            
        }
    }
    public void OnAnswerSelected( int index){
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
        if(progressBar.value == progressBar.maxValue){
            isComplete = true;
        }
    }
    
    void GetNextQuestion(){
        if(questions.Count > 0) {

            SetButtonState(true);
        SetDefaultButtonSprites();
        GetRandomQuestion();
        DisplayQuestion();
        progressBar.value++;
        scoreKeeper.IncrementQuestionsSeen();
        }
        
    }
    void GetRandomQuestion(){

        int index = Random.Range(0,questions.Count);
        currentQuestion = questions[index];
        if(questions.Contains(currentQuestion)){

            questions.Remove(currentQuestion);
        }
        

    }
    void  SetDefaultButtonSprites(){

        for(int i = 0; i < answerButtons.Length; i++){

            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
                    }


    }
    void DisplayQuestion(){
        questionText.text = currentQuestion.GetQuestion();
        for(int i = 0; i <  answerButtons.Length; i++){

         TextMeshProUGUI butttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            butttonText.text = currentQuestion.GetAnswer(i); 
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
