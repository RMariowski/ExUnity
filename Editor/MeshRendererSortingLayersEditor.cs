using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Reflection;

namespace ExUnity.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(MeshRenderer))]
    public class MeshRendererSortingLayersEditor : UnityEditor.Editor
    {
        #region Fields

        private int _selectedOption;

        #endregion

        #region On Enable

        /// <summary>
        /// Unity's OnEnable
        /// </summary>
        private void OnEnable()
        {
            var sortingLayerNames = GetSortingLayerNames();
            var renderer = ((Renderer) target).gameObject.GetComponent<Renderer>();

            for (var i = 0; i < sortingLayerNames.Length; i++)
            {
                if (sortingLayerNames[i] == renderer.sortingLayerName)
                    _selectedOption = i;
            }
        }

        #endregion

        #region On Inspector GUI

        /// <inheritdoc />
        /// <summary>
        /// Unity's OnInspectorGUI
        /// </summary>
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var renderer = ((Renderer) target).gameObject.GetComponent<Renderer>();
            if (!renderer)
                return;

            var sortingLayerNames = GetSortingLayerNames();
            EditorGUILayout.BeginHorizontal();
            _selectedOption = EditorGUILayout.Popup("Sorting Layer", _selectedOption, sortingLayerNames);
            if (sortingLayerNames[_selectedOption] != renderer.sortingLayerName)
            {
                Undo.RecordObject(renderer, "Sorting Layer");
                renderer.sortingLayerName = sortingLayerNames[_selectedOption];
                EditorUtility.SetDirty(renderer);
            }
            EditorGUILayout.EndHorizontal();

            int newSortingLayerOrder = EditorGUILayout.IntField("Order in layer", renderer.sortingOrder);
            if (newSortingLayerOrder != renderer.sortingOrder)
            {
                Undo.RecordObject(renderer, "Edit Layer Order");
                renderer.sortingOrder = newSortingLayerOrder;
                EditorUtility.SetDirty(renderer);
            }
        }

        #endregion

        #region Get Sorting Layer Names

        /// <summary>
        /// Returns array of all sorting layer names.
        /// </summary>
        /// <returns></returns>
        private static string[] GetSortingLayerNames()
        {
            var internalEditorUtilityType = typeof(InternalEditorUtility);
            var sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames",
                BindingFlags.Static | BindingFlags.NonPublic);
            return (string[]) sortingLayersProperty.GetValue(null, new object[0]);
        }

        #endregion
    }
}