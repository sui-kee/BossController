using System.Collections;
using UnityEngine;

public class PlayerRangeMode : MonoBehaviour
{
    [SerializeField] private Onre enemy;
    [SerializeField] private Player player;
    [SerializeField] private GameObject fire_ball;
    [SerializeField] private Transform shootingPoint;
    private bool canFire = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.rangeMode)
        {
            AutoDirection();
            StartCoroutine(DragonFire());
        }
    }

    private void AutoDirection()
    {
        if (player.isFacingRight && player.rb.position.x > enemy.transform.position.x)
        {
            player.NormalFlip();
        }
        else if (!player.isFacingRight && player.rb.position.x < enemy.transform.position.x)
        {
            player.NormalFlip();
        }
    }
    private IEnumerator DragonFire()
    {
        if(canFire)
        {
            canFire = false;
            yield return new WaitForSeconds(1.20f);
            Instantiate(fire_ball, shootingPoint.transform.position, shootingPoint.rotation);
            canFire = true;
        }
    }
}
