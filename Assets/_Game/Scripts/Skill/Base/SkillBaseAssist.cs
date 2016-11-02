// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class SkillBaseAssist : MonoBehaviour {
		public SkillBase skillBase;

		protected virtual void OnValidate() {
			if (skillBase == null) {
				skillBase = GetComponent<SkillBase>();
			}
		}
	}
}