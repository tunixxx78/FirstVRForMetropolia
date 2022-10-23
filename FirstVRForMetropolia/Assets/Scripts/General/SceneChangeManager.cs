using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void ChangeSceneTo(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
