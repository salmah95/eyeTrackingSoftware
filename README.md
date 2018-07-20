# eyeTrackingSoftware
README
1. REQUIRED SCRIPTS AND ASSETS
   To be able to track and use the VR Headset, download or import from the asset store VR Standard assets, this contains:
        - VRDeviceManager
        - VREyeRaycaster
        - VRFPSCounter
        - VRInteractiveItem
        - VRInput
        - VRTrackingReset
    For the purpose of this sotware the only scripts to be used from this asset are, VRInteractiveItem and a modified VREyeRaycaster 
    which can be found in the git repository. The final script needed can be found in the VRSampleScene folder, the script which will be used 
    with the software is the ExampleInteractiveItem script.
 
2. MODIFIED SCRIPTS
   The above asset provides the base functionality to be able to interact with the VRHeadset and approximate the eye ray.  To extent on this
   two of the scripts where modified, VRExampleInteractiveItem provides the functionlity for the heatmap and the logFile summary. VREyeRaycast
   provdes the visulization of the eye raycast on to the objects.
  
3. HOW TO USE THE SCRIPTS
   a) Heatmap and log file summary:
      For the items/prefabs in the scene that you want to know how long they have been looked at, attach the VRInteravtive item script to
      it, this will tell the raycast from the VRHeadset to detect collisions from the raycast to the collider that surroumds the item.
      Make sure that the item you want to be interactive has a box collider attached to it or the raycast will not be able to detect an 
      intersection! The next script to attach is the ExampleInteractiveItem, this script records how long the raycast has intersected with
      the item, and provides a colour depending on the timing, this created a heat map of the object in the scene by changing the colour
      of the texture of the material. The script will also create a txt file which lists every interactive objetc in the scene and the 
      timings of how long they have been looked at, to modify the path in which this file is saved go to the writeToLog function in the script.
      If you want to turn the heatmap function off during run time press 'm', if you want to turn it back on again, press the space bar.
    
    b) Eye tracking Visulaization:
       To be able to visulaize the point of intersection of the raycast on the object make sure the interactive item has a maesh collider
       as well as a box collider around it. The visulization of the raycast will automatically be applied to the interactive items, intially
       it will not be shown during run time, if you want it to show press 's' if you want to hide it again press 't'.
