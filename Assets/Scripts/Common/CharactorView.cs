using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//それぞれのキャラクターにアタッチする
public class CharactorView : MonoBehaviour
{
    [SerializeField] public string charId;
    [SerializeField] public RectTransform charRect;
    [SerializeField] public CanvasGroup charCanvasGroup;
    [SerializeField] public Image charImage;

    [SerializeField] public ImageData[] imageDatas;

    [NonSerialized] public Tween currentTween;

    public void SetSprite(string sprite)
    {
        var spriteName = (ImageData.imageType)Enum.Parse(typeof(ImageData.imageType), sprite);
        var spriteData = imageDatas.FirstOrDefault(x => x.type == spriteName).image;
        charImage.sprite = spriteData;
        
    }

    public void Move(Vector2 pos, float duration = 0.3f)
    {
        currentTween?.Kill();

        currentTween = charRect.DOAnchorPos(pos, duration)
            .SetEase(Ease.OutCubic);
    }

    public void Fade(float alpha, float duration = 0.3f)
    {
        charCanvasGroup.DOFade(alpha, duration);
    }

    public void Scale(float scale, float duration = 0.3f)
    {
        charRect.DOScale(scale, duration);
    }
}

[System.Serializable]
public class ImageData
{
    public enum imageType
    {
        NORMAL,
        SMIRE,
        CRY,
        TROUBLE,
        ANGRY,
        sSMIRE,
        SURPRISE
    }

    public imageType type;
    public Sprite image;
}