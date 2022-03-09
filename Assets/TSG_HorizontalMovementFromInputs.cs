using UnityEngine;

public class TSG_HorizontalMovementFromInputs : MonoBehaviour, TSG_IMoveable
{
	[Header("Variables")]
	[SerializeField] float moveSpeed = 0f;

	[Header("Components")]
	Transform myTransform = null;

	private void Awake()
    {
		myTransform = transform;

	}

    public void Move()
    {
        controlByhNormalInputs();
        controlByTouchInputs();
    }

	private void controlByhNormalInputs()
	{
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			moveLeft();
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			moveRight();
		}
	}

	private void controlByTouchInputs()
	{
		if (Input.touchCount < 1)
		{
			return;
		}

		Touch _touch = Input.GetTouch(0);
		Vector2 _touchPosition = _touch.position;
		Vector2 _normalizedTouchPosition = normalizeTouchPosition(_touchPosition);

		if (_normalizedTouchPosition.x < 0.3f)
		{
			moveLeft();
		}
		else if (_normalizedTouchPosition.x > 0.7f)
		{
			moveRight();
		}
	}

	private void moveLeft()
	{
		Vector3 _position = myTransform.position;
		_position += moveSpeed * Time.deltaTime * -myTransform.right;
		myTransform.position = _position;
	}

	private void moveRight()
	{
		Vector3 _position = myTransform.position;
		_position += moveSpeed * Time.deltaTime * myTransform.right;
		myTransform.position = _position;
	}

	private Vector2 normalizeTouchPosition(Vector2 _position)
	{
		Vector2 _normalizedPosition = new Vector2(_position.x / Screen.width, _position.y / Screen.height);
		return _normalizedPosition;
	}
}
