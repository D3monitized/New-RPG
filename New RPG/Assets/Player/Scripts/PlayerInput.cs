using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInput : MonoBehaviour
{
	//Shown in inspector
	[Header("Mouse Settings")]
	[Range(1, 100)]
	public float Sensitivity;
	[Range(1, 100)]
	public float ScrollSensitivity;

	[FormerlySerializedAs("KeyBindings")] [Header("Keyboard Settings")]
	public KeyCode[] CommandButtons; 

	//Not shown in inspector
	public static Vector2 movementDir;
	public static Vector2 mouseDir;
	public static bool leftMouse;
	public static bool leftMouseDown; 
	public static bool rightMouse;
	public static bool rightMouseDown; 
	public static float scroll; 
	public static float sensitivity;
	public static float scrollSensitivity;
	public static KeyCode[] commandButtons; 


	private Vector2 rawMovementDir;
	private Vector2 rawMouseDir;

	private void Start()
	{
		sensitivity = Sensitivity;
		scrollSensitivity = ScrollSensitivity;
		commandButtons = CommandButtons; 
	}

	private void Update()
	{
		UpdatePlayerInput();
	}

	private void UpdatePlayerInput()
	{
		rawMovementDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
		movementDir = Vector2.Lerp(movementDir, rawMovementDir, 1); //1 is good number

		rawMouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		mouseDir = Vector2.Lerp(mouseDir, rawMouseDir, 1);
		scroll = Input.GetAxisRaw("Mouse ScrollWheel"); 
		leftMouse = Input.GetMouseButton(0);
		leftMouseDown = Input.GetMouseButtonDown(0);
		rightMouse = Input.GetMouseButton(1);
		rightMouseDown = Input.GetMouseButtonDown(1); 
	}
}
