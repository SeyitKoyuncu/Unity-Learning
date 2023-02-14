using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int questionSeen = 0;
    
    public int GetCorrectAnswers() { return correctAnswers; }
    public void IncrementCorrectAnswers() { correctAnswers++; }
    public int GetQuestionSeen() { return correctAnswers; }
    public void IncrementQuestionSeen() { questionSeen++; }

    public int CalculateScore() { return Mathf.RoundToInt(correctAnswers * 100/ (float)questionSeen); }
}
