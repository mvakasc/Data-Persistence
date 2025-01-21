using UnityEditor;
using UnityEditor.SearchService;    
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MenuUI : MonoBehaviour
{
    [SerializeField] TMP_InputField PlayerNameInput;

    /// <summary>
    /// On click it will load the main scene
    /// </summary>
    public void StartNew()
    {
        if (PlayerNameInput.text != null)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void SetPlayerName()
    {
        MenuManager.Instance.PlayerName = PlayerNameInput.text;
    }


    /// <summary>
    /// Exit play mode when button is clicked
    /// </summary>
    public void Exit()
    {


#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
