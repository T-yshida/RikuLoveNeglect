using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChildTouchManager : MonoBehaviour
{
    //先祖スクリプト
    [SerializeField] TouchManager touchManager;
    [SerializeField] TouchManager.Point point;

    private void Start()
    {
        //親の親から取ってくる
        touchManager = transform.parent.parent.gameObject.GetComponent<TouchManager>();
    }

    //event trigger
    public void OnTouch()
    {
        touchManager.OnTouch(point);
    }
}
