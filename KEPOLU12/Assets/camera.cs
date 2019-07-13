using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    public int rotationSpeed;    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 rotation = transform.eulerAngles;
        rotation.y += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; // Standart Left-/Right Arrows and A & D Keys
        transform.eulerAngles = rotation;
    }
}
