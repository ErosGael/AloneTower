using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject tower;
    public List<GameObject> enemiesSpawned;
    public GameObject[] enemyTemplate;

    public float enemiesDMGMul;
    public float enemiesHPMul;
    public float enemiesVelMul;
    public float velSpawn, time;
    public int countEnemies;

    private void Start() {
        tower = GameObject.FindGameObjectWithTag("Player");
        time = velSpawn;
    }

    private void Update() {
        time -= Time.deltaTime * 1;
        if (time <= 0){
            spawn();
            time = velSpawn;
        }
    }

    private void spawn () {
        countEnemies++;
        int randomX = (Random.Range(0, 2) == 0) ? -60 : 60;
        int randomZ = (Random.Range(0, 2) == 0) ? -40 : 40;

        Instantiate(enemyTemplate[0], new Vector3(randomX, 1, randomZ), Quaternion.identity);
    }
}
