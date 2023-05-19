/****************************************************

	文件：
	作者：WWS
	日期：2023/03/25 13:17:08
	功能：摄像机截屏。作为正常转战斗的转场

*****************************************************/

//*****************************************
//创建人： Trigger 
//功能说明：摄像机截屏
//***************************************** 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraCapture : MonoBehaviour,IController
{
    private RawImage ri;
    private float blurValue;


  public  void Init()
    {
        gameObject.Show();
        ri = GetComponent<RawImage>();
        gameObject.Hide();
        this.RegistEvent<CaptrueCameraAndSetMaterialValueEvent>(CaptrueCameraAndSetMaterialValue);
    }

    void Update()
    {
        if (ri.gameObject.activeSelf)
        {
            blurValue += Time.deltaTime;
            ri.material.SetFloat("_Blur", blurValue);//模糊
            ri.color -= new Color(0, 0, 0, Time.deltaTime);
            if (ri.color.a <= 0)
            {
                ri.gameObject.Hide();
            }
        }
    }

    /// <summary>
    /// 相机截图
    /// </summary>
    /// <param name="camera">截屏相机</param>
    /// <param name="rect">截屏区域</param>
    /// <returns></returns>
    public Texture2D CaptureCamera(Camera camera, Rect rect)
    {
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);
        camera.targetTexture = rt;
        camera.Render();
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height);
        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();
        camera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(rt);
        return screenShot;
    }
    /// <summary>
    /// 设置截屏UI所需材质的值
    /// </summary>
    /// <param name="texture"></param>
    public void SetMaterialValue(Texture texture)
    {
        ri.material.SetTexture("_MainTex", texture);
        ri.color = new Color(ri.color.r, ri.color.g, ri.color.b, 1);
        ri.gameObject.Show();
        blurValue = 0;
    }

    private void CaptrueCameraAndSetMaterialValue(object obj)
    {
        SetMaterialValue(CaptureCamera(Camera.main,new Rect(0,0,800,600)));
    }
}
