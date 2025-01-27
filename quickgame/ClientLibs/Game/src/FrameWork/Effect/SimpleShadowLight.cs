/// <summary>
/// 绑到投射阴影的灯光上,用来生成物体的阴影
/// </summary>
 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleShadowLight : MonoBehaviour
{
	public RenderTexture ShadowTexture;// 生成剪影的动态贴图
	
	public float LightCameraSize = 8.0f;// 正交投影的size
	
    Camera mMainCamera;// 主相机
    Light mLight;//投射阴影的灯光
	Camera mLightCamera;// 灯光方向对应的相机
	
    Material mShadowMaterial = null; //接受阴影的材质
	public Material ShadowMaterial
	{
		get { return mShadowMaterial; }
	}
	
    static Camera msLightCamera; // 灯光方向对应的相机（静态变量）
	static public Camera GetLightShadowCamera()
	{
		return msLightCamera;
	}
	
    /// <summary>
    /// 通过设置灯光相机的激活来设置投影是否渲染
    /// </summary>
	public bool Enable
	{
		get { return mLightCamera.enabled; }
		set { mLightCamera.enabled = value; }
	}
	
	void Awake()
	{
        // 获取RenderTexture
		if (ShadowTexture == null)
			ShadowTexture = Resources.Load("core/textures/SimpleShadowTexture") as RenderTexture;
		
        // 获取灯光
		mLight = GetComponent<Light>();
		if (mLight == null || ShadowTexture == null)
			return;
		
        // 设置灯光对应的相机
		mLightCamera = GetComponent<Camera>();
		if (mLightCamera == null)
			mLightCamera = gameObject.AddComponent<Camera>();
		
        // 设置相机的参数
		mLightCamera.orthographic = true;
		mLightCamera.orthographicSize = LightCameraSize;
		mLightCamera.targetTexture = ShadowTexture;
		mLightCamera.backgroundColor = new Color(0, 0, 0, 0);
        // 设置相机渲染过滤层级
		mLightCamera.cullingMask =  1<<LayerMask.NameToLayer("Player") | 1<<LayerMask.NameToLayer("Default");
		
        // 设置相机渲染所用的材质
        Shader replace = Shader.Find("Custom/SShadow_Replace");
        mLightCamera.SetReplacementShader(replace, "");

        //接受阴影材质使用相机渲染的贴图作为阴影贴图
		mShadowMaterial = new Material(Shader.Find("Custom/SShadow"));
		mShadowMaterial.SetTexture("_ShadowTexture", mLightCamera.targetTexture);
		
		msLightCamera = mLightCamera;
	}
	
	// Update is called once per frame
	void Update ()
	{
        // 根据主相机的位置来更新灯光相机的位置
		/*if (mMainCamera == null)
			mMainCamera = Camera.main;
		
		Vector3 posCam = mMainCamera.transform.position;
		//Vector3 posPlayer = main.GetLocalPlayer().transform.position;
        Vector2 MapSize = new Vector2(0.0f, 8.0f);  
		Vector3 look = new Vector3(posCam.x, 0.0f, (MapSize.x + MapSize.y)*0.5f);
		Vector3 dir = mLight.transform.forward;
		
//	    Vector3 newPos = look - dir*50.0f;
//		Vector3 oldPos = mLightCamera.transform.position;
//		if (Mathf.Abs(newPos.x - oldPos.x) > 0.1f)
		
		mLightCamera.transform.position = look - dir*50.0f;*/
	}
	
	void LateUpdate()
	{
		mShadowMaterial.SetMatrix("_LightCameraMVP", mLightCamera.projectionMatrix * mLightCamera.worldToCameraMatrix);
	}
}
