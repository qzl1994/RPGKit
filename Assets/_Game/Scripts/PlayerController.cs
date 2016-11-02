// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public class PlayerController : Singleton<PlayerController> {
		public ETCJoystick Joystick;
		public ETCButton AttackButton;
		public ETCButton SkillButton;
		[NonSerialized]
		public Hero hero;

		void Start() {
			Joystick.onMove.AddListener(OnMove);
			Joystick.onMoveEnd.AddListener(OnMoveEnd);
			AttackButton.onPressed.AddListener(OnAttackPressed);
			SkillButton.onPressed.AddListener(OnSkillPressed);
		}

		private void OnSkillPressed() {
			hero.cState.ProcessEvent(CharacterFSM.Event.Skill);
		}

		private void OnAttackPressed() {
			hero.cState.ProcessEvent(CharacterFSM.Event.Attack);
		}

		private void OnMoveEnd() {
			hero.cState.ProcessEvent(CharacterFSM.Event.Stop_run);
		}

		private void OnMove(Vector2 dir) {
			Vector3 worldDir = new Vector3(dir.x, 0f, dir.y);
			hero.cState.ProcessEvent(CharacterFSM.Event.Run, worldDir);
			hero.cRun.Move(worldDir);
		}



	}
}