using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ExUnity.Editor
{
    /// <summary>
    /// Helper class to get rid of CreateAssetMenu attribute.
    /// </summary>
    public static class ScriptableObjectCreator
    {
        #region Create Instance

        /// <summary>
        /// Creates asset from selected ScriptableObject.
        /// </summary>
        [MenuItem("Assets/Create/Instance")]
        public static void CreateInstance()
        {
            foreach (var obj in Selection.objects)
            {
                var script = obj as MonoScript;
                if (script == null)
                    continue;

                var type = script.GetClass();
                if (type.IsSubclassOf(typeof(ScriptableObject)))
                    CreateAsset(type);
            }
        }

        #endregion

        #region Validate Create Instance

        /// <summary>
        /// Checks whatever selected objects are ScriptableObjects.
        /// </summary>
        [MenuItem("Assets/Create/Instance", true)]
        public static bool ValidateCreateInstance()
        {
            return Selection.objects
                .OfType<MonoScript>()
                .Select(script => script.GetClass())
                .Any(type => type.IsSubclassOf(typeof(ScriptableObject)));
        }

        #endregion

        #region Create Asset

        /// <summary>
        /// Creates asset of ScriptableObject.
        /// </summary>
        /// <param name="type">ScriptableObject type</param>
        private static void CreateAsset(System.Type type)
        {
            var asset = ScriptableObject.CreateInstance(type);
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (string.IsNullOrEmpty(path))
            {
                path = "Assets";
            }
            else if (!string.IsNullOrEmpty(Path.GetExtension(path)))
            {
                string assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
                string fileName = Path.GetFileName(assetPath);
                if (fileName != null)
                    path = path.Replace(fileName, "");
            }

            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + type + ".asset");
            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        #endregion
    }
}