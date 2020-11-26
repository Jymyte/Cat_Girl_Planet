using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void plaal() {
        SceneFader.instance.LoadScene("Gameplay");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
