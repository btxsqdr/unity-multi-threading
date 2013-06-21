using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/**
 * interface of Example1Processor classes
 * 
 * for c# interfaces, see: http://www.codeproject.com/Articles/18743/Interfaces-in-C-For-Beginners
 * */
public interface IProcessor<T> {
	void Action(T t);
	void Process(List<T> t);
}

/**
 * example 1 processor with grandma
 * 
 * for c# generics: http://msdn.microsoft.com/en-us/library/ms379564(v=vs.80).aspx
 * */
public class Example1Processor<G> : IProcessor<G> where G : Grandma {
	
	// our thread processor, where the multi-threading magic happens
	private IThreadProcessor<G> m_ThreadProcessor;
	
	/**
	 * constructor
	 * 
	 * @processor: a particular processor you like to use
	 * */
	public Example1Processor(IThreadProcessor<G> processor) {
		m_ThreadProcessor = processor;
	}
	
	/**
	 * method we call/delegate for every item/grandma
	 * 
	 * @g: one grandma
	 * */
	public void Action(G g) {
		g.age += 1; // we getting older
		Debug.Log( g.age );
	}
	
	/**
	 * public method to start multi-threading processor with grandma array
	 * 
	 * @grannies: list of grandmas
	 * */
	public void Process(List<G> grannies) {
		m_ThreadProcessor.Process(grannies, Action, false);
	}
}
