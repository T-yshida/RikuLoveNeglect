using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneBGM : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClip;
    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, audioClip.Count);

        AudioManager.Instance.PlayBGM(audioClip[randomIndex]);
    }
}
