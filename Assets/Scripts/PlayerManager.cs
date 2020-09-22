using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	
	public float health;//жизни
	public float strength;//сила
	public float agility;//ловкость
	public float stamina;//выносливость
	public float intelligence;//интеллект
	public float mana;// кол-во маны
	public float lightDepth;//интенсивность света
	public int lightScore;//очки света
	
	public float maxHp;
	public float maxStam;
	public float maxInt;
	
	public string namePlayer;
	public float kills;
	public float crypts;
	public float deaths;
	
	private int scoreLimit = 100;//начальный предел прокачки статов
	public GameObject firstSpawnPoint; 
	public GameObject lastBonfire;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void PlayerIsDead(bool dead)//функция смерти игрока
	{
		
	}
}
