using UnityEngine;

public class jumpPadScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player player;

    private float speed = 2f;
    private float distance = 3f;
    private Vector3 startPosition;
    private GameObject jumpPad2;

    void Start()
    {
        jumpPad2 = GameObject.Find("jumpPad (1)");

        startPosition = jumpPad2.transform.position;
    }

    void Update()
    {
        if (player.isCollected)
        {
            gameObject.SetActive(false);
        }


    }
    private void FixedUpdate()
    {
        float move = Mathf.PingPong(Time.fixedTime * speed, distance);
        jumpPad2.transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z + move);
    }
}
