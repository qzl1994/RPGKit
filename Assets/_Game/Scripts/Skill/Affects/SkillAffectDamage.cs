// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class SkillAffectDamage : SkillAffectBase {
		public float damage;

		public override void Affect(CBase c) {
			c.cHealth.Damage(damage);
		}
	}
}