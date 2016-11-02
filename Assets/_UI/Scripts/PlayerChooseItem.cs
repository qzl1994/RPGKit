// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameClient;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI {

	public class PlayerChooseItem : MonoBehaviour, IPointerClickHandler {

		public Text NameLabel;
		private HeroData data;

		public void Init(HeroData data) {
			this.data = data;
			this.NameLabel.text = data.Name;
		}

		public void OnPointerClick(PointerEventData eventData) {
			Client.Ins.Game.ChoosedHero = data;
			Client.Ins.Game.StartGame();
		}
	}
}