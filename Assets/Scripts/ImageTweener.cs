using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ImageTweener : MonoBehaviour
{
    public bool tweenOnAwake;

    [Header("Color")]
    public bool tweenColor;
    public Gradient gradient;
    public float colorSpeed;

    [Header("Rotation")]
    public bool shakeRotation;
    public Vector3 shakeAngles = Vector3.forward * 20;
    public float shakeSpeed = .7f;
    public int shakeVibration = 10;
    [Range(0, 1)]
    public float shakeElasticity = 1;

    [Header("Tween Targets")]
    public Image image;
    public TextMeshProUGUI text;

    private void Awake()
    {
        if (tweenOnAwake)
        {
            StartTweening();
        }
    }

    public void StartTweening()
    {
        if (tweenColor)
        {
            if (image)
            {
                image.DOGradientColor(gradient, colorSpeed).SetLoops(-1);
            }
            if (text)
            {
                text.fontMaterial.DOGradientColor(gradient, "_FaceColor", colorSpeed).SetLoops(-1);
            }
        }

        if (shakeRotation)
        {
            image.rectTransform.DOPunchRotation(shakeAngles, shakeSpeed, shakeVibration, shakeElasticity).SetLoops(-1);
        }
    }

    public void HandlePointerEnter()
    {
        image.rectTransform.DOScale(Vector3.one * 1.5f, .2f);
    }

    public void HandlePointerExit()
    {
        image.rectTransform.DOScale(Vector3.one, .2f);
    }

    public void HandlePointerDown()
    {
        image.rectTransform.DOPunchScale(Vector3.one * 2f, .2f, 5, 1);
    }
}