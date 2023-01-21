using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Move MoveScript;
    public GameObject SpikeHead;
    public Vector2 height;
    public float time;

    public void Start(){

    StartCoroutine(SpawnObject(time));//time s�resinde bir rutinde obje spawn et

    }

    public IEnumerator SpawnObject(float time){

    while (!MoveScript.isDead)//e�er karakter �l� de�ilse
    {
        Instantiate (SpikeHead , new Vector3 (1 , Random.Range(height.x , height.y), 0), Quaternion.identity);//bu aral�kta spike head objesi

        yield return new WaitForSeconds(time);

    }
    }
}
