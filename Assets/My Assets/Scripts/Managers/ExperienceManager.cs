using System.Linq;
using TwitchChatConnect.Client;
using TwitchChatConnect.Config;
using TwitchChatConnect.Data;
using TwitchChatConnect.Manager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ExperienceManager : MonoBehaviour
{
    public Transform userCharacter;

    [Header("Commands")]
    public string spawnEnemyCommand = "enemy";

    [Header("Prefabs")]
    public GameObject enemyPrefab;
    public Color[] entityUserNameColors;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    [Header("UI Elements")]
    public InputField commandInputField;

    private void Start() {
        UpdateUI();

        StartCoroutine(SpawnEnemyOfflineprocess());
    }

    void UpdateUI() {
        commandInputField.text = spawnEnemyCommand;
    }

    public void SetSpawnEnemyCommand(string s) {
        spawnEnemyCommand = s;
    }

    public void AnalizeCommand(TwitchChatCommand chatCommand) {

        if (string.Equals(chatCommand.Command, "!" + spawnEnemyCommand)) {

            SpawnEntity(chatCommand.User.DisplayName);
        }
    }

    void SpawnEntity(string entityName) {
        GameObject entityGameObject = Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

        EntitySetup entitySetup = entityGameObject.GetComponent<EntitySetup>();
        entitySetup.SetupEntity(entityName, entityUserNameColors[Random.Range(0, entityUserNameColors.Length)]);

        EntityIABehaviour entityBehaviour = entityGameObject.GetComponent<EntityIABehaviour>();
        entityBehaviour.target = userCharacter;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadSceneAsync("Menu");
    }

    public IEnumerator SpawnEnemyOfflineprocess() {
        yield return new WaitForSeconds(3f);

        while (true) {
            SpawnEntity("TuningMania");
            yield return new WaitForSeconds(3f);
        }
    }

    public void OpenURL(string s) {
        Application.OpenURL(s);
    }
}
