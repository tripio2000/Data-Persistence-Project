using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Text playerNameText;
    [SerializeField] Animator textBoxAnimator;

    public void StartNewGame()
    {
        //Require playerName
        if (string.IsNullOrEmpty(playerNameText.text)) 
        {
            textBoxAnimator.Play("playerTextShake");
            return; 
        }
        //Update DataManager with new playerName
        DataManager.instance.currentPlayerName = playerNameText.text;
        //Start Game
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.instance.SavePlayerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
