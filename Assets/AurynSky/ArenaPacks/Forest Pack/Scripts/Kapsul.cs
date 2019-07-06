using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kapsul : MonoBehaviour
{
    // Start is called before the first frame update
    public int moveSpeed;
    public int rotationSpeed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        Vector3 rotation = transform.eulerAngles;
        rotation.y += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // Standart Left-/Right Arrows and A & D Keys
        transform.eulerAngles = rotation;
    }
}
