using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialRotator : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * moveHorizontal * speed * Time.deltaTime);
        transform.Rotate(Vector3.left* moveVertical * speed * Time.deltaTime);
    }
}
