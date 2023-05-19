using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ResData : Singleton<ResData>
{

    #region 字属构造

    /// <summary>AB包列表</summary>
    public List<AssetBundleData> AssetBundleDatas = new List<AssetBundleData>();
    /// <summary>AB包清单</summary>
    private AssetBundleManifest mManifest;
    private ResData()
    {
        Load();
    }
    #endregion

    #region 生命
    private void Load()
    {
        if (ResMgr.IsSimulationModeLogic)
        {
#if UNITY_EDITOR
            var assetBundleNames = UnityEditor.AssetDatabase.GetAllAssetBundleNames();

            foreach (var assetBundleName in assetBundleNames)
            {
                var assetPaths = UnityEditor.AssetDatabase.GetAssetPathsFromAssetBundle(assetBundleName);

                var assetBundleData = new AssetBundleData
                {
                    Name = assetBundleName,
                    DependencyBundleNames =
                        UnityEditor.AssetDatabase.GetAssetBundleDependencies(assetBundleName, false)
                };

                foreach (var assetPath in assetPaths)
                {
                    var assetData = new AssetData
                    {
                        OwnerBundleName = assetBundleName,
                        // 通过路径获取名字
                        Name = assetPath
                            .Split('/').Last()
                            .Split('.').First()
                    };

                    assetBundleData.AssetDataList.Add(assetData);
                }

                AssetBundleDatas.Add(assetBundleData);
            }
#endif
        }
        else
        {
            var mainBundle =
                AssetBundle.LoadFromFile(ResKitUtil.FullPathForAssetBundle(ResKitUtil.GetPlatformName()));

            mManifest = mainBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        }
    }

    #endregion

    #region 辅助


    public string[] GetDirectDependencies(string bundleName)
    {
        if (ResMgr.IsSimulationModeLogic)
        {
            return AssetBundleDatas
                .Find(data => data.Name == bundleName)
                .DependencyBundleNames;
        }

        return mManifest.GetDirectDependencies(bundleName);
    }





    #endregion
}
