using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject fire_ball;
    [SerializeField] private Player player;
    [SerializeField] private Transform shootingPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !player.isAttacking && player.canShoot)
        {
            player.isAttacking = true;
            player.canShoot = false;
            player.comingAnimation = "PlayerShoot";
            StartCoroutine(PlayerShoot());
        }

    }
    // player shooting animation
    public IEnumerator PlayerShoot()
    {
        //if (player.canShoot)
        //{
            //player.canShoot = false;
            //player.isAttacking = true;
            player.comingAnimation = "PlayerFire";
            yield return new WaitForSeconds(0.40f);
            Instantiate(fire_ball, shootingPoint.position, shootingPoint.rotation);
            player.isAttacking = false;
            yield return new WaitForSeconds(0.20f);
            player.canShoot = true;
        //}
    }
}
