using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class InterfaceUser : MonoBehaviour,InterfaceEx
{

	void Start()
	{
		InterfaceEx ex = gameObject.GetComponent<InterfaceEx>();
		ex.Init();
		ex.Attack();

		Debug.Log("hp ="+hp);
		Debug.Log("Mp =" +Mp);

	}

	// Update is called once per frame
	void Update()
	{

	}
	public int hp { get; set; }
	public int Mp { get;  set; }

	public void Attack()
	{
		Debug.Log("АјАн");
	}

	public void Init()
	{

		hp = 100;
		Mp = 50;
		
	}





}
