using UnityEngine;

public class SingletonUnity<T> : MonoBehaviour where T : Component
{
    #region Fields

    private static T _instance;

    #endregion

    #region Properties

    /// <summary>
    /// Returns instance
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    var obj = new GameObject { name = typeof(T).Name };
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    #endregion

    #region Awake

    /// <summary>
    /// Unity's Awake
    /// </summary>
    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
}