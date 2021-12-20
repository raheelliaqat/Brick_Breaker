using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int points;
    public int hitsToBreak;
    public Sprite hitSprite;
    public int bd = 0;

    void Awake()
    {
 
        
    }

    void Update()
    {

    }
    public void BreakBrick()
    {
        hitsToBreak--;
        GetComponent<SpriteRenderer>().sprite = hitSprite;
        if (hitsToBreak == 3)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.92f, 0.016f, 1f);
         
        }
        if (hitsToBreak == 2)
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.64f, 0.0f);
         
        }
        if (hitsToBreak == 1)
        {

            GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        
        }
    }
}