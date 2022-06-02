using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] string gameScene;
    [SerializeField] string titlleSene;

    void ReStart()
    {
        //SceneManager.LoadScene(gameScene);
    }

    void Titole()
    {
       //SceneManager.LoadScene(titlleSene);
    }
}
