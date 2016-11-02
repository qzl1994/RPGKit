// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class SkillBase : MonoBehaviour {

		public SkillInfo skillInfo;

		public MountPoint MP = MountPoint.Foot;

		public Action OnSpawn;

		public SkillBase Spawn(SkillInfo info) {
			var mp = info.User.cMountPoint[MP];
			var insGO = Instantiate(gameObject, mp.position, mp.rotation) as GameObject;
			var insSkill = insGO.GetComponent<SkillBase>();
			insSkill.skillInfo = info;
			if (insSkill.OnSpawn != null) {
				insSkill.OnSpawn();
			}
			return insSkill;


		}
	}
}