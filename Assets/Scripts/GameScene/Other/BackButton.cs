using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void OnClick(GameObject obj)
    {
        obj.SetActive(false);
    }
}
