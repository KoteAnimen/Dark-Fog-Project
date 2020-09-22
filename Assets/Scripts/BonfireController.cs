using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireController : MonoBehaviour
{
	public bool isActivate = false;// активирован ли алтарь
	public bool active; // разрешено ли открывание менб алтаря
	private BonfireManager bm; // ссылка на менеджер алтаря(костра)
	private GameObject forceStorm;// объект частиц при активвации 
	private GameObject crystal;// кристал
	private UIController uiBonfire;// ссылка на контроллер интерфейса
	
    
    void Awake()// здесь задаются начальные состояния и ссылки
    {
        forceStorm = this.transform.Find("ForceStorm").gameObject; // ищет на этом объекте его дочерний с заданным именем
		crystal = this.transform.Find("bonCrystal").gameObject; // аналогично предидущему
		forceStorm.SetActive(false); // состояние не активно
		crystal.GetComponent<Light>().enabled = false; // состояние не активно для компонента Light
		bm = GameObject.Find("Player").GetComponent<BonfireManager>(); // ищет игрока по имени и компонент на нем
		uiBonfire = GameObject.Find("Player").GetComponent<UIController>(); // аналогично предыдущему
    }
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.E) && active == true)// если нажата кнопка E и разрешено активировать панель костра(алтаря)
		{
			isActivate = true; // алтарь считается активным
			forceStorm.SetActive(true); // активируются частицы силового шторма
			crystal.GetComponent<Light>().enabled = true; // свет активируется
			crystal.GetComponent<Light>().intensity = 5f; // задается интенсивность света
			uiBonfire.ActivateBonfireMenu(); // активируется панель алтаря(костра)
			
		}		
		
	}
	
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "Player") // если объект с тегом игрок попадает в триггер
		{
			active = true; // разрешение на активанию панели алтаря(костра) = правда
			bm.actPanel.SetActive(true); // активируется подсказка на нажание нужной кнопки
		}
		
	}
	
	
	void OnTriggerExit(Collider other) // событие игрок выходит из триггера
	{
		if(other.gameObject.tag == "Player")
		{
			active = false; // разрешение на активанию панели алтаря(костра) = ложь
			bm.actPanel.SetActive(false); // деактивируется подсказка на нажание нужной кнопки
		}
	}
	
				
	
}
