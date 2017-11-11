using System.Collections;
using System.Collections.Generic;
using System;

namespace ExUnity
{
    /// <summary>
    /// A thread-safe class which holds a queue with actions to execute on the next Update() method. 
    /// It can be used to make calls to the main thread for things such as UI Manipulation in Unity. 
    /// It was developed for use in combination with the Firebase Unity 
    /// plugin, which uses separate threads for event handling.
    /// </summary>
    public class UnityMainThreadDispatcher : SingletonUnity<UnityMainThreadDispatcher>
    {
        #region Fields

        private static readonly Queue<Action> ExecutionQueue = new Queue<Action>();

        #endregion

        #region Update

        /// <summary>
        /// Unity's Update
        /// </summary>
        public void Update()
        {
            lock (ExecutionQueue)
            {
                while (ExecutionQueue.Count > 0)
                    ExecutionQueue.Dequeue().Invoke();
            }
        }

        #endregion

        #region Enqueue

        /// <summary>
        /// Locks the queue and adds the IEnumerator to the queue
        /// </summary>
        /// <param name="action">IEnumerator function that will be executed from the main thread.</param>
        public void Enqueue(IEnumerator action)
        {
            lock (ExecutionQueue)
                ExecutionQueue.Enqueue(() => { StartCoroutine(action); });
        }

        #endregion

        #region Enqueue

        /// <summary>
        /// Locks the queue and adds the Action to the queue
        /// </summary>
        /// <param name="action">function that will be executed from the main thread.</param>
        public void Enqueue(Action action)
        {
            Enqueue(ActionWrapper(action));
        }

        #endregion

        #region ActionWrapper

        /// <summary>
        /// Wraps function.
        /// </summary>
        /// <param name="action">function that will be wrapped.</param>
        /// <returns></returns>
        private static IEnumerator ActionWrapper(Action action)
        {
            action();
            yield return null;
        }

        #endregion
    }
}