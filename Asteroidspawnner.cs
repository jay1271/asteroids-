using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroidspawnner : MonoBehaviour
{ public float spawnrate = 2.0f;
    public float trajectoryvariance = 15.0f;
    public Asteroid asteroidprefab;
    public int spawnAmount = 5;
    public float spawndistance = 15.0f;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnrate, this.spawnrate);
    }
    private void Spawn()
    {
        for (int i=0; i< this. spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawndistance;

            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float variance = Random.Range(-this.trajectoryvariance, this.trajectoryvariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidprefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minsize, asteroid.maxsize);
            Vector2 trajectory = rotation * -spawnDirection;
            asteroid.Path(trajectory);


        }


    }
   
}
