// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace UI {

	public class StartButton : MonoBehaviour, IPointerClickHandler {

		public ChoosePlayerPanel ChoosePlayerPanel;

		public void OnPointerClick(PointerEventData eventData) {
			this.ChoosePlayerPanel.gameObject.SetActive(true);
		}
	}
}