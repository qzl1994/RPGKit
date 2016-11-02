// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class CAttack : CBase {
		[NonSerialized]
		public LayerMask EnemyLayer;
		[NonSerialized]
		public LayerMask AllyLayer;

		public float AttackRange = 3;

		public SkillSlot[] AttackSlots;


		void Start() {
			cState.FSM.OnAttackIn += o => {
				//寻找最近的目标
				var colliders = Physics.OverlapSphere(transform.position, AttackRange, EnemyLayer);
				CBase target = null;
				float dis = Mathf.Infinity;
				foreach (var c in colliders) {
					if (c.attachedRigidbody != null) {
						var cbase = c.attachedRigidbody.GetComponent<CHealth>();
						if (cbase != null) {
							var newDis = Vector3.Distance(transform.position, cbase.transform.position);
							if (dis > newDis) {
								dis = newDis;
								target = cbase;
							}
						}
					}
				}
				if (target != null) {
					transform.LookAt(target.transform);
				}
			};
			foreach (var slot in AttackSlots) {
				slot.Init(this);
			}
		}

		void OnAttack() {
			AttackSlots[0].Spawn();
		}


		void OnDrawGizmos() {
			Gizmos.DrawWireSphere(transform.position, AttackRange);
		}


	}
}