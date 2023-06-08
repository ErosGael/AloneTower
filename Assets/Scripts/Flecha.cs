using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public tower tower;
    public List<GameObject> enemiesClose;

    public float[] radiusSize;
    public GameObject[] bullet;
    public float time;

    
    private void Start() {
        tower = GameObject.FindGameObjectWithTag("Player").GetComponent<tower>();
        gameObject.GetComponent<CapsuleCollider>().radius = radiusSize[0];
        tower.ATKRange = radiusSize[0];
    }

    public void Reajuste () {
        gameObject.GetComponent<CapsuleCollider>().radius = tower.ATKRange;
    }

    private void Update() {
        time -= Time.deltaTime * 1;
        if (time <= 0){
            if(enemiesClose.Count != 0){
                var random = Random.Range(0,100);
                bulletShot(tower.selectBullet);
                if (random <= tower.DoubleChance){
                    bulletShot(tower.selectBullet);
                }
            }
            time =  1 / tower.ATKSpeed;
        }
    }
    public void OnTriggerEnter (Collider other) {
        if(other.tag == "Enemy"){
            enemiesClose.Add(other.gameObject);
        }
    }

    private void bulletShot (int sb) {
        
        if (tower.bulletCount[sb] == 0){
            tower.selectBullet = 0;
            sb = 0;
        }
        Instantiate(bullet[sb], this.transform);
        if(sb != 0){
            tower.bulletCount[sb] -= 1;
        }
    }

}
