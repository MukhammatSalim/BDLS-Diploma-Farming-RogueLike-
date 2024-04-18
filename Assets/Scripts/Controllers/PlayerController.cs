using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    Vector3 mousePosition;
    public CharacterController characterController;
    [Header("Connections")]
    public PlayerData playerData;
    [Header("Shooting")]
    public GameObject BulletPrefab;
    public Transform GunEnd;
    bool CanShoot = true;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x));
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        characterController.Move(move * Time.deltaTime * playerData.MovementSpeed);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        if (CanShoot)
        {
            Debug.Log("Pew");
            GameObject bullet = BulletPrefab;
            bullet.GetComponent<BulletScript>().BulletLifeTime = playerData.BulletLifeTime; 
            GameObject NewBullet = Instantiate(bullet, GunEnd.transform.position, transform.rotation);
            Rigidbody2D b = NewBullet.GetComponent<Rigidbody2D>();
            b.AddForce(b.transform.up * playerData.BulletSpeed, ForceMode2D.Force);
            
            CanShoot = false;
            yield return new WaitForSeconds(playerData.FireRate);
            CanShoot = true;
        }
    }
}
