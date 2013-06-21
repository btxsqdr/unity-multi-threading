using UnityEngine;
using System.Collections;

/**
 * main game manager
 * 
 * place from where we start
 * 
 * */

public class Game : MonoBehaviour {
	
	// long, but simple example
	private Example1Manager m_Example1Manager;
	
	// short, but more advanced example
	private Example2Manager m_Example2Manager;
	
	void Start () {
		m_Example1Manager = new Example1Manager();
		m_Example2Manager = new Example2Manager();
		
		// activate example 1
		m_Example1Manager.GoGoGo();
		
		// activate example 2
		//m_Example2Manager.GoGoGo();
	}
	
	void Update () {
		//
	}
}
