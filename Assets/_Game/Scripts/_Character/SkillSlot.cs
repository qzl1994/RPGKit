// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	[System.Serializable]
	public class SkillSlot {


		public SkillBase SkillPrefab;

		private CBase _owner;

		public void Init(CBase c) {
			this._owner = c;
		}

		public void Spawn() {
			SkillPrefab.Spawn(new SkillInfo() {
				User = _owner
			});
		}
	}
}