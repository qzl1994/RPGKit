// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class CSkill : CBase {
		public SkillSlot[] Slots;

		void Start() {
			foreach (var slot in Slots) {
				slot.Init(this);
			}
		}

		void OnUseSkill() {
			Slots[0].Spawn();
		}

	}
}