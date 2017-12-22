using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ExUnity.Editor
{
    public static class ScriptableObjectCreator
    {
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

        /// <summary>
        /// Checks whatever selected objects are ScriptableObjects.
        /// </summary>
        /// <returns></returns>
        [MenuItem("Assets/Create/Instance", true)]
        public static bool ValidateCreateInstance()
        {
            return Selection.objects.OfType<MonoScript>().Select(script => script.GetClass())
                .Any(type => type.IsSubclassOf(typeof(ScriptableObject)));
        }

        /// <summary>
        /// Creates asset of ScriptableObject.
        /// </summary>
        /// <param name="type">ScriptableObject type</param>
        private static void CreateAsset(System.Type type)
        {
            var asset = ScriptableObject.CreateInstance(type);
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == "")
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != "")
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }

            string assetPathAndName =
                AssetDatabase.GenerateUniqueAssetPath(string.Format("{0}/New {1}.asset", path, type));
            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
    }
}