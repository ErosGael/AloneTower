using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIButtonsTower : MonoBehaviour
{
    public string scene;
    private tower tower;
    public string tagDatos;
    public string tipoDato;
    public string uso;

    private TMP_Text textoCambiante;
    private TMP_Text manaCostText;
    public int manaCost;
    public int manaCostMul;

    public Color[] color;
    private Image cambioColor;
    public Image imageSize;

    public GameObject[] allStat;
    public GameObject[] openStat;
    public GameObject[] clouseStat;
    public bool isPorcentual;
    public float valueChange;

    private void Start() {
        if(uso == "stats+"){
            tower = GameObject.FindGameObjectWithTag(tagDatos).GetComponent<tower>();
            textoCambiante = transform.GetChild(0).GetComponent<TMP_Text>();
            manaCostText = transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
            cambioColor = transform.GetChild(1).GetComponent<Image>();
        }
        if(uso == "openAtaque" || uso == "OpenDefensa" || uso == "OpenEspecial"){
            imageSize = transform.parent.parent.GetComponent<Image>();
        }
    }

    private void Update() {
        if(uso == "openAtaque" || uso == "OpenDefensa" || uso == "OpenEspecial"){
            if(!allStat[0].activeInHierarchy && !allStat[1].activeInHierarchy && !allStat[2].activeInHierarchy){
                imageSize.color = new Color(imageSize.color.r, imageSize.color.g, imageSize.color.b, 0);
            } else {
                imageSize.color = new Color(imageSize.color.r, imageSize.color.g, imageSize.color.b, 0.50f);
            }
        }

        if(uso == "stats+"){
            textoCambiante.text =
                tipoDato == "stat-DamageBase" ? "Daño Base":
                tipoDato == "stat-ATKRange" ? "Rango Ataque":
                tipoDato == "stat-ATKSpeed" ? "Velocidad Ataque":
                tipoDato == "stat-DoubleChance" ? "Disparo Doble":
                tipoDato == "stat-CriticalChance" ? "posibilidad de Critico":
                tipoDato == "stat-CriticalMultiplier" ? "Multiplicador de Critico":
                tipoDato == "stat-HPMax" ? "Vida Maxima":
                tipoDato == "stat-HPRegen" ? "Regeneracion vida":
                tipoDato == "stat-DefenceBase" ? "Defensa":
                tipoDato == "stat-TowerDamage" ? "Daño al contacto":
                tipoDato == "stat-VampireChance" ? "robo de vida":
                tipoDato == "stat-VampireValue" ? "Multiplicador de Critico":
                tipoDato == "stat-MPHour" ? "Ganancia de Mana minuto":
                tipoDato == "stat-MPKill" ? "Mana Por Muerte":
                tipoDato == "stat-velChargeBarrier" ? "Velocidad de carga de barrera":
                tipoDato == "stat-Slowness" ? "lentitud":
                tipoDato == "stat-Poison" ? "veneno":
                tipoDato == "stat-ManaBarrier" ? "Cantidad de Barrera": "";

            if(tower.MP < manaCost){
                cambioColor.color = color[0];
            } else {
                cambioColor.color = color[1];
            }

            manaCostText.text = manaCost + "";
        }
    }

    public void upStat () {
        if(tower.MP >= manaCost) {
            if (tipoDato == "stat-DamageBase") {
                tower.DamageBase += !isPorcentual ? valueChange : (tower.DamageBase * valueChange / 100);
            }
            if (tipoDato == "stat-ATKRange") {
                tower.ATKRange += !isPorcentual ? valueChange : (tower.ATKRange * valueChange / 100);
            }
            if (tipoDato == "stat-ATKSpeed") {
                tower.ATKSpeed += !isPorcentual ? valueChange : (tower.ATKSpeed * valueChange / 100);
            }
            if (tipoDato == "stat-DoubleChance") {
                tower.DoubleChance += !isPorcentual ? valueChange : (tower.DoubleChance * valueChange / 100);
            }
            if (tipoDato == "stat-CriticalChance") {
                tower.CriticalChance += !isPorcentual ? valueChange : (tower.CriticalChance * valueChange / 100);
            }
            if (tipoDato == "stat-CriticalMultiplier") {
                tower.CriticalMultiplier += !isPorcentual ? valueChange : (tower.CriticalMultiplier * valueChange / 100);
            }

            if (tipoDato == "stat-HPMax") {
                tower.HPMax += !isPorcentual ? valueChange : (tower.HPMax * valueChange / 100);
            }
            if (tipoDato == "stat-HPRegen") {
                tower.HPRegen += !isPorcentual ? valueChange : (tower.HPRegen * valueChange / 100);
            }
            if (tipoDato == "stat-DefenceBase") {
                tower.DefenceBase += !isPorcentual ? valueChange : (tower.DefenceBase * valueChange / 100);
            }
            if (tipoDato == "stat-TowerDamage") {
                tower.TowerDamage += !isPorcentual ? valueChange : (tower.TowerDamage * valueChange / 100);
            }
            if (tipoDato == "stat-VampireChance") {
                tower.VampireChance += !isPorcentual ? valueChange : (tower.VampireChance * valueChange / 100);
            }
            if (tipoDato == "stat-VampireValue") {
                tower.VampireValue += !isPorcentual ? valueChange : (tower.VampireValue * valueChange / 100);
            }

            if (tipoDato == "stat-MPHour") {
                tower.MPHour += !isPorcentual ? valueChange : (tower.MPHour * valueChange / 100);
            }
            if (tipoDato == "stat-MPKill") {
                tower.MPKill += !isPorcentual ? valueChange : (tower.MPKill * valueChange / 100);
            }
            if (tipoDato == "stat-velChargeBarrier") {
                tower.velChargeBarrier += !isPorcentual ? valueChange : (tower.velChargeBarrier * valueChange / 100);
            }
            if (tipoDato == "stat-Slowness") {
                tower.Slowness += !isPorcentual ? valueChange : (tower.Slowness * valueChange / 100);
            }
            if (tipoDato == "stat-Poison") {
                tower.Poison += !isPorcentual ? valueChange : (tower.Poison * valueChange / 100);
            }
            if (tipoDato == "stat-ManaBarrier") {
                tower.ManaBarrier += !isPorcentual ? valueChange : (tower.ManaBarrier * valueChange / 100);
            }
            tower.MP -= manaCost;
            manaCost += (manaCost * manaCostMul / 100);
        }
    }

    public void openStatPlus () {
        foreach(var obj in clouseStat) {
            obj.SetActive(false);
        }
        foreach(var obj in openStat) {
            if(obj.activeInHierarchy){
                obj.SetActive(false);
            } else {
                obj.SetActive(true);
            }
        }
    }

    public void changeScene() {
        SceneManager.LoadScene(scene);
    }
}

