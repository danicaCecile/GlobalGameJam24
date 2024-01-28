using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public float delay = 0f;

    public void DeactivateScreen(GameObject screen)
    {
        StartCoroutine(Activate(false, screen));
    }

    public void ActivateScreen(GameObject screen)
    {
        StartCoroutine(Activate(true, screen));
    }

    private IEnumerator Activate(bool isActive, GameObject screen)
    {
        yield return new WaitForSeconds(delay);
        screen.SetActive(isActive);
    }
}
