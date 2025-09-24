# ClassExercise_05
A simple class assignment using AddRelativeForce created by Max Valle.

I chose the racecar scenario. I didn't add any particular obstacles other than the walls of the track, but you'll find that it's still quite difficult. 

Included in the scene are some simple checkpoints that disappear when the player passes them. I was going to add an on-screen timer that counts how long it takes to get to each checkpoint, but I didn't get to it. There's also a Start line, that turns into the finish line after the player passes it. 

There are only three scripts in the scene, and the player "Mover" script does most of the heavy lifting. For simplicity, this script handles movement, collisions, and the audio playing. 

The second script is attached to the Start line and uses an IEnumerator to change the text to "FINISH" 3 seconds after the player passes under it. The final script is attached to the checkpoints and just destroys them when the player passes through a trigger zone. 