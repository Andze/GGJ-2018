using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float verticalOffset;
	public float lookAheadDstX;
	public float lookSmoothTimeX;
	public float verticalSmoothTime;
	public Vector2 focusAreaSize;

	FocusArea focusArea;

	float currentLookAheadX;
	float targetLookAheadX;
	float lookAheadDirX;
	float smoothLookVelocityX;
	float smoothVelocityY;

	bool lookAheadStopped;

    public float maxAngle = 10f;
    public float maxOffset = 1f;
    public float maxyOffset = 0.1f;
    public float calming = 0.05f;
    public float perlinTimescale = 10f;

    float shake;

    float angle;
    float xOffset;
    float yOffset;

    Transform shakeyCamera;
    Transform baseCamera;

    float seed1;
    float seed2;
    float seed3;

    void Start() {
		focusArea = new FocusArea (target.GetComponent<Collider2D>().bounds, focusAreaSize);
        shakeyCamera = transform;
        seed1 = Random.Range(0f, 100000f);
        seed2 = Random.Range(0f, 100000f);
        seed3 = Random.Range(0f, 100000f);

        baseCamera = transform;
	}

	void LateUpdate() {
		focusArea.Update (target.GetComponent<Collider2D>().bounds);

		Vector2 focusPosition = focusArea.centre + Vector2.up * verticalOffset;

		if (focusArea.velocity.x != 0) {
			lookAheadDirX = Mathf.Sign (focusArea.velocity.x);
			if (Mathf.Sign(target.GetComponent<Controller2D>().playerInput.x) == Mathf.Sign(focusArea.velocity.x) && target.GetComponent<Controller2D>().playerInput.x != 0) {
				lookAheadStopped = false;
				targetLookAheadX = lookAheadDirX * lookAheadDstX;
			}
			else {
				if (!lookAheadStopped) {
					lookAheadStopped = true;
					targetLookAheadX = currentLookAheadX + (lookAheadDirX * lookAheadDstX - currentLookAheadX)/4f;
				}
			}
		}


		currentLookAheadX = Mathf.SmoothDamp (currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);

		focusPosition.y = Mathf.SmoothDamp (baseCamera.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
		focusPosition += Vector2.right * currentLookAheadX;
		transform.position = (Vector3)focusPosition + Vector3.forward * -10;
        transform.eulerAngles = Vector3.zero;

        Shake();
	}

    private void Shake()
    {
        baseCamera = transform;
        if (Mathf.Abs(WorldState.Trauma) >= 1f)
        {
            WorldState.Trauma = 1f;
        }
        shake = Mathf.Pow(WorldState.Trauma, 2f);

        angle = maxAngle * shake * ((Mathf.PerlinNoise(seed1, Time.time * perlinTimescale) * 2f) - 1f);
        xOffset = maxOffset * shake * ((Mathf.PerlinNoise(seed2, Time.time * perlinTimescale) * 2f) - 1f);
        yOffset = maxyOffset * shake * ((Mathf.PerlinNoise(seed3, Time.time * perlinTimescale) * 2f) - 1f);

        shakeyCamera.eulerAngles = new Vector3(0f, 0f, baseCamera.eulerAngles.z + angle + WorldState.CameraANgle);
        shakeyCamera.position = new Vector3(xOffset + baseCamera.position.x, yOffset + baseCamera.position.y, -10f);

        transform.eulerAngles = shakeyCamera.eulerAngles;
        transform.position = shakeyCamera.position;
        WorldState.Trauma = Mathf.MoveTowards(WorldState.Trauma, 0f, calming);
    }

    void OnDrawGizmos() {
		Gizmos.color = new Color (1, 0, 0, .5f);
		Gizmos.DrawCube (focusArea.centre, focusAreaSize);
	}

	struct FocusArea {
		public Vector2 centre;
		public Vector2 velocity;
		float left,right;
		float top,bottom;


		public FocusArea(Bounds targetBounds, Vector2 size) {
			left = targetBounds.center.x - size.x/2;
			right = targetBounds.center.x + size.x/2;
			bottom = targetBounds.min.y;
			top = targetBounds.min.y + size.y;

			velocity = Vector2.zero;
			centre = new Vector2((left+right)/2,(top +bottom)/2);
		}

		public void Update(Bounds targetBounds) {
			float shiftX = 0;
			if (targetBounds.min.x < left) {
				shiftX = targetBounds.min.x - left;
			} else if (targetBounds.max.x > right) {
				shiftX = targetBounds.max.x - right;
			}
			left += shiftX;
			right += shiftX;

			float shiftY = 0;
			if (targetBounds.min.y < bottom) {
				shiftY = targetBounds.min.y - bottom;
			} else if (targetBounds.max.y > top) {
				shiftY = targetBounds.max.y - top;
			}
			top += shiftY;
			bottom += shiftY;
			centre = new Vector2((left+right)/2,(top +bottom)/2);
			velocity = new Vector2 (shiftX, shiftY);
		}
	}

}
