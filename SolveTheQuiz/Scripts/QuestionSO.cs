using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Whith CreateAssetMenu() you can create this script in to like assets
[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject //Scriptable object is so usefull for storing data and etc instead of monoBehaviour scripts
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex = 2;
    public string GetQuestion() { return question; }
    public int GetCorrectAnswerIndex() { return correctAnswerIndex; }
    public string GetAnswer(int index) { return answers[index]; }

}
 