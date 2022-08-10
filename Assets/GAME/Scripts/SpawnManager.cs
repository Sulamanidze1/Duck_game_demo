using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{ 
[SerializeField] Transform []spawnPointForBuskets;
[SerializeField] GameObject[]busketsPrefab;
private List<int> randomNumberList = new List<int>();
private int rnd;
[SerializeField] Transform []spawnPointForDucks;
[SerializeField] GameObject[]duckPrefab;
 AudioManager audiomanager;




    void Start()
    {
        GenerateRandonNumber();
        StartCoroutine(CouritineForInstantiateBuskets());
        StartCoroutine(CouritineForInstantiateDucks());
        audiomanager=FindObjectOfType<AudioManager>();
        
    }


    void GenerateRandonNumber()
    { 
        while (randomNumberList.Count<3)
       {
        rnd=Random.Range(0,3);
         if(!randomNumberList.Contains(rnd))
        { 
            randomNumberList.Add(rnd);
        }
      } 
    }
 void InstantiateBuskets()
 {
     for(int i=0; i<3;i++)
     {
         Instantiate(busketsPrefab[randomNumberList[i]], spawnPointForBuskets[i].position,Quaternion.identity);
     }

 }
 

 IEnumerator CouritineForInstantiateBuskets()
 {
  yield return new WaitForSeconds(2);
  InstantiateBuskets();

 }
 

void InstantiateDucks()
 {
     for(int i=0; i<3;i++)
     {
         Instantiate(duckPrefab[randomNumberList[i]], spawnPointForDucks[i].position,Quaternion.identity);
     }

 }

IEnumerator CouritineForInstantiateDucks()
 {
  yield return new WaitForSeconds(3);
  InstantiateDucks();
  audiomanager.PlaySound(1);

 }




 }





