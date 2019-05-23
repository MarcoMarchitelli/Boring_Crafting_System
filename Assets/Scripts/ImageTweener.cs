using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ImageTweener : MonoBehaviour
{
    public bool tweenOnAwake;
    public bool isCustomButton;

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

    bool active;

    Tween imageColor, textColor, imageRotationShake, imageScaleUp, imageScaleDown, imageScaleHuge;

    private void Awake()
    {
        DOTween.defaultAutoPlay = AutoPlay.None;
        DOTween.defaultAutoKill = false;

        InitTweens();

        if (tweenOnAwake)
            StartTweening();
    }

    void InitTweens()
    {
        if (image)
        {
            if (tweenColor)
            {
                imageColor = image.DOGradientColor(gradient, colorSpeed).SetLoops(-1);
                imageColor.Rewind();
            }

            if (shakeRotation)
            {
                imageRotationShake = image.rectTransform.DOPunchRotation(shakeAngles, shakeSpeed, shakeVibration, shakeElasticity).SetLoops(-1);
                imageRotationShake.Rewind();
            }

            if (isCustomButton)
            {
                imageScaleUp = image.rectTransform.DOScale(1.5f, .2f);
                imageScaleDown = image.rectTransform.DOScale(1, .2f);
                imageScaleHuge = image.rectTransform.DOScale(2f, .2f);
                imageScaleUp.Rewind();
                imageScaleDown.Rewind();
                imageScaleHuge.Rewind();
            }
        }
        if (text)
        {
            if (tweenColor)
            {
                textColor = text.fontMaterial.DOGradientColor(gradient, "_FaceColor", colorSpeed).SetLoops(-1);
                textColor.Rewind();
            }
        }
    }

    public void StartTweening()
    {
        if (tweenColor)
        {
            if (image)
            {
                imageColor.PlayForward();
            }
            if (text)
            {
                textColor.Play();
            }
        }

        if (shakeRotation)
        {
            imageRotationShake.Play();
        }
    }

    public void StopTweening()
    {
        imageColor.Rewind();
        textColor.Rewind();
        imageRotationShake.Rewind();
        imageScaleUp.Rewind();
        imageScaleDown.Rewind();
        imageScaleHuge.Rewind();
    }

    public void HandlePointerEnter()
    {
        if (active)
        {
            imageScaleUp.Rewind();
            imageScaleUp.Play();
        }
    }

    public void HandlePointerExit()
    {
        if (active)
        {
            imageScaleDown.Rewind();
            imageScaleDown.Play();
        }
    }

    public void HandlePointerDown()
    {
        if (active)
        {
            imageScaleHuge.Rewind();
            imageScaleHuge.Play();
        }
    }

    public void HandlePointerUp()
    {
        if (active)
        {
            imageScaleDown.Rewind();
            imageScaleDown.Play();
        }
    }

    public void SetActive(bool _value)
    {
        active = _value;
        if (active)
            StartTweening();
        else
            StopTweening();
    }
}