// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class SkillConditionBase : SkillBaseAssist {

		public SkillAffectBase[] Affects;

		public virtual void Affect(CBase c) {
			if (Affects == null || Affects.Length == 0) {
				Debug.LogError("没有影响逻辑可以执行");
				return;
			}
			foreach (var affect in Affects) {
				affect.Affect(c);
			}
		}


	}
}