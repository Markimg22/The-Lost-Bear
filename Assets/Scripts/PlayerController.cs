using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region Fields

    private float _speedForce = 5f;
    private float _jumpForce = 10f;
    private Rigidbody2D _rigid;

    public GameObject slotCommands;

    #endregion



    #region Unity

    private void Awake() 
    {
        _rigid = GetComponent<Rigidbody2D>();    
    }

    #endregion



    #region Button

    public void ButtonRun()
    {
        for( int i = 0; i < slotCommands.transform.childCount; i++ )
        {
            Transform block = slotCommands.transform.GetChild( i );

            switch( block.name )
            {
                case "Command Walk":
                    Walk();
                    break;
                
                case "Command Jump":
                    Jump();
                    break;
            }
        }
    }

    #endregion



    #region Methods Controller

    public void Walk()
    {
        _rigid.AddForce( Vector2.right * _speedForce, ForceMode2D.Impulse );
    }

    public void Jump()
    {
        _rigid.AddForce( Vector2.up * _jumpForce, ForceMode2D.Impulse );
    }

    #endregion

}
