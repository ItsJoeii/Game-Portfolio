using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesImageDisplay : MonoBehaviour
{
    public GameObject bulletTurret;
    public GameObject rocketLauncher;
    public GameObject laserBeamer;

    public void displayBulletTurret()
    {
        bulletTurret.SetActive(true);
        rocketLauncher.SetActive(false);
        laserBeamer.SetActive(false);
    }

    public void displayRocketLauncher()
    {
        bulletTurret.SetActive(false);
        rocketLauncher.SetActive(true);
        laserBeamer.SetActive(false);
    }

    public void displayLaserBeamer()
    {
        bulletTurret.SetActive(false);
        rocketLauncher.SetActive(false);
        laserBeamer.SetActive(true);
    }
}
