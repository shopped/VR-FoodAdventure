using UnityEngine;
using System.Collections;
 
 public class Changer : MonoBehaviour
{
    //drag prefab here in editor
    public Transform OneController;
    public Transform ThreeControllerL;
    public Transform ThreeControllerR;

    // Update is called once per frame
    public void one()
    {
            var go = Instantiate(OneController, transform.position, transform.rotation);
    }

    public void three()
    {
        Debug.Log("Instanced");
        //var go = Instantiate(ThreeControllerL);
        //var go = Instantiate(ThreeControllerR);
    }
}
