using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    [SerializeField]
    private GameObject fadePanel;
    [SerializeField]
    private Animator fadeAnim;

    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadScene(string scene) {
        StartCoroutine(FadeInOut(scene));
    }

    IEnumerator FadeInOut(string scene) {
        fadePanel.SetActive(true);
        fadeAnim.Play("FadeIn");
        yield return StartCoroutine(SceneCoroutine.WaitForRealSeconds(1f));
        SceneManager.LoadScene(scene);
        fadeAnim.Play("FadeOut");
        yield return StartCoroutine(SceneCoroutine.WaitForRealSeconds(.7f));
        fadePanel.SetActive(false);
    }
}
