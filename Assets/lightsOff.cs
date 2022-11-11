using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
public class lightsOff : MonoBehaviour
{
    // create camera list that can be updated in the inspector
    public List<Light> Lights;
    // create frame and button variables 
    private VisualElement frame;
    private Button lightsbutton;
	public float light_dimmed = 0.5f;
	public float light_on = 1f;
	public float light_off = 0f;
    // This function is called when the object becomes enabled and active.
    void OnEnable()
    {
        // get the UIDocument component (make sure this name matches!)
        var uiDocument = GetComponent<UIDocument>();
        // get the rootVisualElement (the frame component)
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("LightFrame");
        // get the button, which is nested in the frame
        lightsbutton = frame.Q<Button>("LightButton");
        // create event listener that calls ChangeCamera() when pressed
        lightsbutton.RegisterCallback<ClickEvent>(ev => ChangeLights());
    }
   
	private void ChangeLights(){ 
		if (Lights[0].intensity == light_on){
			Lights.ForEach(light => light.intensity = light_dimmed);
		} else if (Lights[0].intensity == light_dimmed){
			Lights.ForEach(light => light.intensity = light_off);
		} else if (Lights[0].intensity == light_off){
			Lights.ForEach(light => light.intensity = light_on);
		}
		
	}
}

    
    

//else {
//			Lights.ForEach(light => light.enabled = true);
//		if (Lights[0].intensity == intensity_one){
//			Lights.ForEach(light => light.enabled = false);
