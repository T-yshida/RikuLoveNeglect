using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

//それぞれのキャラクターにアタッチする
public class CharactorView : MonoBehaviour
{
    [SerializeField] public string charId;
    [SerializeField] public RectTransform charRect;
    [SerializeField] public CanvasGroup charCanvasGroup;
    [SerializeField] public Image charImage;

    [SerializeField] public ImageData[] imageDatas;

    [NonSerialized] public Tween currentTween;

    public void SetSprite(int faceIdx)
    {
        charImage.sprite = imageDatas[faceIdx].image;
    }

    public void SetSprite(GameManager.imageTypeKanojo imageType)
    {
        var spriteData = imageDatas[(int)imageType].image;
        charImage.sprite = spriteData;
    }

    public void Move(Vector2 pos, float duration)
    {
        currentTween?.Kill();

        var toPosition = new Vector2(charRect.localPosition.x + pos.x, charRect.localPosition.y + pos.y);

        Debug.Log(toPosition);

        currentTween = charRect.DOAnchorPos(toPosition, duration)
            .SetEase(Ease.OutCubic);
    }

    public void Fade(float alpha, float duration)
    {
        charCanvasGroup.DOFade(alpha, duration);
    }

    public void Scale(float scale, float duration)
    {
        var toScale = charRect.localScale * scale;
        charRect.DOScale(toScale, duration);
    }
}

[System.Serializable]
public class ImageData
{
    public string displayName;
    public Sprite image;
}