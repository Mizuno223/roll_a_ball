using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float time;
    public Text countText;
    public Text winText;
    public Text TimeText;
    private Rigidbody rb;
    private int count;
    public int pickUp;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }
    void Update()
    {
        if (count < pickUp)
        {
            time += Time.deltaTime;
            TimeText.text = "Time : " + time.ToString("F2");
        }
    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        if (count >= pickUp)
        {
            movement = new Vector3 (0.0f, 0.0f, 0.0f);
        }

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
            winText.text = "You Win!";
        }
    }
}
