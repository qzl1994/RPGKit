// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class CState : MonoBehaviour {

		public CharacterFSM FSM { private set; get; }
		public Animator animator;

		public CharacterFSM.State State {
			get { return FSM.currentState(); }
		}

		void Awake() {
			var leaves = animator.GetBehaviours<CheckStateLeave>();
			foreach (var leave in leaves) {
				leave.OnLeave += OnLeave;
			}
			FSM = new CharacterFSM();
			FSM.OnIdleIn += OnIdleIn;
			FSM.OnAttackIn += OnAttackIn;
			FSM.OnRunIn += OnRunIn;
			FSM.OnRunOut += OnRunOut;
			FSM.OnSkillIn += OnSkillIn;
			FSM.OnDeathIn += OnDeathIn;
		}

		[ContextMenu("AutoAddCCom")]
		void AutoAddCCom() {
			var collider = gameObject.AddComponent<CapsuleCollider>();
			var rigidbody = gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			gameObject.AddComponent<CRun>();
			gameObject.AddComponent<CAttack>();
			gameObject.AddComponent<CSkill>();
			gameObject.AddComponent<CHealth>();
			var mp = gameObject.AddComponent<CMountPoint>();
			mp.AutoCreate();
		}

		private void OnLeave(string s) {
			switch (s) {
				case "attack0":
					ProcessEvent(CharacterFSM.Event.Stop_attack);
					break;
				case "skill0":
					ProcessEvent(CharacterFSM.Event.Stop_skill);
					break;
			}
		}

		public void ProcessEvent(CharacterFSM.Event e, object o = null) {
			FSM.processEvent(e, o);
		}

		private void OnRunIn(object o) {
			animator.SetBool("run", true);
		}
		private void OnRunOut(object o) {
			animator.SetBool("run", false);
		}

		private void OnAttackIn(object o) {
			animator.SetTrigger("attack");
		}

		private void OnIdleIn(object o) {
			animator.CrossFade("stand", 0.1f);
		}

		private void OnSkillIn(object o) {
			animator.SetTrigger("skill");
		}

		private void OnDeathIn(object o) {
			animator.SetTrigger("death");
		}

	}
}