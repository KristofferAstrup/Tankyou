using UnityEngine;
using System.Collections;
using Assets.States;
using States;

public class Main : MonoBehaviour {

    private StateController _stateController;

	void Start () {
        _stateController = new StateController();

        var gameState = new GameState();
        _stateController.Push(gameState);
	}
	
	void Update () {
        _stateController.Update(Time.deltaTime);
	}
}
