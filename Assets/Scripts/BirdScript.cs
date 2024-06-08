using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rigidBody; // Reference на компонент того же ГО, на якому скрипт
    void Start()
    {
        Debug.Log("BirdScript Start");
        // пошук компонента та одержання посилання на нього 
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, 500));
        }
    }
}
