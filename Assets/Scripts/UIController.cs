using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	public GameObject menu;
	public GameObject inventory;
	public GameObject statistic;
	public GameObject playerUp;
	public GameObject bonfireMenu;
	public GameObject teleportMenu;
	
	private controller player;
	private PlayerManager pm;
	
	private Slider hpBar;
	private Slider stamBar;
	private Slider manaBar;
	
	//статистика
	private TMP_Text hp;
	private TMP_Text str;
	private TMP_Text agi;
	private TMP_Text stam;//выносливость
	private TMP_Text intel;//интеллект
	private TMP_Text mana;// кол-во маны
	private TMP_Text lightDepth;//интенсивность света
	private TMP_Text lightScore;//очки света
	private TMP_Text namePlayer;
	private TMP_Text kills;
	private TMP_Text crypts;
	private TMP_Text deaths;
	
    // Start is called before the first frame update
    void Awake()
    {
		StatOnScreen();
		menu.SetActive(false);
		inventory.SetActive(false);
		statistic.SetActive(false);
		playerUp.SetActive(false);
		bonfireMenu.SetActive(false);
		teleportMenu.SetActive(false);
		player = gameObject.GetComponent<controller>();
		pm = GameObject.Find("Player").GetComponent<PlayerManager>();
		hpBar = GameObject.Find("HealthBar").GetComponent<Slider>();
		stamBar = GameObject.Find("StaminaBar").GetComponent<Slider>();
		manaBar = GameObject.Find("ManaBar").GetComponent<Slider>();		
		maxBarsCount();		
    }
	
	void StatOnScreen()
	{
		hp = statistic.transform.Find("HealthStat").GetComponent<TMP_Text>();
		str = statistic.transform.Find("StrengthStat").GetComponent<TMP_Text>();
		agi = statistic.transform.Find("AgilityStat").GetComponent<TMP_Text>();
		stam = statistic.transform.Find("StaminaStat").GetComponent<TMP_Text>();
		intel = statistic.transform.Find("IntelligenceStat").GetComponent<TMP_Text>();
		lightDepth = statistic.transform.Find("LightStat").GetComponent<TMP_Text>();
		lightScore = statistic.transform.Find("LightScore").GetComponent<TMP_Text>();
		namePlayer = statistic.transform.Find("NamePlayer").GetComponent<TMP_Text>();
		kills = statistic.transform.Find("Kills").GetComponent<TMP_Text>();
		crypts = statistic.transform.Find("Crypts").GetComponent<TMP_Text>();
		deaths = statistic.transform.Find("Deaths").GetComponent<TMP_Text>(); // нужно закончить отображение статистики
	}

    // Update is called once per frame
    void Update()
    {
		hpBar.value = pm.health;
		stamBar.value = pm.stamina;
		manaBar.value = pm.mana;
        if(Input.GetKeyDown(KeyCode.Escape)){
			menu.SetActive(!menu.activeSelf);
			inventory.SetActive(false);
			statistic.SetActive(false);
		}
		if(Input.GetKeyDown(KeyCode.I)){
			inventory.SetActive(!inventory.activeSelf);
		}
		if(Input.GetKeyDown(KeyCode.P)){
			StatisticClick();
		}
		
    }
	
	public void maxBarsCount()
	{
		hpBar.maxValue = pm.maxHp;
		stamBar.maxValue = pm.maxStam;
		manaBar.maxValue = pm.maxInt;
	}
	
	public void InventoryClick()
	{
		inventory.SetActive(!inventory.activeSelf);
		statistic.SetActive(false);
	}
	public void StatisticClick()
	{		
		statistic.SetActive(!statistic.activeSelf);
		hp.text = "Здоровье - " + pm.health;
		str.text = "Сила - " + pm.strength;
		agi.text = "Ловкость - " + pm.agility;
		stam.text = "Выносливость - " + pm.stamina;
		intel.text = "Интеллект - " + pm.intelligence;
		lightDepth.text = "Свет - " + pm.lightDepth;
		lightScore.text = "Количество частиц света - " + pm.lightScore;
		namePlayer.text = "Имя - " + pm.namePlayer;
		kills.text = "Убито - " + pm.kills;
		crypts.text = "Тайников - " + pm.crypts;
		deaths.text = "Смертей - " + pm.deaths;
		inventory.SetActive(false);
		
	}
	public void PlayerUpClickOpen()
	{
		playerUp.SetActive(true);
		ActivateBonfireMenu();
	}
	public void PlayerUpClickClose()
	{
		maxBarsCount();
		playerUp.SetActive(false);
		player.enabled = !player.enabled;
	}
	public void ExitGame()
	{
		Application.Quit();
	}
	public void ActivateBonfireMenu()
	{
		bonfireMenu.SetActive(!bonfireMenu.activeSelf);
		player.enabled = !player.enabled;
	}
	
	public void ActivateTeleportMenu()
	{
		teleportMenu.SetActive(!teleportMenu.activeSelf);
		bonfireMenu.SetActive(false);		
	}

	
	
}
