using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAnimationControl : MonoBehaviour
{
   public void StartGameNow()
    {
        SceneManager.LoadScene(1);
    }
}
