// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameClient;

namespace Game {

	public class CBase : MonoBehaviour {
		[HideInInspector]
		public CState cState;
		[HideInInspector]
		public CRun cRun;
		[HideInInspector]
		public CAttack cAttack;
		[HideInInspector]
		public CSkill cSkill;
		[HideInInspector]
		public CHealth cHealth;
		[HideInInspector]
		public CMountPoint cMountPoint;


		protected virtual void OnValidate() {
			cState = GetComponent<CState>();
			cRun = GetComponent<CRun>();
			cAttack = GetComponent<CAttack>();
			cSkill = GetComponent<CSkill>();
			cHealth = GetComponent<CHealth>();
			cMountPoint = GetComponent<CMountPoint>();
		}

		public void InitAllCom(HeroData data) {
			var ccom = GetComponents<CBase>();
			foreach (var c in ccom) {
				c.InitData(data);
			}
		}

		public virtual void InitData(HeroData data) { }

	}
}