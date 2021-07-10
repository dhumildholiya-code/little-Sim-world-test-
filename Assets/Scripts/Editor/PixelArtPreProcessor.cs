using UnityEditor;
using UnityEngine;

namespace LittleSimTest.Editor
{
    public class PixelArtPreProcessor : AssetPostprocessor
    {
        private const string AssetPathStartsWith = "Assets/Sprites/Clothes/";
        private const int SpritePixelPerUnit = 10;
        private void OnPreprocessTexture()
        {
            if(!assetImporter.assetPath.StartsWith(AssetPathStartsWith)) return;
            TextureImporter textureImporter = assetImporter as TextureImporter;
            if(textureImporter == null) return;

            textureImporter.spriteImportMode = SpriteImportMode.Multiple;
            textureImporter.filterMode = FilterMode.Point;
            textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
            textureImporter.spritePixelsPerUnit = SpritePixelPerUnit;
        }
    }
}
