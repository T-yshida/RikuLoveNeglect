using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    //https://qiita.com/AzureBlue/items/f88342bbba3f5d67d230
    [SerializeField] private Camera camera_;        // ‘ÎÛ‚Ì¶Ò×
    [SerializeField] private Vector2 aspectVec_ = new Vector2(16, 9);    // QÆ‰ğ‘œ“x
    [SerializeField] private float CameraSize = 6;      // ‰æ‘œ‚ÌPixelPerUnit
    private float currentAspect_ = 0.0f;            // Œ»İ‚Ì±½Íß¸Ä”ä

    private void Start()
    {
        if (!camera_) camera_ = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Screen.width * aspectVec_.y < Screen.height * aspectVec_.x) currentAspect_ = 1;
        else currentAspect_ = 0;
        // ¶Ò×»²½Ş‚Ì’²®
        camera_.orthographicSize = CameraSize;

        // ËŞ­°Îß°Ä‚Ì’²®
        float baseAspect = aspectVec_.y / aspectVec_.x;     // Šî€‚Ì±½Íß¸Ä”ä

        if (baseAspect <= currentAspect_)
        {
            // ‰æ–Ê‚ªc‚É’·‚¢ê‡
            float bgScale = aspectVec_.x / Screen.width;

            // viewportRect‚Ìc•
            float tmpHeight = aspectVec_.y / (Screen.height * bgScale);

            // viewportRect‚ğİ’è
            camera_.rect =
             new Rect(0.0f, (1.0f - tmpHeight) / 2, 1.0f, tmpHeight);
        }
        else
        {
            // ‰æ–Ê‚ª‰¡‚É’·‚¢ê‡
            float bgScale = aspectVec_.y / Screen.height;

            // viewportRect‚Ì‰¡•
            float tmpWidth = aspectVec_.x / (Screen.width * bgScale);

            // viewportRect‚ğİ’è
            camera_.rect =
             new Rect((1.0f - tmpWidth) / 2, 0.0f, tmpWidth, 1.0f);
        }
    }
}
