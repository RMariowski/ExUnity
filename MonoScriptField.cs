using UnityEngine;

[System.Serializable]
public class MonoScriptField
{
    #region Fields

    [SerializeField] private Object _scriptAsset;

    [SerializeField] private string _scriptName = "";

    #endregion

    #region Properties

    /// <summary>
    /// Returns script name.
    /// </summary>
    public string ScriptName
    {
        get { return _scriptName; }
    }

    #endregion
}