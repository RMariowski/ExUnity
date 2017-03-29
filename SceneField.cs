﻿using UnityEngine;

[System.Serializable]
public class SceneField
{
    #region Fields

    [SerializeField]
    private Object _sceneAsset;

    [SerializeField]
    private string _sceneName = "";

    #endregion

    #region Properties

    /// <summary>
    /// Returns scene name.
    /// </summary>
    public string SceneName { get { return _sceneName; } }

    #endregion

    #region Scene Name

    /// <summary>
    /// Makes it work with the existing Unity methods (LoadLevel/LoadScene)
    /// </summary>
    /// <param name="sceneField">scene field object</param>
    public static implicit operator string(SceneField sceneField)
    {
        return sceneField.SceneName;
    }

    #endregion
}
