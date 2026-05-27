using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBackChange : MonoBehaviour
{
    [SerializeField] BackgroundManager bgManager;

    private void OnEnable()
    {
        bgManager.BGRandomChanger();
    }
}
