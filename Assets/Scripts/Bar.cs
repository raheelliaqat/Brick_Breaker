using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    public int time =10;
    // Start is called before the first frame update
    public void resetbar()
    {
        LeanTween.scaleX(bar, 1, 0);
        LeanTween.cancelAll(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnimateBar(int t)
    {
        time = t;
        LeanTween.scaleX(bar, 0, t);
    }
}
