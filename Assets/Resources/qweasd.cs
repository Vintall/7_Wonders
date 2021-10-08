using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class qweasd : MonoBehaviour, IPunObservable
{
    bool a = false;
    public void ChangeColor()
    {
        if (!GetComponent<PhotonView>().IsMine)
            return;

        if(a)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        a = !a;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            Debug.Log("send");
            stream.SendNext(x);
            stream.SendNext(y);
        }
        else
        {
            Debug.Log("receive");
            x = (int)stream.ReceiveNext();
            y = (int)stream.ReceiveNext();
        }
    }

    void Start()
    {
        if (!GetComponent<PhotonView>().IsMine)
            transform.GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Image>().gameObject.SetActive(false);
    }
    int x = 0, y = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            x = -2;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            y = 2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            x = 2;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            y = -2;
        }

        transform.position = new Vector3(x, y, -7);
    }
}
