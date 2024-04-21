// Author: Injae Cho
// Contributor(s): Colby Heist

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public GameObject ShopScreen;
    public GameObject InventoryScreen;
    public GameObject PauseScreen;
    private Animator anim;
    private float movementX;
    private float movementY;
    private bool isAttacking;
    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isAttacking = false;

        ShopScreen.SetActive(false);
        InventoryScreen.SetActive(false);
        PauseScreen.SetActive(false);
    }

    void OnAttack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            // Might be better to make an animation controller as well idk
            anim.SetBool("IsAttacking", true);
            StartCoroutine("StopAttack");
        }
    }

    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }

    void OnShop()
    {
        if (!InventoryScreen.activeSelf && !PauseScreen.activeSelf) {
            ShopScreen.SetActive(!ShopScreen.activeSelf);
            if (ShopScreen.activeSelf) {
                Cursor.lockState = CursorLockMode.None;
            }
            else {Cursor.lockState = CursorLockMode.Locked;}
            Cursor.visible = !Cursor.visible;
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
    }

    void OnInventory()
    {
        if (!ShopScreen.activeSelf && !PauseScreen.activeSelf)
        {
            InventoryScreen.SetActive(!InventoryScreen.activeSelf);
            if (InventoryScreen.activeSelf) {
                Cursor.lockState = CursorLockMode.None;
            }
            else {Cursor.lockState = CursorLockMode.Locked;}
            Cursor.visible = !Cursor.visible;
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
    }

    void OnPause()
    {
        if (!ShopScreen.activeSelf && !InventoryScreen.activeSelf) {
            PauseScreen.SetActive(!PauseScreen.activeSelf);
            if (PauseScreen.activeSelf) {
                Cursor.lockState = CursorLockMode.None;
            }
            else {Cursor.lockState = CursorLockMode.Locked;}
            Cursor.visible = !Cursor.visible;
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        } else
        {
            if (ShopScreen.activeSelf)
            {
                ShopScreen.SetActive(!ShopScreen.activeSelf);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = !Cursor.visible;
                Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            }
            else if (InventoryScreen.activeSelf)
            {
                InventoryScreen.SetActive(!InventoryScreen.activeSelf);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = !Cursor.visible;
                Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (isAttacking)
            {
                if (movement.killMode) {
                    Destroy(other.gameObject);
                } else {
                    if (other.GetComponent<Animator>() != null)
                    {
                        other.GetComponent<Animator>().SetBool("IsStunned", true);
                        StartCoroutine("StartAnimation", other);
                    } else
                    {
                        // Stuns Shooting Ghost by shutting off detectplayer's shoot function
                        other.gameObject.transform.GetChild(3).GetComponent<DetectPlayer>().Stun();
                    }
                    other.GetComponent<Body>().Stun();
                }
                
            }
        }
    }

    IEnumerator StartAnimation(Collider other)
    {
        yield return new WaitForSeconds(2f);
        other.gameObject.GetComponent<Animator>().SetBool("IsStunned", false);
    }
}
