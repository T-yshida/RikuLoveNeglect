using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;

    private void Start()
    {
        AudioManager.Instance.PlayBGM(audioClip);
    }
}
