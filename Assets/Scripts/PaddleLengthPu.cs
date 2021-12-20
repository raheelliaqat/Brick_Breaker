using System.Collections;
using System.Collections.Generic;
using UnityEngine;using DentedPixel;
public class PaddleLengthPu : MonoBehaviour
{
    public GameObject Paddle;
    public int time = 10;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }

    public void DecreasePaddle()
    {
        LeanTween.scaleX(Paddle, 16, 1);
        //LeanTween.cancelAll(true);
    }

    public void IncreasePaddle(int t)
    {
        time = t;
        LeanTween.scaleX(Paddle, 30, t);
    }

    public void ResetPaddle()
    {
        LeanTween.scaleX(Paddle, 23, 1);
    }
}
