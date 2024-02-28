# InterviewPrepScripts
Selected Scripts from the project Freud's Witness for review by Toukana Interactive GmbH

### 1.DraggbleScript

This script is a component in Unity that handles dragging an object. It implements the IDrag interface, has parameters to configure magnetic binding to another object, and contains an array of sound files to play when an object is successfully placed in its place. When the object stops being dragged, the script checks its position: if it is close enough to the specified magnetic object, the object is moved to its position and a sound effect is played, otherwise the object smoothly returns to its initial location.

![Screenshot_4](https://github.com/agatatelesh/InterviewPrepScripts/assets/41807041/bb6e17a6-5dfa-4fa4-a794-49274c5f53d6)

### 2. DragAndDropPuzzleManager

This script in Unity controls the solution to a drag-and-drop puzzle. It contains a Unity event to signal that the puzzle has been solved, and a boolean variable indicating whether the puzzle has been solved. The script also contains a list of objects of type `DraggbleScript` representing the dragged puzzle elements. In the `Update` method, it checks to see if all the dragged elements are in their places, and if so, it sets the `solved` flag to `true` and calls the `onPuzzleSolved` event.
