using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float time;
    public float bestTime;
    public Text countText;
    public Text winText;
    public Text TimeText;
    public Text BestTimeText;
    private Rigidbody rb;
    private int count;
    public int pickUp;
    private bool isGameClear = false;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }
    void Update()
    {
        bestTime = PlayerPrefs.GetFloat("TIMER", 100);
        if (count < pickUp)
        {
            time += Time.deltaTime;
            TimeText.text = "Time : " + time.ToString("F2");
        }

        if(bestTime < 100)
        {
            BestTimeText.text = "Best time " + bestTime.ToString("F2");
        }
        else
        {
            BestTimeText.text = "Best time ";
        }

        if (isGameClear && Input.GetButtonDown("Submit"))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MiniGame");
        }
    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Pick Up")) 
       {
           other.gameObject.SetActive(false);
           count = count + 1;
           SetCountText ();
       }
    }

    void SetCountText ()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= pickUp)
        {
            isGameClear = true;
            winText.text = "You Win!";
            Time.timeScale = 0f;
            if(bestTime > time )
            {
                bestTime = time;
                PlayerPrefs.SetFloat("TIMER", bestTime);
                PlayerPrefs.Save();
            }
        }
    }
}
