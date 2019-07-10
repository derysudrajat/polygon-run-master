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
    public int moveSpeed;
    public int rotationSpeed;
    public int jumpHeight;
    public float jumpSpeed;
    public int mCoin;
    public int mHealth;
    public Text txtHealth;
    public Text txtCoin;    
    [SerializeField] private Transform player;
    [SerializeField] private Transform origTrans;
    [SerializeField] private string namaScene;
    Rigidbody rb;    

    void Start()
    {
        rb = GetComponent<Rigidbody>();        
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
        if (col.gameObject.tag == "DoorFinish")
        {
            print("Object: DoorFinish");
        }
        if (col.gameObject.tag == "WinFlag")
        {
            SceneManager.LoadScene(namaScene);
            print("Object: WinFlag");
        }
        if (col.gameObject.tag == "Coin")
        {
            GameObject mCoin = col.gameObject;
            mCoin.SetActive(false);
            this.mCoin += 1;
            txtCoin.text = this.mCoin.ToString();
        }        
        if (col.gameObject.tag=="WaterFall")
        {
            if (mHealth <=1)
            {
                txtHealth.text = "Die";
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
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        Vector3 rotation = transform.eulerAngles;
        rotation.y += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // Standart Left-/Right Arrows and A & D Keys
        transform.eulerAngles = rotation;
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
        if (gameObject.tag == "Coin")
        {
            print("Coin uuuuuu");
        }
        
    }
}
