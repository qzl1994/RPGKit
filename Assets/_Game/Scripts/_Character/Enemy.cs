// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class Enemy : CBase {

		void Awake() {
			base.OnValidate();
		}

		void Start() {
			cAttack.EnemyLayer = LayerMamanger.Ins.Player;
			cAttack.AllyLayer = LayerMamanger.Ins.Enemy;
			LayerMamanger.SetLayerRecursion(gameObject, LayerMamanger.Ins.Enemy);
		}

		void Update() {
			if (Hero.ins == null || !Hero.ins.cHealth.IsAlive) {
				cState.ProcessEvent(CharacterFSM.Event.Stop_run);
				return;
			}
			if (cState.State == CharacterFSM.State.Idle) {
				cState.ProcessEvent(CharacterFSM.Event.Run, Hero.ins.transform.position - transform.position);
			} else if (cState.State == CharacterFSM.State.Run) {
				if (Vector3.Distance(transform.position, Hero.ins.transform.position) < cAttack.AttackRange) {
					//reach attack range
					cState.ProcessEvent(CharacterFSM.Event.Stop_run);
					cState.ProcessEvent(CharacterFSM.Event.Attack);
					transform.LookAt(Hero.ins.transform);
				} else {
					var dir = Hero.ins.transform.position - transform.position;
					cState.ProcessEvent(CharacterFSM.Event.Run, dir);
					cRun.Move(dir);
				}
			}
		}
	}
}