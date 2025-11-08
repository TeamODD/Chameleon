using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager _playerInputManager;


    void Update()
    {
        _playerInputManager.movePlayer();
    }


}
