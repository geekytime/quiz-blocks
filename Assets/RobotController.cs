using Platypus;
using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {

  public BoxCollider2D Confines;
  public float MinDelay = 0;
  public float MaxDelay = 1;
  public float MoveSpeed = 2;

  Facing facing;

  Bounds bounds;
  bool isMoving = false;
  Vector3 targetPosition;

  void Start()
  {
    bounds = Confines.bounds;    
    facing = GetComponent<Facing>();
  }

  void Update()
  {
    if (isMoving)
    {
      UpdateFacing();
      var moveSpeed = MoveSpeed * Time.deltaTime;
      transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);
      float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
      if (distanceToTarget < .05f)
      {
        SetNotMoving();
      }
    } else
    {
      targetPosition = ChooseTargetPosition();
      isMoving = true;
    }
  }

  Vector3 ChooseTargetPosition()
  {
    var x = Random.Range(bounds.min.x, bounds.max.x);
    return new Vector3(x, transform.position.y);
  }

  void SetNotMoving()
  {
    isMoving = false;
  }

  void UpdateFacing()
  {
    if (facing != null)
    {
      facing.FacingRight = (targetPosition.x < transform.position.x);
    }
  }
}
