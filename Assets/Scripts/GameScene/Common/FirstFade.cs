using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFade : MonoBehaviour
{
    [SerializeField] FadeManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.startFade();
    }
}
