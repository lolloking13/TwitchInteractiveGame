using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using TwitchChatConnect.Config;
using TwitchChatConnect.Data;
using TwitchChatConnect.Manager;
using TwitchChatConnect.Parser;
using UnityEngine;
using TwitchChatConnect.Client;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Twitch Connect Data")]
    public TwitchConnectConfig connectData;

    [Header("UI")]
    public InputField userNameInputField;
    public InputField userTokenInputField;
    public InputField userChannelNameInputField;

    [Header("UI panels")]
    public GameObject[] uiPanels;

    private void Start() {
        LoadUserPrefs();

        ManageUIPanels(0);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    void LoadUserPrefs() {
        userNameInputField.text = PlayerPrefs.GetString("UserName");
        userTokenInputField.text = PlayerPrefs.GetString("UserToken");
        userChannelNameInputField.text = PlayerPrefs.GetString("UserChannelName");
    }

    public void SetUsername(string s) {
        connectData.username = s;
        PlayerPrefs.SetString("UserName", s);
    }
    public void SetToken(string s) {
        connectData.userToken = s;
        PlayerPrefs.SetString("UserToken", s);
    }
    public void SetChannelName(string s) {
        connectData.channelName = s;
        PlayerPrefs.SetString("UserChannelName", s);
    }

    public void StartScene(string s) {
        SceneManager.LoadSceneAsync(s);
    }

    public void OpenURL(string s) {
        Application.OpenURL(s);
    }

    public void ManageUIPanels(int i) {
        foreach (GameObject j in uiPanels) {
            j.SetActive(false);
        }

        uiPanels[i].SetActive(true);
    }
}
