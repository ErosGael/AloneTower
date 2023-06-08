using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextTower : MonoBehaviour
{
    private tower tower;
    public string tagDatos;
    public string tipoDato;

    private TMP_Text textoCambiante;

    private void Start() {
        tower = GameObject.FindGameObjectWithTag(tagDatos).GetComponent<tower>();
        textoCambiante = this.GetComponent<TMP_Text>();
    }

    private void Update() {
        textoCambiante.text =
            tipoDato == "HP" ? tower.HP + "/" + tower.HPMax :
            tipoDato == "Barrier" ? tower.manaBarrier + "/" + tower.ManaBarrier :
            tipoDato == "MP" ? tower.MP + "" :
            tipoDato == "stat-DamageBase" ? "Daño Base: " + tower.DamageBase :
            tipoDato == "stat-ATKRange" ? "Rango Ataque: " + tower.ATKRange + "%" :
            tipoDato == "stat-ATKSpeed" ? "Velocidad Ataque: 1/" + tower.ATKSpeed + "s" :
            tipoDato == "stat-DoubleChance" ? "Disparo Doble: " + tower.DoubleChance + "%" :
            tipoDato == "stat-CriticalChance" ? "posibilidad de Critico: " + tower.CriticalChance + "%" :
            tipoDato == "stat-CriticalMultiplier" ? "Multiplicador de Critico: " + tower.CriticalMultiplier :
            tipoDato == "stat-HPMax" ? "Vida Maxima: " + tower.HPMax :
            tipoDato == "stat-HPRegen" ? "Regeneracion vida: 1/" + tower.HPRegen + "s":
            tipoDato == "stat-DefenceBase" ? "Defensa: " + tower.DefenceBase + "%" :
            tipoDato == "stat-TowerDamage" ? "Daño al contacto: " + tower.TowerDamage :
            tipoDato == "stat-VampireChance" ? "robo de vida: " + tower.VampireChance + "%" :
            tipoDato == "stat-VampireValue" ? "Multiplicador de Critico: " + tower.VampireValue :
            tipoDato == "stat-MPHour" ? "Ganancia de Mana minuto: " + tower.MPHour + "/m":
            tipoDato == "stat-MPKill" ? "Mana Por Muerte: " + tower.MPKill :
            tipoDato == "stat-velChargeBarrier" ? "carga de barrera: 1/" + Mathf.Round(tower.velChargeBarrier) + "s" :
            tipoDato == "stat-Slowness" ? "lentitud: " + tower.Slowness + "%" :
            tipoDato == "stat-Poison" ? "veneno: " + tower.Poison :
            tipoDato == "stat-ManaBarrier" ? "Multiplicador de Critico: " + tower.ManaBarrier : "";

        if (tipoDato == "HP" || tipoDato == "Barrier")
        {
            transform.parent.gameObject.GetComponent<Image>().fillAmount = tipoDato == "HP" ? (tower.HP * 1f / tower.HPMax) : (tower.manaBarrier * 1f / tower.ManaBarrier);
        }
        }
    }

