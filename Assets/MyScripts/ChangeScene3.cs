using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExitGames.Client.Photon;
using Photon.Realtime;


namespace Photon.Pun
{
    public class ChangeScene3 : MonoBehaviour
    {

        public void LoadScene(string sceneName)
        {
            Debug.Log(sceneName);
            PlayerPrefs.SetString("SelectedLevel", sceneName);
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("Lobby");
        }
    }
}

