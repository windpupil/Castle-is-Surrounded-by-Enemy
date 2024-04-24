using UnityEditor;
using System.IO;

#if UNITY_EDITOR
public class CreateAssetBundles
{
    // [MenuItem("Assets/Build AssetBundles")]
    // static void BuildAllAssetBundles()
    // {
    //     string dir = "AssetBundles";
    //     if (Directory.Exists(dir) == false)
    //     {
    //         Directory.CreateDirectory(dir);
    //     }
    //     //BuildTarget 选择build出来的AB包要使用的平台
    //     BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    // }
}
#endif