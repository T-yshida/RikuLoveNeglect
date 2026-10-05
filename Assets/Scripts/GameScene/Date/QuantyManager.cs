using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuantyManager : MonoBehaviour
{
    [SerializeField] Text quantyText;

    private void OnEnable()
    {
        quantyText.text = GameManager.restDate.ToString() + "/2";
    }
}
