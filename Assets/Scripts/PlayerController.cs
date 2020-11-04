using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

  private GameObject _slotRun;
  private Rigidbody2D _rigid;
  private Animator _animator;
  private Transform _floorPoint;
  private float _speed = 2f;
  private float _jumpForce = 5f;
  private bool _isGrounded;
  private int _numCommands = 0;
  private int _currentCommand = 0;

  
  private void Awake() {
    _rigid = GetComponent<Rigidbody2D>();    
    _animator = GetComponent<Animator>();
    _slotRun = GameObject.FindWithTag("Slot Run");
    _floorPoint = transform.Find("FloorPoint");  
  }

  private void Update() {
    // Is Grounded?
    _isGrounded = Physics2D.OverlapCircle(_floorPoint.position, 0.025f, LayerMask.GetMask("Ground"));
  }

  private void LateUpdate() {
    // Animations
    _animator.SetBool("Idle", _rigid.velocity == Vector2.zero);
    _animator.SetBool("isGrounded", _isGrounded);
    _animator.SetFloat("VerticalVelocity", _rigid.velocity.y);
  }

  public void ButtonRun() {   
    _numCommands = _slotRun.transform.childCount;
    _currentCommand = 0;

    RunCommands();
  }

  private void RunCommands() {
    GameObject block = _slotRun.transform.GetChild(_currentCommand).gameObject;

    switch(block.tag) {
      case "Walk":
          StartCoroutine("Walk");
          break;

      case "Jump":
          StartCoroutine("Jump");
          break;
    }
  }

  private IEnumerator Walk() {
    _rigid.velocity = Vector2.right * _speed;
    yield return new WaitForSeconds(0.5f);
    _rigid.velocity = Vector2.zero;

    _currentCommand++;

    if(_currentCommand < _numCommands) {
        Invoke("RunCommands", 0f); 
    }
  }

  private IEnumerator Jump() {
    _rigid.AddForce(new Vector2(0.2f, 1f) * _jumpForce, ForceMode2D.Impulse);
    yield return new WaitForSeconds(0.5f);

    _currentCommand++;

    if(_currentCommand < _numCommands) {
      Invoke("RunCommands", 0f);
    }
  }
}
