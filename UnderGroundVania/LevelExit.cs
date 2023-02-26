using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
            StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1.0f);

        int currentSceenIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceenIndex = currentSceenIndex + 1;
        if (SceneManager.sceneCountInBuildSettings == nextSceenIndex)
        {
            nextSceenIndex = 0;
        }

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceenIndex);
    }
}
