/****************************************************
    文件：ANMD5.cs
	作者：lenovo
    邮箱: 
    日期：2022/8/28 14:3:30
	功能：记录打包所有的名字和MD5
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;





[Serializable]
public class ABMD5
{ 

   [XmlElement("ABMD5Lst")]
    public List<ABMD5Base> ABMD5Lst { get; set; }
}  

[Serializable]
public class ABMD5Base
{
    [XmlAttribute("Name")]
    public string Name { get; set; }  
    
    [XmlAttribute("MD5")]
    public string MD5 { get; set; }     
    
    [XmlAttribute("Size")]
    public float Size { get; set; }

}
