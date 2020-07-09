using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true; // koyunlar belirli sürede tekrar tekrar atılması için

    public GameObject sheepPrefab; // referans olarak koyunları al
    public List<Transform> sheepSpawnPositions = new List<Transform>(); // koyunların doğacağı konumlar
    public float timeBetweenSpawns; // tekrar atılırken belirenen süre için

    private List<GameObject> sheepList = new List<GameObject>(); //oyundaki koyunların listesi

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine()); // oyun başlar başlamaz koyunları fırlatmaya başla

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position; // koyun nereden atılacak ise rasgele random olarak belirliyor
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation); // yeni koyun olurturulur ve belirlenen rasgele konumdan at
        sheepList.Add(sheep); // yeni oluşturulan koyunu koyun listesine ekle
        sheep.GetComponent<Sheep>().SetSpawner(this); 
    }

    private IEnumerator SpawnRoutine() // belli bir dönüş için enumater oluştururuz
    {
        while (canSpawn) //yukarıda değeri bir olarak aldığımız için while 1 döngü durmadan çalışacaktır
        {
            SpawnSheep(); //yukarıda yazdığımız koyunu atma fonksiyonunu çalıştır
            yield return new WaitForSeconds(timeBetweenSpawns); // belirtilen saniye boyunca duraklat
        }
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }

    public void DestroyAllSheep()  // koyunları yok eden method
    {
        foreach (GameObject sheep in sheepList) // 1
        {
            Destroy(sheep); // 2
        }

        sheepList.Clear();
    }


}
