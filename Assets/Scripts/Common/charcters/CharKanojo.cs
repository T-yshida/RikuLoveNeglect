using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharKanojo : CharactorView
{

    new public void SetSprite(GameManager.imageTypeKanojo imageType)
    {
        var spriteData = imageDatas[(int)imageType].image;
        charImage.sprite = spriteData;
    }
    
    public enum imageTypeKanojo
    {
        NORMAL,
        SMILE,
        CRY,
        TROUBLE,
        ANGRY,
        sSMILE,
        SURPRISE,
        SHY,
        SAD,
        HEART,
        SERIOUS,
        JITOME,
        WINK,
        MADNESS,
        YNORMAL,
        YSERIOUS,
        YHEART,
        YHSMILE,
        YJITOME,
        YANGRY
    }
}


///
///  TODO : 表情差分(enum)を合わせる作業
///　TODO : CharactorViewManager.charEnumSelectを完成させる
///　        キャラごとにenumが違うのでキャラクターIDでswitchにかけて表情のidxを求めてそれを返すメソッド
/// ///
