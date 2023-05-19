//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

namespace GameFramework.DataTable
{
    /// <summary>
    /// 数据表行接口。
    /// </summary>
    public interface IDataRow
    {
        /// <summary>
        /// 获取数据表行的编号。
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// 解析数据表行。
        /// </summary>
        /// <param name="dataRowString">要解析的数据表行字符串。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>是否解析数据表行成功。</returns>
        bool ParseDataRow(string dataRowString, object userData);

        /// <summary>
        /// 解析数据表行。
        /// </summary>
        /// <param name="dataRowBytes">要解析的数据表行二进制流。</param>
        /// <param name="startIndex">数据表行二进制流的起始位置。</param>
        /// <param name="length">数据表行二进制流的长度。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>是否解析数据表行成功。</returns>
        bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData);

        /// <summary>
        /// 数据表行文本内容解析器。
        /// </summary>
        /// <param name="dataRowText">要解析的文本内容。</param>
        void ParseDataRow(string dataRowText);


    }

    /// <summary>
    /// 数据表行接口。
    /// </summary>
    public interface IDataRowPre
    {
        /// <summary>
        /// 获取数据表行的编号。
        /// </summary>
        int Id
        {
            get;
        }


        /// <summary>
        /// 数据表行文本内容解析器。
        /// </summary>
        /// <param name="dataRowText">要解析的文本内容。</param>
        void ParseDataRow(string dataRowText);


    }


}
