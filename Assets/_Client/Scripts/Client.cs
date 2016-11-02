using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace GameClient {


	public class Client : Singleton<Client> {

		public ModGame Game;
		public ModPlayer Player;
		public ModEnemy Enemy;


		[RuntimeInitializeOnLoadMethod]
		static void Init() {
			Instantiate(Resources.Load("Client"));
		}


	}
}
