// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Timer {

	private float _timer;
	public float time { get; set; }
	private Action _action;
	private bool _timeScale;


	public Timer(float time, Action action, bool timeScale = true) {
		_timer = 0f;
		this.time = time;
		_action = action;
		_timeScale = timeScale;
	}

	public void Update() {
		_timer += _timeScale ? Time.deltaTime : Time.unscaledDeltaTime;
		if (_timer >= time) {
			_timer = 0f;
			_action();
		}
	}
}
