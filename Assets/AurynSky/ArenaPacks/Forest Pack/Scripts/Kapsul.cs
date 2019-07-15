using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kapsul : MonoBehaviour
{
    // Start is called before the first frame update    
    public bool isGrounded;
    public bool isLadder;
    public float moveSpeed;
    public float rotationSpeed;
    public int jumpHeight;
    public float jumpSpeed;

    public int targetCoin;

    public int mCoin;
    public int mHealth;

    public float totalTime; //3 minutes
    public Text timer;

    private bool isnotover = false;

    public Text txtHealth;
    public Text txtCoin;        

    [SerializeField] private Transform player;
    [SerializeField] private Transform origTrans;
    [SerializeField] private string namaScene;    
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject nextStage;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject timUp;

    Rigidbody rb;
    public float scrollSpeed = 0.5F;
    public Renderer rend;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
            print("Object: Ground");
        }
        if (col.gameObject.tag == "Ladder")
        {
            isLadder = true;
            print("Object: Ladder");
        }
        if (col.gameObject.tag == "DoorStart")
        {
            print("Object: DoorStart");
        }
        if (col.gameObject.tag == "Hurt")
        {
            float force = 3;            
            Vector3 dir = col.contacts[0].point - transform.position;            
            dir = -dir.normalized;
            rb.AddForce(new Vector3(0, jumpHeight, force) * jumpSpeed, ForceMode.Impulse);            
            if (mHealth <= 1)
            {
                txtHealth.text = "0";
                gameOver.SetActive(true);
                isnotover = false;
            }
            else
            {
                mHealth -= 1;
                txtHealth.text = mHealth.ToString();
            }            


        }
        if (col.gameObject.tag == "DoorFinish")
        {
            print("Object: DoorFinish");
        }
        if (col.gameObject.tag == "WinFlag")
        {            
            if (mCoin == targetCoin)
            {
                nextStage.SetActive(true);
                isnotover = false;
            }
            else
            {
                print("Object: Please Collect All Coin");
            }
            
        }
        if (col.gameObject.tag == "Coin")
        {
            GameObject mCoin = col.gameObject;
            mCoin.SetActive(false);
            this.mCoin += 1;
            txtCoin.text = this.mCoin.ToString()+" / "+this.targetCoin.ToString();
        }        
        if (col.gameObject.tag=="WaterFall")
        {
            if (mHealth <=1)
            {
                txtHealth.text = "0";
                gameOver.SetActive(true);
                isnotover = false;
            }
            else
            {
                mHealth -= 1;
                txtHealth.text = mHealth.ToString();
            }
            player.transform.position = origTrans.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timUp.active)
        {
            isnotover = false;
            timer.text = "00:00";
        }
        if (mainPanel.active)
        {
           if(timUp.active||nextStage.active||gameOver.active)
            {
                isnotover = false;
            }
            else
            {
                isnotover = true;
            }            
        }        
        if (isnotover)
        {
            transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
            Vector3 rotation = transform.eulerAngles;
            rotation.y += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // Standart Left-/Right Arrows and A & D Keys
            transform.eulerAngles = rotation;
            float offset = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
            if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || isLadder))
            {
                rb.AddForce(new Vector3(0, jumpHeight, 0) * jumpSpeed, ForceMode.Impulse);
                isGrounded = false;
                if (isLadder)
                {
                    isLadder = false;
                }
            }
            if (Input.GetAxis("Mouse X") < 0)
            {
                //Code for action on mouse moving left
                print("Mouse moved left");
            }
            if (Input.GetAxis("Mouse X") > 0)
            {
                //Code for action on mouse moving right
                print("Mouse moved right");
            }

            if (totalTime > 0)
            {
                totalTime -= Time.deltaTime;
                UpdateLevelTimer(totalTime);
            }
            else
            {
                timer.text = "00:00";
                timUp.SetActive(true);                
            }
        }
    }
    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
