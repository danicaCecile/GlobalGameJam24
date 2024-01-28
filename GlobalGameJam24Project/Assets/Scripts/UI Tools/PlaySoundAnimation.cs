using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaySoundAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator animator;
    private bool isHovering = false;

    void Start()
    {
        // Pause the animation on start
        if (animator != null)
        {
            animator.speed = 0f;
        }
        Debug.Log(animator.speed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Play the animation on mouse hover
        if (animator != null)
        {
            animator.speed = 1f;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Pause the animation when the mouse is no longer hovering
        if (animator != null)
        {
            animator.speed = 0f;
        }
        isHovering = false;
    }
}
