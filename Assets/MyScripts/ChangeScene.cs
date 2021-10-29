using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        Debug.Log(sceneName);
        PlayerPrefs.SetString("SelectedLevel", sceneName);
        SceneManager.LoadScene("Lobby");
    }


}

