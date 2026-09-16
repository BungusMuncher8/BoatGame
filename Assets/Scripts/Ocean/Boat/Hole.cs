using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private float sizeMin, sizeMax;
    public int index;

    private void Start()
     {
        float size = Random.Range(sizeMin,sizeMax);
        transform.localScale = new Vector2(size,size);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.tag == "Player")
        {
           
        }
    }
}
