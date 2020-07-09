using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed; // koyunun kaç saniyede çalışacağı
    public float gotHayDestroyDelay; // 
    private bool hitByHay; // 3

    public float dropDestroyDelay; // koyunun makineyi geçtikten sonra yok olma süresi
    private Collider myCollider; // çarpışma için referans
    private Rigidbody myRigidbody; // yer çekimi referans

    private SheepSpawner sheepSpawner; // koyun atma merkeini burada çağırdık

    public float heartOffset; // 1
    public GameObject heartPrefab; // 2



    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime); //saman makinesi doğru koşması


    }


    private void HitByHay()
    {
        hitByHay = true; // 1
        runSpeed = 0; // koyunun hızını sıfırla

        Destroy(gameObject, gotHayDestroyDelay); // koyunun saniye cinsinde gecikmesi için parametre alır

        sheepSpawner.RemoveSheepFromList(gameObject);

        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);

        TweenScale tweenScale = gameObject.AddComponent<TweenScale>(); ; // 1
        tweenScale.targetScale = 0; // 2
        tweenScale.timeToReachTarget = gotHayDestroyDelay; // 3

        GameStateManager.Instance.SavedSheep();



    }

    private void OnTriggerEnter(Collider other) // 1
    {
        if (other.CompareTag("Hay") && !hitByHay) // eğer hay tag var ise yani çarmış ise
        {
            Destroy(other.gameObject); // objeyi yok et yani samanı
            HitByHay(); // 4
        }
        else if (other.CompareTag("DropSheep")) // tag dropsheep ise drop fonksiyonunu çalıştır
        {
            Drop();
        }

    }

    private void Drop()
    {
        myRigidbody.isKinematic = false; // çarpamayan koyun yer çekimi ile aşağı düşsün
        myCollider.isTrigger = false; 
        Destroy(gameObject, dropDestroyDelay); // belli bir süre geçtikten sonra objeyi yok et

        sheepSpawner.RemoveSheepFromList(gameObject);
        GameStateManager.Instance.DroppedSheep();



    }

    public void SetSpawner(SheepSpawner spawner) //koyuna düsme için burada atılma için burada çağırıyoruz
    {
        sheepSpawner = spawner;
    }




}
