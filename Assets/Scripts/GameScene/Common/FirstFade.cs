using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FadeManager.Instance.startFade();
    }
}
