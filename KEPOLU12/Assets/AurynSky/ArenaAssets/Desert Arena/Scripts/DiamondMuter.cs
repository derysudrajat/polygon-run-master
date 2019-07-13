using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondMuter : MonoBehaviour
{

    public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
          transform.Rotate(vector3.fwd * speed * Time.deltaTime);
    }
}
