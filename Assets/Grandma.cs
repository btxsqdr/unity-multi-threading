using UnityEngine;
using System.Collections;

/**
 * 
 * ol' lady class
 * 
 * */

public class Grandma {
	
	private bool m_Angry = false;
	private int m_Age = 65;
	
	public bool angry {
		set { m_Angry = value; }
		get { return m_Angry; }
	}
	
	public int age {
		set { 
			m_Age = value % 100; // forever young 
		}
		get { return m_Age; }
	}
	
	public Grandma(int age) {
		m_Age = age;
	}
}
