using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour

{

    [SerializeField] private float moveSpeed = 2.0f;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(moveSpeed, 0) * Time.deltaTime);  
    }
}
