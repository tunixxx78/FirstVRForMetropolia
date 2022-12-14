using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropDetector : MonoBehaviour
{
    //[SerializeField] GameObject gameoverScreen;
    [SerializeField] float delayTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //gameoverScreen.SetActive(true);
            StartCoroutine(reStartScene());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            //gameoverScreen.SetActive(true);
            StartCoroutine(reStartScene());
        }
    }

    

    IEnumerator reStartScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(currentScene);
    }
}
