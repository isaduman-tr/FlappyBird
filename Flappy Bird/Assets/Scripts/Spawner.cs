using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Birdy BirdScript;
    public GameObject Borular;
    public float height;
    public float time;
    private void Start()
    {
        StartCoroutine(SpawnObject(time));
    }
    public IEnumerator SpawnObject(float time)
    {
        while (!BirdScript.ÝsDead) 
        {
            Instantiate(Borular, new Vector3(2, UnityEngine.Random.Range(-height, height),0), quaternion.identity);
            yield return new WaitForSeconds(time);
        }

       
    }
}
