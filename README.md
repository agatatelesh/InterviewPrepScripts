# InterviewPrepScripts
Selected Scripts from the project Freud's Witness for review by Toukana Interactive GmbH

### 1.DraggbleScript

This script is a component in Unity that handles dragging an object. It implements the `IDrag` interface, has parameters to configure magnetic binding to another object, and contains an array of sound files to play when an object is successfully placed in its place.
When the object stops being dragged, the script checks its position: if it is close enough to the specified magnetic object, the object is moved to its position and a sound effect is played, otherwise the object smoothly returns to its initial location.

![Screenshot_4](https://github.com/agatatelesh/InterviewPrepScripts/assets/41807041/bb6e17a6-5dfa-4fa4-a794-49274c5f53d6)

#### Example on the IDrag script:

public interface IDrag {
    void onStartDrag();
    void onEndDrag();
}

### 2. DragAndDropPuzzleManager

This script in Unity controls the solution to a drag-and-drop puzzle. It contains a Unity event to signal that the puzzle has been solved, and a boolean variable indicating whether the puzzle has been solved. The script also contains a list of objects of type `DraggbleScript` representing the dragged puzzle elements. In the `Update` method, it checks to see if all the dragged elements are in their places, and if so, it sets the `solved` flag to `true` and calls the `onPuzzleSolved` event.

![Screenshot_3](https://github.com/agatatelesh/InterviewPrepScripts/assets/41807041/1f298b66-235c-4831-9447-0483086ebd80)

### 3. Object Placement Checker

This script in Unity is responsible for checking the location of objects in the scene and controlling the character animations and sound effects depending on whether the objects are in their proper places. It keeps track of the number of objects in the right place and turns on various character animations and sound effects accordingly. By referencing other components, such as `DraggbleScript` for tracking the state of objects, and animation and sound components, this script controls various aspects of puzzle-related interaction in the scene.

![Screenshot_2](https://github.com/agatatelesh/InterviewPrepScripts/assets/41807041/3618b0bf-0d13-466b-92ea-7150fd85a2b8)
