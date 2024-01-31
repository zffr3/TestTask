using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _player.AttackWithSplashCast();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            _player.UseSpellToEnemy();
        }
    }
}
