using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 1;

	public Vector3Event changeModelRotation; 

    private Rigidbody rb;

	private Transform cameraAxis;
	private Transform playerCamera; 
	private Transform pov;
	private Transform tp; 

	private float yRot = 0;
	private float xRot = 0;
	private float currentPlayerSpeed;
	private bool setRotation; 

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		cameraAxis = transform.Find("CameraAxis");
		playerCamera = GameObject.Find("Player Camera").transform; 
		pov = GameObject.Find("POV").transform;
		tp = GameObject.Find("TP").transform;		
	}

	private void Update()
	{
		if (PlayerInput.rightMouse)
			Rotation();
		else
			Cursor.lockState = CursorLockMode.None; 

		if (PlayerInput.scroll != 0)
			Zoom();

		currentPlayerSpeed = rb.velocity.magnitude; 
	}

	private void FixedUpdate()
	{
		if (PlayerInput.movementDir.x != 0 || PlayerInput.movementDir.y != 0)
		{
			Movement();
			changeModelRotation.Invoke(new Vector3(PlayerInput.movementDir.x, 0, PlayerInput.movementDir.y));
		}
		else
		{
			rb.velocity = new Vector3(0, rb.velocity.y, 0);
			changeModelRotation.Invoke(new Vector3(PlayerInput.movementDir.x, 0, PlayerInput.movementDir.y));
		}
				
	}

	private void Movement()
	{
		rb.velocity =
				(new Vector3(transform.right.x, rb.velocity.y, transform.right.z) * PlayerInput.movementDir.x + transform.forward * PlayerInput.movementDir.y) * movementSpeed;
	}

	private void Rotation()
	{
		Cursor.lockState = CursorLockMode.Locked;

		float sensitivity = PlayerInput.sensitivity / 10;

		if (!setRotation)
		{
			xRot = transform.eulerAngles.y;
			setRotation = true;
		}

		xRot += sensitivity * PlayerInput.mouseDir.x;
		transform.rotation = Quaternion.Euler(0, xRot, 0);

		yRot += sensitivity * -PlayerInput.mouseDir.y;
		yRot = Mathf.Max(yRot, -90);
		yRot = Mathf.Min(yRot, 90);
		cameraAxis.localRotation = Quaternion.Euler(yRot, 0, 0);
	}

	private void Zoom()
	{

		if (PlayerInput.scroll > 0) { playerCamera.position = Vector3.MoveTowards(playerCamera.position, pov.position, .1f * PlayerInput.scrollSensitivity / 10); }
		if (PlayerInput.scroll < 0) { playerCamera.position = Vector3.MoveTowards(playerCamera.position, tp.position, .1f * PlayerInput.scrollSensitivity / 10); }
		
	}	
}
