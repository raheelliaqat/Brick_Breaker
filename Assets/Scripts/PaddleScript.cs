using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleScript : MonoBehaviour
{
    //public float speed;
    public Touch touch;
    public GameManager gm;
    public Text LivesText;
    public int BallDamage = 0;
    public Transform ball;
    public AudioClip ExtraLife;
    public GameObject Bar;
    public GameObject bg;
    public Bar bar;
    public Text BallDamageText;
    public GameObject bdt;
    public GameObject Paddle;
    private Vector3 scaleChange;
    public CreateScreenColliders csc;
    public GameObject trail;
    public PaddleLengthPu plp;
    // Start is called before the first frame update
    //public float ulse;
    //public float urse;
    public void Start()
    {
        scaleChange = new Vector3(7.0f, 0.0f, 0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                horizontal = touch.deltaPosition.x;
            }


        }
        transform.Translate(Vector2.right * horizontal * Time.deltaTime);
        if (transform.position.x < csc.lse)
        {
            transform.position = new Vector2(csc.lse, transform.position.y);
        }
        if (transform.position.x > csc.rse)
        {
            transform.position = new Vector2(csc.rse , transform.position.y);
        }
        
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ExtraLife"))
        {
            gm.UpdateLives(1);
            StartCoroutine(changelivestext(other));
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(ExtraLife, transform.position);
        }
        if (other.CompareTag("BallDamage"))
        {
          
            bg.SetActive(true);
            Bar.SetActive(true);
            bar.resetbar();
            bar.AnimateBar(10);
            StopAllCoroutines();
            StartCoroutine(DamagePowerup(other));
            AudioSource.PlayClipAtPoint(ExtraLife, transform.position);
        }
        if (other.CompareTag("PaddleIncr"))
        {
            AudioSource.PlayClipAtPoint(ExtraLife, transform.position);
            Destroy(other.gameObject);
            StartCoroutine(PaddleIncrease(other));
        }
        if (other.CompareTag("PaddleDecr"))
        {
            AudioSource.PlayClipAtPoint(ExtraLife, transform.position);
            Destroy(other.gameObject);
            StartCoroutine(PaddleDecrease(other));
        }
        
    }

    
    IEnumerator PaddleIncrease(Collider2D PaddleIncr)
    {
    csc.lse = -4.65f;
    csc.rse = 4.65f;
    plp.IncreasePaddle(1);
    yield return new WaitForSeconds(10f);
    csc.lse = -5.1f;
    csc.rse =  5.1f;
    plp.ResetPaddle();
    }


    IEnumerator PaddleDecrease(Collider2D PaddleDecr)
    {
     csc.lse = -5.65f;
     csc.rse =  5.65f;
     plp.DecreasePaddle();
     yield return new WaitForSeconds(10f);
     csc.lse = -5.1f;
     csc.rse = 5.1f;
     plp.ResetPaddle();
    }
    
    IEnumerator DamagePowerup(Collider2D balldamage)
    {

        Destroy(balldamage.gameObject);
        BallDamage = BallDamage + 2;
        ball.GetComponent<SpriteRenderer>().color = new Color(1f, 0.92f, 0.016f, 1f);
        bdt.SetActive(true);
        BallDamageText.text = "Ball Damage: " + BallDamage + "X";
        trail.GetComponent<TrailRenderer>().enabled = true;
        yield return new WaitForSeconds(10f);
        trail.GetComponent<TrailRenderer>().enabled = false;
        bdt.SetActive(false);
        bg.SetActive(false);
        BallDamage = 0;
        ball.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
    }

    IEnumerator changelivestext(Collider2D ExtraLife)
    {
     
        LivesText.fontStyle = FontStyle.Bold;
        LivesText.fontSize = 50;
        yield return new WaitForSeconds(0.4f);
        LivesText.fontStyle = FontStyle.Normal;
        LivesText.fontSize = 30;
    }
}
