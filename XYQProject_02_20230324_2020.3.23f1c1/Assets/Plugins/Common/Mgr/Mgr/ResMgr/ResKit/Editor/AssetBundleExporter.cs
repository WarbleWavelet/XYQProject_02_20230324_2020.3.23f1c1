using System.IO;
using UnityEditor;
using UnityEngine;


public class AssetBundleExpoter 
{
#if UNITY_EDITOR	
    [MenuItem("QFramework/Framework/ResKit/Build AssetBundles", false)]
	static void BuildAssetBundles()
	{
		var outputPath = Application.streamingAssetsPath + "/AssetBundles/" + ResKitUtil.GetPlatformName();
		Common.Folder_New(outputPath);
		AB.Build(outputPath);
	}
#endif
}
