using System.Collections.Generic;

/// <summary>AB包数据</summary>
public class AssetBundleData
{
    /// <summary>包名</summary>
    public string Name;
    /// <summary>依赖包名数组</summary>
    public string[] DependencyBundleNames;
    /// <summary>资源列表</summary>
    public List<AssetData> AssetDataList = new List<AssetData>();
}
