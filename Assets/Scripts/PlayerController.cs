using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        Debug.Log("sag sol yapiyorummm");
        float verticalAxis = Input.GetAxis("Vertical");
        Debug.Log("s ve w kullanıyorummm");


    }
}
