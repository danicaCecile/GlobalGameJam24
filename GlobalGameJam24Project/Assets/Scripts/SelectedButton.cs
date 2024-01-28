using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedButton : MonoBehaviour
{
    public List<Image> buttons = new List<Image>();
    public Sprite activeSprite;
    public Sprite inactiveSprite;

    public void ActivateButton(Image button)
    {
        foreach(Image oneButton in buttons)
        {
            oneButton.sprite = inactiveSprite;
        }

        button.sprite = activeSprite;
    }

    public void ResetButtons()
    {
        foreach(Image oneButton in buttons)
        {
            oneButton.sprite = inactiveSprite;
        }
    }
}
