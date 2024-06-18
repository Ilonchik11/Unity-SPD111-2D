using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
