using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * in this example we chose the long way for a better understanding
 * 
 * steps:
 * 
 * a) define a processor (see Example1Processor)
 * b) add grannies to m_Grannies array
 * c) call process() of Example1Processor in order to process all grannies
 * d) happy face
 * 
 * for c# delegates: http://msdn.microsoft.com/en-us/library/ms173171(v=vs.80).aspx
 * 
 * */
public class Example1Manager {
	
	// grandma processor, see: Example1Processor.cs
	private Example1Processor<Grandma> m_GrandmaAger;
	
	// grandma array
	private List<Grandma> m_Grannies;
	
	public Example1Manager() {
		m_GrandmaAger = new Example1Processor<Grandma>(new ThreadProcessor<Grandma>());
		m_Grannies = new List<Grandma>();
		
		// add sample grannies to array
		AddGrannies();
	}
	
	/**
	 * public main method, which will be called from Game.cs
	 * */
	public void GoGoGo() {
		// process all grannies
		m_GrandmaAger.Process(m_Grannies);
	}
	
	/**
	 * add sample grannies to array
	 * */
	private void AddGrannies() {
		Grandma[] g = {
			new Grandma(60),
			new Grandma(62),
			new Grandma(64),
			new Grandma(66),
			new Grandma(68),
			
			new Grandma(70),
			new Grandma(72),
			new Grandma(74),
			new Grandma(76),
			new Grandma(78)
		};
		
		m_Grannies.AddRange(g);
	}
}
