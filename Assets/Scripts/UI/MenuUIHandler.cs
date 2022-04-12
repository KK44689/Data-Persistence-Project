using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    public InputField nameInputField;

    public Text BestScore;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        DataManager.Instance.SavePlayerData();


#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
                Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void SetPlayerName()
    {
        // if (DataManager.Instance.highScoreName != null)
        // {
        //     nameInputField.text = DataManager.Instance.highScoreName;
        // }
        DataManager.Instance.playerName = nameInputField?.text;
    }

    public void SetBestScore()
    {
        if (DataManager.Instance.highScoreName != null)
        {
            BestScore.text =
                "Best Score : " +
                DataManager.Instance.highScoreName +
                " with " +
                DataManager.Instance.highScore +
                " points.";
        }
        else
        {
            BestScore.text = "Best Score : No Records";
        }
    }

    public void ResetData()
    {
        DataManager.Instance.playerName = null;
        DataManager.Instance.highScoreName = null;
        DataManager.Instance.highScore = 0;
        DataManager.Instance.SavePlayerData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        if (DataManager.Instance.highScoreName != null)
        {
            nameInputField.text = DataManager.Instance.highScoreName;
            SetBestScore();
        }
    }

    // void Update()
    // {
    //     // SetPlayerName();
    //     SetBestScore();
    // }
}
