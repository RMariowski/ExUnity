using UnityEngine;

namespace ExUnity
{
    [System.Serializable]
    public class MonoScriptField
    {
        #region Fields

        [SerializeField] private Object _scriptAsset;

        [SerializeField] private string _scriptName = "";

        #endregion

        #region Properties

        public string ScriptName => _scriptName;

        #endregion
    }
}