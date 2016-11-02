// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameClient;

namespace Game {

	public class CHealth : CBase {
		public float HP = 1000f;

		public bool IsAlive {
			get { return HP > 0f; }
		}

		void Start() {
			cState.FSM.OnDeathIn += o => {
				GetComponent<Collider>().enabled = false;//死亡的时候关闭碰撞体
			};
		}

		public void Damage(float damage) {
			HP -= damage;
			if (HP <= 0) {
				cState.ProcessEvent(CharacterFSM.Event.Death);
				var autoDestroy = gameObject.AddComponent<AutoDestroy>();
				autoDestroy.time = 2f;
			}
		}

		public override void InitData(HeroData data) {
			this.HP = data.HP;
		}

	}
}