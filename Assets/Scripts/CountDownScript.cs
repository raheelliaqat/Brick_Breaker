using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 10f;
    [SerializeField] Text CountdownText;

    public void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    public void Update()
    {

        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;

        }

    }
}