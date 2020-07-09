using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotationSpeed; //dönme hızını tanımlayoruz
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime); //dışarıdan alacağımız dönme hızını samiyede kaç derece olacağını belirliyoruz
    }
}
