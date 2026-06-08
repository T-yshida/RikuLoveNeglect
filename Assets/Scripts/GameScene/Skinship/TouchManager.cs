using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchManager : MonoBehaviour
{
    [SerializeField] OnTalk onTalk;

    private int touchCount;
    private int desCount;
    private int healCount;

    public enum Point 
    {
        DESIRE,
        HEAL
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        touchCount = 5;
        desCount = 0;
        healCount = 0;
    }

    public void OnTouch(Point tPoint)
    {
        onTalk.Talk(tPoint);
        Debug.Log(tPoint);
        touchCount--;
        switch (tPoint)
        {
            case Point.DESIRE:
                desCount++;
                break;
            case Point.HEAL:
                healCount++; 
                break;
        }

        if(touchCount == 0)
        {
            if(desCount > healCount)
            {
                //ƒ}ƒO
                //‚¢‚­‚Â‚©‘«‚·
                GameManager.loveMeter++;
            }
            else if(desCount < healCount)
            {
                //ƒCƒ„‚µ
                //‚¢‚­‚Â‚©ˆø‚­
                GameManager.illMeter--;
            }
        }
    }
}
