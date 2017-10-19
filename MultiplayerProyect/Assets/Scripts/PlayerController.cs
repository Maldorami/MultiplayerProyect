using UnityEngine;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour {

    public float rotateSpeed = 150.0f;
    public float movementSpeed = 3.0f;

    public GameObject bullet;
    public Transform bulleSpawnPoint;

    public float shootSpeed = 0.1f;

	void Update () {
        //Si no es el jugador local vuelve
        if (!isLocalPlayer) return;

        //Movement
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        //Attack
        shootSpeed -= Time.deltaTime;
        if (Input.GetButton("Fire1") && shootSpeed < 0)
        {
            CmdFire();
            shootSpeed = 0.1f;
        }
    }

    [Command]
    void CmdFire()
    {
        var _bullet = Instantiate(bullet, bulleSpawnPoint.position, transform.rotation);
        NetworkServer.Spawn(_bullet);

    }

    //Local Player Start
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        base.OnStartLocalPlayer();
    }
}
