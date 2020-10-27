using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneQuizTrigger : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject questionMenu;
    [SerializeField]
    private GameObject heartsUI;
    [SerializeField]
    private GameObject buttonUI;
    [SerializeField]
    private GameObject joystickUI;
    private GameObject board;

    private bool crouch;
    // Start is called before the first frame update
    void Start()
    {
        board = this.gameObject;
        crouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetJoystickVertical() < -0.5f)
            crouch = true;
        else
            crouch = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && crouch == true)
        {
            heartsUI.SetActive(false);
            buttonUI.SetActive(false);
            joystickUI.SetActive(false);
            questionMenu.SetActive(true);
            Time.timeScale = 0.0f;

            Destroy(board);
        }
    }
}
