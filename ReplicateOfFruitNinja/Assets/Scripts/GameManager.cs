using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText, gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    private float spawnRate = 1.0f;
    private int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore(0);
        if (ISGameOver())
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }          
    }

    IEnumerator SpawnTarget()
    {
        Debug.Log("Inside of SpawnTarget, out of while");
        while(true && !ISGameOver())
        {
            // The yield return statement is special; it is what actually tells Unity to pause the script and continue on the next frame.
            Debug.Log("Inside of SpawnTarget and while, before yield return");
            yield return new WaitForSeconds(spawnRate);
            Debug.Log("Inside of SpawnTarget and while, after yield return");
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public bool ISGameOver()
    {
        if (score < 0) return true;
        return false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        score = 0;
        spawnRate = spawnRate / difficulty;
        //You cant call with like that SpawnTarget(), if you try to call like SpawnTarget(), it never go to the SpawnTarget() this method
        //So you need to use StartCoroutine
        StartCoroutine(SpawnTarget());
        Debug.Log("After StartCoroutine");
        titleScreen.SetActive(false);
    }
}
