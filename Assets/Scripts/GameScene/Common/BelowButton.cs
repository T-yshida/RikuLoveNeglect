using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelowButton : MonoBehaviour
{
    [SerializeField] public GameObject screenPanel;
    public void OnClick(GameObject gameObject)
    {
        screenPanel.SetActive(false);
        screenPanel = gameObject;
        gameObject.SetActive(true);
    }
}
