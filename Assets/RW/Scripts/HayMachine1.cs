using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine1 : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22; // trenimiz dışarı çıkmasın diye 
    //aşağıda ki özellikler samanların koyunları patlatması için
    public GameObject hayBalePrefab; // hay Balya prefabrikine referans.
    public Transform haySpawnpoint; // samanın vurulacağı nokta
    public float shootInterval; // çekimler arasında en küçük süre. Bu, oynatıcının çekim düğmesini spam yapmasını ve ekranı saman balyası ile doldurmasını önler
    private float shootTimer; // makinenin çekim yapıp yapamayacağını takip etmek için sürekli azalan bir zamanlayıcı.



    // Start is called before the first frame update
    void Start()
    {
    
    }

    void Update()
    {
        UpdateMovement(); //methodu burada çağırıyoruz//
        UpdateShooting();
    }

    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // yatay olarak hareket giriş alıyoruz

        if ( horizontalInput < 0 && transform.position.x > -horizontalBoundary) //sola harekette değerin sadce negatif olduğu  beklenmez ayrica negatif olduğu için değerin büyük olması gerekir
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime );
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary ) //sağa harekette pozitif olması gerekir alanda kalması için
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime );
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity); //samanı referans alarak
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime; // 1

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) // 2
        {
            shootTimer = shootInterval; // 3
            ShootHay(); // 4
        }
    }

}
