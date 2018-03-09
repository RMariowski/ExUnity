using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExUnity
{
    public static class Helpers
    {
        #region Blank Texture

        /// <summary>
        /// Creates texture filled with one color.
        /// </summary>
        /// <param name="width">width of texture</param>
        /// <param name="height">height of texture</param>
        /// <param name="color">color of texture</param>
        public static Texture2D CreateBlankTexture(int width, int height, Color color)
        {
            var result = new Texture2D(width, height);

            var colors = new Color[4];
            for (var i = 0; i < 4; i++)
                colors[i] = color;
            result.SetPixels(colors);

            result.Apply();
            return result;
        }

        #endregion

        public static T FindObjectOfType<T>()
        {
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                var s = SceneManager.GetSceneAt(i);
                if (!s.isLoaded)
                    continue;

                var allGameObjects = s.GetRootGameObjects();
                foreach (var go in allGameObjects)
                {
                    var component = go.GetComponentInChildren<T>(true);
                    if (component == null)
                        continue;

                    return component;
                }
            }

            return default(T);
        }

        public static List<T> FindObjectsOfTypeAll<T>()
        {
            var results = new List<T>();
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                var s = SceneManager.GetSceneAt(i);
                if (!s.isLoaded)
                    continue;

                var allGameObjects = s.GetRootGameObjects();
                foreach (var go in allGameObjects)
                {
                    results.AddRange(go.GetComponentsInChildren<T>(true));
                }
            }
            return results;
        }
    }
}