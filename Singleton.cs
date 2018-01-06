using System;

namespace ExUnity
{
    public class Singleton<T> where T : class
    {
        #region Static Readonly

        private static readonly object LockObj = new object();

        #endregion

        #region Fields

        private static T _instance;

        #endregion

        #region Properties

        /// <summary>
        /// Returns instance of singleton.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    CreateInstance();
                return _instance;
            }
        }

        #endregion

        #region Create Instance

        /// <summary>
        /// Creates instance of singleton.
        /// </summary>
        private static void CreateInstance()
        {
            lock (LockObj)
            {
                if (_instance != null)
                    return;

                var type = typeof(T);
                var constructors = type.GetConstructors();
                if (constructors.Length > 0)
                {
                    throw new InvalidOperationException(type.Name +
                                                        " has at least one accessible constructor making it impossible to enforce singleton behavior.");
                }

                _instance = (T) Activator.CreateInstance(type, nonPublic: true);
            }
        }

        #endregion
    }
}