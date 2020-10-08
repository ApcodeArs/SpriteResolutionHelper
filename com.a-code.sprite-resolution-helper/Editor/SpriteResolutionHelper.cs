using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SpriteResolutionHelper
{
    public class SpriteResolutionHelper : UnityEditor.AssetModificationProcessor
    {
        private const string SpriteFileType = ".png";

        static void OnWillCreateAsset(string assetName)
        {
            if (!SpriteResolutionEditorTool.IsUsed || !assetName.Contains(SpriteFileType))
                return;

            var assetFullPath = GetAssetFullPath(assetName);
            var texture = TextureFromFile(assetFullPath);

            if (texture.width % 4 != 0 || texture.height % 4 != 0)
                Debug.LogWarning($"{assetName} have incorrect resolution");
        }

        private static string GetAssetFullPath(string assetName)
        {
            var metaStartIndex = assetName.IndexOf(".meta");
            var assetPath = assetName.Remove(metaStartIndex);

            return Path.Combine(Path.GetDirectoryName(Application.dataPath), assetPath);
        }

        private static Texture TextureFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);

            var bytes = File.ReadAllBytes(filePath);
            var texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);

            return texture;
        }
    }
}
