using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderMenu : MonoBehaviour
{
    private bool isActiveImage=false;
    [SerializeField]private GameObject background;
    
    public GameObject[]BuildList;
    private GameObject currentBuild=null;
    public Transform BuildPoint;
    void Start()
    {
        background.SetActive(isActiveImage);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            isActiveImage = !isActiveImage;
            background.SetActive(isActiveImage);
        }

        currentBuild.transform.rotation = Quaternion.Euler(0,0,0);
        if (Input.GetMouseButtonDown(0))
        {
            if (currentBuild != null)
            {
                Instantiate( currentBuild, BuildPoint.position, Quaternion.Euler(0,0,0));
                Destroy(currentBuild);
                currentBuild = null;
            }
        }
    }

    public void BuildThis(int number)
    {
        currentBuild = Instantiate( BuildList[number], BuildPoint.position, transform.rotation);
        currentBuild.transform.SetParent(BuildPoint);
    }
}
