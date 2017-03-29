using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SceneField))]
public class SceneFieldPropertyDrawer : PropertyDrawer
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

        var sceneAsset = property.FindPropertyRelative("_sceneAsset");
        var sceneName = property.FindPropertyRelative("_sceneName");
        position = EditorGUI.PrefixLabel(position,
            GUIUtility.GetControlID(FocusType.Passive), label);

        if (sceneAsset != null)
        {
            EditorGUI.BeginChangeCheck();

            var value = EditorGUI.ObjectField(position, sceneAsset.objectReferenceValue,
                typeof(SceneAsset), allowSceneObjects: false);
            if (EditorGUI.EndChangeCheck())
            {
                sceneAsset.objectReferenceValue = value;
                if (sceneAsset.objectReferenceValue != null)
                    sceneName.stringValue = ((SceneAsset)sceneAsset.objectReferenceValue).name;
            }

        }

        EditorGUI.EndProperty();
    }

    #endregion
}