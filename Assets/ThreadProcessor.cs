using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

/**
 * interface of ThreadProcessor classes
 * 
 * for c# interfaces, see: http://www.codeproject.com/Articles/18743/Interfaces-in-C-For-Beginners
 * */
public interface IThreadProcessor<T> {
	void Process(List<T> items, Action<T> action, bool waitUntilFinished);
}

/**
 * main thread processor class
 * for c# generics: http://msdn.microsoft.com/en-us/library/ms379564(v=vs.80).aspx
 * */
public class ThreadProcessor<T> : IThreadProcessor<T> where T : class {
	
	/**
	 * main method for all processors
	 * 
	 * @items: list of items to process; for <t>, take a look at c# generics
	 * @action: action/method which we call for every item
	 * @wait: wait until all threads are finished before you proceed
	 * */
	public void Process(List<T> items, Action<T> action, bool wait) {
		
		// number of items to process
		if (items.Count == 0) return;
		
		// thread array
		List<Thread> threads = new List<Thread>();
		
		// max number of possible thread, depending on hardware and number of items
		int maxThreads = Environment.ProcessorCount;
		if (maxThreads < 1) maxThreads = 1;
        if (maxThreads > items.Count) maxThreads = items.Count;

		// items per thread, perhaps
        int itemsPerThread = items.Count / maxThreads;
        
		// number of items to process per thread
		int itemsToProcess = itemsPerThread;

		// loop through all threads
        for (int threadIndex = 0; threadIndex < maxThreads; ++threadIndex) {
            // if current thread index is the last one
			if (threadIndex == maxThreads - 1) {
				// count remaining items to process
				itemsToProcess = (items.Count - (threadIndex * itemsPerThread));
            }
			
			// current thread index
            int index = threadIndex;
			
			// current items to process number
            int toProcess = itemsToProcess;
            
			// magic! create a thread
			// with an offset
			Thread thread = new Thread(() => Action(items, index * itemsPerThread, toProcess, action));
			
			// add it to threads array
			threads.Add(thread);
			
			// and start it...
            thread.Start();
        }
		
		// wait until all threads are finished
        if (wait) {
            // block threads until all calls are finished
			foreach (Thread thread in threads) {
                thread.Join();
            }
        }
	}
	
	/**
	 * method or action we're calling for every thread
	 * 
	 * @items: list of items
	 * @start: index start, in items array
	 * @limit: max number of items to process
	 * @action: actual action/method to call -- from: Process(List<T> items, Action<T> action, bool waitUntilAllFinished)
	 * */
	private static void Action(List<T> items, int start, int limit, Action<T> action) {
		for (int i = start; i < start + limit; ++i) {
            T item = items[i];

			try {
				if (item != null) action(item);
			} catch(Exception e) {
				Debug.Log(e);	
			}

			Thread.Sleep(1);
        }
    }

}