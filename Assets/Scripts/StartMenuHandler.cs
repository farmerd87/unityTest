using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuHandler : MonoBehaviour
{

    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_Text title;


    // Start is called before the first frame update
    void Start()
    {
        var highScore = GameManager.Instance.SavedHighScore;

        if (!string.IsNullOrEmpty(highScore.HighScorePlayerName))
        {
            nameInputField.text = highScore.HighScorePlayerName;
            title.text = $"Best Score : {highScore.HighScorePlayerName} : {highScore.Score}";
        }
    }

    public void StartGame()
    {
        GameManager.Instance.PlayerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Apllication.Quit;
#endif
    }

}
