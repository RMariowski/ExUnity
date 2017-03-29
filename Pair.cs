using System;

[Serializable]
public class Pair<TF, TS>
{
    #region Fields

    public TF first;
    public TS second;

    #endregion

    #region Constructor

    /// <summary>
    /// Empty constructor.
    /// </summary>
    public Pair()
    {

    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="first">first value/object</param>
    /// <param name="second">second value/object</param>
    public Pair(TF first, TS second)
    {
        this.first = first;
        this.second = second;
    }

    #endregion
}