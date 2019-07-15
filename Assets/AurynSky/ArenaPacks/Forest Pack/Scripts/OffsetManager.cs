using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer rend;
    public float offset;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

    

    
}
