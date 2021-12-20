using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBgGameImg : MonoBehaviour
{
    bool MaintainWidth = true;
    Vector3 CameraPos;
    float DefaultWidth;
    float DefaultHeight;
    //public GameObject backgroundImage;
    //public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        //scaleBackgroundImageFitScreenSize();
        CameraPos = Camera.main.transform.position;

        DefaultWidth = Camera.main.orthographicSize * 0.5625f;
        DefaultHeight = Camera.main.orthographicSize;
       if (MaintainWidth)
            {
                Camera.main.orthographicSize = DefaultWidth / Camera.main.aspect;
            }
        Camera.main.transform.position = new Vector3(CameraPos.x, -1 * (DefaultHeight - Camera.main.orthographicSize), CameraPos.z);
    }

    
    /*private void scaleBackgroundImageFitScreenSize()
    {
        //Step 1: Get Device Screen Aspect
        Vector2 deviceScreenResolution = new Vector2(Screen.width, Screen.height);
        print(deviceScreenResolution);

        float scrHeight = Screen.height;
        float scrWidth = Screen.width;

        float DEVICE_SCREEN_ASPECT = scrWidth / scrHeight;
        print("DEVCE_SCREEN_ASPECT: " + DEVICE_SCREEN_ASPECT.ToString());

        //Step 2: Set Main Camera's Aspect = Device's Aspect
        mainCam.aspect = DEVICE_SCREEN_ASPECT;

        //Step 3: Scale Background Image to fit with Camera's Size
        float camHeight = 100.0f * mainCam.orthographicSize * 2.0f;
        float camWidth = camHeight * DEVICE_SCREEN_ASPECT;
        print("camHeight: " + camHeight.ToString());
        print("camWidth: " + camWidth.ToString());

        //Get Background Image Size;
        SpriteRenderer backgroundImageSR = backgroundImage.GetComponent<SpriteRenderer>();
        float bgImgH = backgroundImageSR.sprite.rect.height;
        float bgImgW = backgroundImageSR.sprite.rect.width;
        print("bgImgH: " + bgImgH.ToString());
        print("bgImgW: " + bgImgW.ToString());

        //Calculate Ratio of Scaling
        float bgImg_scale_ratio_Height = camHeight / bgImgH;
        float bgImg_scale_ratio_Width = camWidth / bgImgH;

        backgroundImage.transform.localScale = new Vector3(bgImg_scale_ratio_Width, bgImg_scale_ratio_Height, 1);
    }*/
}
