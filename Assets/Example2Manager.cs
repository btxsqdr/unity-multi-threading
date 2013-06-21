using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * in this example we try something else; we do the same, but shorter
 * 
 * a) add grannies to grandma array
 * b) process all grannies
 * 
 * for c# delegates: http://msdn.microsoft.com/en-us/library/ms173171(v=vs.80).aspx
 * for c# generics: http://msdn.microsoft.com/en-us/library/ms379564(v=vs.80).aspx
 * 
 * */

public class Example2Manager {
	
	// list of grandmas
	private List<Grandma> m_Grannies;
	
	public Example2Manager() {
		m_Grannies = new List<Grandma>();
		
		// add grannies first
		AddGrannies();
	}
	
	/**
	 * main method
	 * */
	public void GoGoGo() {
		// call process() directly, after instantiating a ThreadProcessor<Grandma>
		new ThreadProcessor<Grandma>()
			.Process(
				m_Grannies, 
				
				// magic part! see c# delegates for more
				delegate(Grandma g) {
					
					g.age += 1;
					Debug.Log( g.age );
				
				}, 
			
				true);
	}
	
	/**
	 * add grannies to array
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
