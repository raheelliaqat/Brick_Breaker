using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;
    public Transform ball;
    public Touch touch;
    public Transform powerup;
    public Transform powerup1;
    public Transform powerup2;
    public Transform powerup3;
    public PaddleScript ps;
    public AudioClip bricksound;
    public AudioClip paddlesound;
    public Bar bar;
    public GameObject Bar;
    public GameObject bg;
    public GameObject bdt;
    public GameObject trail;
    public PaddleLengthPu plp;
    public CreateScreenColliders csc;
    // public BrickScript bs;
    // int n = 0;
    // Start is called before the first frame update
    void Start()
    {
  
        rb = GetComponent<Rigidbody2D> ();
        trail.GetComponent<TrailRenderer>().enabled = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if(gm.gameOver)
        {
            transform.position = paddle.position;
            transform.position = ball.position;

            return;
        }
        if(!inPlay)
        {
            transform.position = paddle.position;
            transform.position = ball.position;
           
        }
        if (Input.touchCount >= 1 && !inPlay)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                inPlay = true;
                rb.AddForce(Vector2.up * speed);
            }
            
        }
       // n = ps.BallDamage;
        //Debug.Log("Ball Damage: " + n);
    }
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Bottom"))
            {
                //Debug.Log("Ball hit the bottom of the Screen");
                rb.velocity = Vector2.zero;
                inPlay = false;
                gm.UpdateLives(-1);
                bar.resetbar();
                bg.SetActive(false);
                Bar.SetActive(true);
                bdt.SetActive(false);
                ps.BallDamage = 0;
                plp.ResetPaddle();
                trail.GetComponent<TrailRenderer>().enabled = false;
                ps.ball.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
                csc.lse = -5.1f;
                csc.rse = 5.1f;
        }
          
        }

    void OnCollisionEnter2D(Collision2D other)
    {
          
            if (other.transform.CompareTag("brick"))
            {

                AudioSource.PlayClipAtPoint(bricksound, transform.position);
                BrickScript brickScript = other.gameObject.GetComponent<BrickScript>();
            if (ps.BallDamage == 2)                                                  //Make this commented piece of code 
                                                                                    // efficient later
            {
                brickScript.hitsToBreak = brickScript.hitsToBreak - 1;
            }

            if (ps.BallDamage >=4)
            {
                brickScript.hitsToBreak = brickScript.hitsToBreak - 3;
            }

            if (brickScript.hitsToBreak < 0)
            {
                brickScript.hitsToBreak = 0;                
            }                                                                       //
            if (brickScript.hitsToBreak > 1)
                {
                    brickScript.BreakBrick();

                }

                else
                {
                    int randChance = Random.Range(1, 101);
                    if (randChance < 50)
                    {
                        int randChance1 = Random.Range(1, 101);
                    
                        if (randChance1 <=25)
                        {
                            Instantiate(powerup, other.transform.position, other.transform.rotation);
                        }
                        else
                        if(randChance1>25 && randChance1<=50)
                        {
                            Instantiate(powerup1, other.transform.position, other.transform.rotation);

                        }
                        
                        else
                        if(randChance1 > 50 && randChance1 <= 75)
                        {
                        Instantiate(powerup2, other.transform.position, other.transform.rotation);
                        }
                        else
                        if(randChance1 > 75 && randChance1 <= 100)
                        {
                        Instantiate(powerup3, other.transform.position, other.transform.rotation);
                        }


                    }
                    Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
                    Destroy(newExplosion.gameObject, 1.5f);
                    gm.UpdateScore(brickScript.points);
                    gm.UpdateNumberOfBricks();
                    Destroy(other.gameObject);
                }
            }
        if (inPlay)
        {
            if (other.transform.CompareTag("Paddle"))
            {
                AudioSource.PlayClipAtPoint(paddlesound, transform.position);
            }
        }
    }
}
