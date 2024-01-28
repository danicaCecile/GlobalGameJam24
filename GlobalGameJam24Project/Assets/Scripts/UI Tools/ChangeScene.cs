using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public float delay = 0f;

    public void LoadScene(string sceneName) {
        StartCoroutine(SwapSceneWithDelay(sceneName));
    }

    private IEnumerator SwapSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
