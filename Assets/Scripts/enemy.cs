using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public GameController gc;
    public NavMeshAgent nav;
    public Transform Objetivo;
    public float hp;
    public float dmg;
    public float moveVel;

    private void Start() {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        transform.SetParent(gc.gameObject.transform.GetChild(1));
        gc.enemiesSpawned.Add(this.gameObject);
        creacion();
        Objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        nav = gameObject.GetComponent<NavMeshAgent>();
        nav.speed = moveVel;
        nav.destination = Objetivo.position;
    }
    private void creacion () {
        hp *= gc.enemiesHPMul;
        dmg *= gc.enemiesDMGMul;
        moveVel *= gc.enemiesVelMul;
    }
}
