﻿// Author:
// [LongTianhong]
//
// Copyright (C) 2014 Nanjing Xiaoxi Network Technology Co., Ltd. (http://www.mogoomobile.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {

	public abstract class SkillAffectBase : SkillBaseAssist{

		public abstract void Affect(CBase c);
	}
}