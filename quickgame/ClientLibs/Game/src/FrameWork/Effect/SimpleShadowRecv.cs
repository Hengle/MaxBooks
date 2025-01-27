/// <summary>
/// 用来接收物体的阴影
/// </summary>

using UnityEngine;
using System.Collections.Generic;

public class SimpleShadowRecv : MonoBehaviour
{
	bool mIsAddedShader = false;
	Material mShadowMaterial = null;
	
	public bool Enable
	{
		set
		{
			Material shadowMat = mShadowMaterial;
			if (shadowMat == null)
				return;
			
			Renderer[] rds = GetComponentsInChildren<Renderer>();
			foreach (Renderer rd in rds)
			{
				if (value)
				{
					if (!mIsAddedShader)
					{
						Material[] bk = rd.materials;
						
						List<Material> newMatLst = new List<Material>();
						newMatLst.AddRange(bk);
						newMatLst.Add(shadowMat);
						
						rd.materials = newMatLst.ToArray();
						
						mIsAddedShader = true;
					}
				}
				else
				{
					if (mIsAddedShader)
					{
						Material[] bk = rd.materials;
						
						List<Material> newMatLst = new List<Material>();
						newMatLst.AddRange(bk);
						newMatLst.RemoveAt(newMatLst.Count-1);
						
						rd.materials = newMatLst.ToArray();
						
						mIsAddedShader = false;
					}
				}
			}
		}
	}
	
	void Start()
	{
		Camera lightCamera = SimpleShadowLight.GetLightShadowCamera();
		if (lightCamera == null)
		{
			Enable = false;
			return;
		}
		
		mShadowMaterial = lightCamera.GetComponent<SimpleShadowLight>().ShadowMaterial;
		Enable = true;
		
		// PS：更新一下Transform就能正常显示，原因暂时不明
		Vector3 pos = transform.localPosition;
		Vector3 newPos = pos + new Vector3(0f, 0.001f, 0f);
		transform.localPosition = newPos;
		transform.localPosition = pos;
	}
}

