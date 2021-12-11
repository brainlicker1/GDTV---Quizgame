using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreen : MonoBehaviour
{   [SerializeField] TextMeshProUGUI finalScoreText;
ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }

    public void ShowFinalScore(){

        finalScoreText.text = "Congradualtions cunt \nYou got a score of " +
         scoreKeeper.CalculateScore()+ "%";
    }

    // Update is called once per frame

}
