using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bullet : MonoBehaviour
{
    public GameController gc;
    public tower tower;
    public Flecha colDisparo;
    public float dmg;
    public Transform objetivo;
    private Rigidbody rb;
    private bool vampire;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        tower = GameObject.FindGameObjectWithTag("Player").GetComponent<tower>();
        colDisparo = transform.parent.GetComponent<Flecha>();
        objetivo = colDisparo.enemiesClose[0].transform;
        Vector3 direccion = (objetivo.position - transform.position).normalized;
        Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionDeseada, 10000000);
        //chanse de critico y asignacion de daño si es verdadero
        var random = Random.Range(0,100);
        if (random <= tower.CriticalChance){
            dmg *= tower.CriticalMultiplier;
        }
        //robo de vida
        var vampireChance = Random.Range(0,100);
        if(vampireChance <= tower.VampireChance){
            vampire = true;
        }
    }

    private void Update () {
        if(objetivo != null){
            Vector3 direccionAdelante = transform.forward;
            rb.AddForce(direccionAdelante * 1000f, ForceMode.Acceleration);
        } else {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy"){
            enemy e = other.gameObject.GetComponent<enemy>();
            e.hp -= dmg + tower.DamageBase;
            if(vampire){
                tower.HP += tower.VampireValue;
            }
            if(e.hp <= 0){
                gc.enemiesSpawned.Remove(other.gameObject);
                colDisparo.enemiesClose.Remove(other.gameObject);
                Destroy(other.gameObject);
                tower.MP += tower.MPKill;
            }
            Destroy(this.gameObject);
        }
        if (other.tag == "suelo"){
            Destroy(this.gameObject);
        }
        
    }
}
