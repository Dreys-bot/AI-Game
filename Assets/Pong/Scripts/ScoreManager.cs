using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int scoreToReach;


    private int playerScore = 0;
    private int playerAIScore = 0;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI playerAIScoreText;

    public void PlayerGoal(){
        playerScore++;
        playerScoreText.text = playerScore.ToString();

        CheckScore();
    }

    public void PlayerAIGoal(){
        playerAIScore++;
        playerAIScoreText.text = playerAIScore.ToString();
        CheckScore();
    }

    //Score to end game
    private void CheckScore(){
        if(playerScore == scoreToReach || playerAIScore == scoreToReach){
            SceneManager.LoadScene(2);
        }
    }
}
