using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class tower : MonoBehaviour
{
    public GameController gc;
    public float DamageBase; //en <tower>
    public float ATKRange; //en <flecha> llamado en <tower>
    public float ATKSpeed; //en <flecha>
    public float DoubleChance; //en <flecha>
    public float CriticalChance; //en <flecha>
    public float CriticalMultiplier; //en <flecha>

    public float HP; //en <tower>
    public float HPMax; //en <tower>
    public float HPRegen; //en <tower>
    public float DefenceBase; //en <tower>
    public float TowerDamage; //en <tower>
    public float VampireChance; //en <bullet>
    public float VampireValue; //en <bullet>

    public float MP;    //moneda del juego
    public float MPHour; //en <tower>
    public float MPKill; //en <tower>
    public float velChargeBarrier; //en <tower>
    public float manaBarrier; //en <tower>
    public float ManaBarrier; //en <tower>
    
    //esto lo dejo para despues todavia no se como implementarlos ya que no tengo planteado el como van a funcionar, si en las flechas como el vampirismo o como zona alrededor de la tower
    public float Poison;
    public float Slowness;

    public int[] bulletCount;
    public int selectBullet;

    public GameObject vidaImage;
    public GameObject barrierImage;
    public TMP_Text ManaTotal;

    public Flecha colDisparo;
    public float[] time;
    private void Start()
    {
        time = new float[2];
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        colDisparo = GameObject.FindGameObjectWithTag("PuntoDisparo").GetComponent<Flecha>();
        defaultSelect();
        time[0] = velChargeBarrier;
        time[1] = HPRegen;
    }

    private void Update() {
        ManaTotal.text = MP + "";
        if(manaBarrier < 0){
            manaBarrier = 0;
        }
        //ATKRange
        colDisparo.Reajuste();

        //HPRegen
        time[1] -= 1 * Time.deltaTime;
        if(time[1] <= 0 && HP < HPMax){
            HP += 1;
            time[1] = HPRegen;
        } else if(HP > HPMax){
            HP = HPMax;
        }
        //recarga barrera
        if (MP != 0 && manaBarrier < ManaBarrier){
            time[0] -= 1 * Time.deltaTime;
            if(time[0] <= 0){
                RecargarBarrera(); // cada 5 segundo consume 1 de mana para sumar 1 de barrera
                time[0] = velChargeBarrier;
            }
        }
    }

    private void RecargarBarrera () {
        if(manaBarrier < ManaBarrier){
            MP -= 1;
            manaBarrier += 1;
        } else {
            manaBarrier = ManaBarrier;
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy"){
            enemy e = other.gameObject.GetComponent<enemy>();
            if(manaBarrier == 0){
                HP -= calculoDEF(e.dmg);
            } else {
                manaBarrier -= e.dmg;
            }
            other.gameObject.GetComponent<enemy>().hp -= TowerDamage;
            if(other.gameObject.GetComponent<enemy>().hp <= 0){
                colDisparo.enemiesClose.Remove(other.gameObject);
                gc.enemiesSpawned.Remove(other.gameObject);
                Destroy(other.gameObject);
            }
        }
    }
    private void defaultSelect () {
        bulletCount[0] = -1;
        selectBullet = 0;
        HP = HPMax;
        MP = 0;
    }

    private float calculoDEF(float oDMG){
        float nDMG = oDMG - (DefenceBase * oDMG / 100);
        return nDMG;
    }
}
