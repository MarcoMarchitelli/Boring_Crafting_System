using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class Menu : MonoBehaviour
{
    public UnityEvent onOpenStart, onOpenEnd, OnCloseEnd;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        Open();
    }

    private void OnDisable()
    {
        Close();
    }

    public void Open()
    {
        onOpenStart.Invoke();
        image.rectTransform.localScale = Vector3.zero;
        image.rectTransform.DOScale(1, .5f).onComplete += () => { onOpenEnd.Invoke(); };
    }

    public void Close()
    {
        image.rectTransform.DOScale(0, .5f).onComplete += () => { OnCloseEnd.Invoke(); };
    }

}