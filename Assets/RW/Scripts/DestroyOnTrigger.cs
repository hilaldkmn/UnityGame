using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string tagFilter;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) // trigger yazdık
    {
        if (other.CompareTag(tagFilter)) // eğer tanımladığım tag var ise
        {
            Destroy(gameObject); // objeyi yok et
        }
    }

}
