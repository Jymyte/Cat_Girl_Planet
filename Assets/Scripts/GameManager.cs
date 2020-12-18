using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int phase = 1;
    public string comicToLoad, currentScene;
    public int hearts = 3;
    public Vector3 playerSpawnPoint;
    public List<string> disabledEnemies;

    private void Awake() {
        MakeSingleton();
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void GameOver() {
        Destroy(gameObject);
    }

    private void MakeSingleton() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
