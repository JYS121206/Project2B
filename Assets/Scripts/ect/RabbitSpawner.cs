using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class RabbitSpawner : MonoBehaviour
{
    public List<GameObject> rabbitList = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SpawnRabbit()
    {
        int rabbitIdx = Random.Range(0, rabbitList.Count);
        Instantiate(rabbitList[rabbitIdx]);
    }
}
