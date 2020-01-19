using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnLeftRightController : MonoBehaviour
{
    public Component btnLeft;
    public Component btnRight;

    public bool btnsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        btnLeft.gameObject.SetActive(btnsActive);
        btnRight.gameObject.SetActive(btnsActive);
    }

    public void SetActiveBtns(bool statusAcitve)
    {
        btnLeft.gameObject.SetActive(statusAcitve);
        btnRight.gameObject.SetActive(statusAcitve);
    }
}
