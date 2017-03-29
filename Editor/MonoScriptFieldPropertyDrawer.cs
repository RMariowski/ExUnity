using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MonoScriptField))]
public class MonoScriptFieldPropertyDrawer : PropertyDrawer
{
    #region On GUI

    /// <summary>
    /// Unity's OnGUI
    /// </summary>
    /// <param name="position"></param>
    /// <param name="property"></param>
    /// <param name="label"></param>
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, GUIContent.none, property);
        
        var scriptAsset = property.FindPropertyRelative("_scriptAsset");
        var scriptName = property.FindPropertyRelative("_scriptName");
        position = EditorGUI.PrefixLabel(position,
            GUIUtility.GetControlID(FocusType.Passive), label);

        if (scriptAsset != null)
        {
            EditorGUI.BeginChangeCheck();

            var value = EditorGUI.ObjectField(position, scriptAsset.objectReferenceValue,
                typeof(MonoScript), allowSceneObjects: false);
            if (EditorGUI.EndChangeCheck())
            {
                scriptAsset.objectReferenceValue = value;
                if (scriptAsset.objectReferenceValue != null)
                {
                    scriptName.stringValue =
                        ((MonoScript) scriptAsset.objectReferenceValue).name;
                }
            }

        }

        EditorGUI.EndProperty();
    }

    #endregion
}