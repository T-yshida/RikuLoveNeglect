using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameSceneChange : MonoBehaviour
{
    [SerializeField] FadeManager fadeManager;

    private void Start()
    {
        fadeManager = GameObject.Find("FadeObject").GetComponent<FadeManager>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // UIÇÃè„Ç»ÇÁñ≥éã
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            fadeManager.LoadSceneWithFade("GameScene");
        }
    }
}
