using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(ImageTweener))]
public class CustomButton : MonoBehaviour
{
    public UnityEvent onClick;

    bool active;
    bool downPressed;
    ImageTweener tweener;

    private void Awake()
    {
        tweener = GetComponent<ImageTweener>();
    }

    public void SetActive(bool _value)
    {
        active = _value;
        tweener.SetActive(active);
    }

    public void HandlePointerEnter()
    {
        if (!active)
            return;

        tweener.HandlePointerEnter();
    }

    public void HandlePointerExit()
    {
        if (!active)
            return;

        tweener.HandlePointerExit();
    }

    public void HandlePointerDown()
    {
        if (!active)
            return;

        downPressed = true;
        tweener.HandlePointerDown();
    }

    public void HandlePointerUp()
    {
        if (!active)
            return;

        if (downPressed)
        {
            tweener.HandlePointerUp();

            onClick.Invoke();

            downPressed = false;
        }
    }
}