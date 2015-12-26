using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScreenTextCtrl : MonoBehaviour {

	public Text text;
	bool hasKey = false;
	bool hasMirror = false;
	bool hasOpenedChest = false;
	int  whichCorridor = 0;

	private enum States {start_state, 
		cell_0, bunk_0, door_0, mirror, poster, cell_1, bunk_1, door_1, cell2_0, bunk2_0, door2_0, 
		key_0, cell2_1, door2_1, corridor_0, floor_0, stairs_0,
		closet_0, corridor_1, stairs_1, closet_1, corridor_2, stairs_2, closet_2, freedom,
		poster_1, treasure_chest_0, treasure_chest_1, special_surprise,
		end_state};

	private States myState;
	// Use this for initialization
	void Start () {
		myState = States.start_state;
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.start_state){
			start_state();
		}
		else if(myState == States.cell_0){
			cell_0();
		}
		else if(myState == States.bunk_0){
			bunk_0();
		}
		else if(myState == States.door_0){
			door_0();
		}
		else if(myState == States.mirror){
			mirror();
		}
		else if(myState == States.cell_1){
			cell_1();
		}
		else if(myState == States.poster){
			poster();
		}
		else if(myState == States.bunk_1){
			bunk_1();
		}
		else if(myState == States.door_1){
			door_1();
		}
		else if(myState == States.cell2_0){
			cell2_0();
		}
		else if(myState == States.bunk2_0){
			bunk2_0();
		}
		else if(myState == States.door2_0){
			door2_0();
		}
		else if(myState == States.cell2_1){
			cell2_1();
		}
		else if(myState == States.door2_1){
			door2_1();
		}
		else if(myState == States.corridor_0){
			corridor_0();
		}
		else if(myState == States.floor_0){
			floor_0();
		}
		else if(myState == States.stairs_0){
			stairs_0();
		}
		else if(myState == States.closet_0){
			closet_0();
		}
		else if(myState == States.corridor_1){
			corridor_1();
		}
		else if(myState == States.stairs_1){
			stairs_1();
		}
		else if(myState == States.closet_1){
			closet_1();
		}
		else if(myState == States.corridor_2){
			corridor_2();
		}
		else if(myState == States.stairs_2){
			stairs_2();
		}
		else if(myState == States.freedom){
			freedom();
		}
		else if(myState == States.end_state){
			end_state();
		}

		//New states added to FSM are coded here:
		else if(myState == States.poster_1){ //Viewing poster after having taken the mirror should lead back to cell_1.
			poster_1();
		}
		else if(myState == States.treasure_chest_0){ //Treasure chest shouldn't open without key found in cell2 bunk sheets.
			treasure_chest_0();
		}
		else if(myState == States.treasure_chest_1){ //Treasure chest will open if the player has key
			treasure_chest_1();
		}
		else if(myState == States.special_surprise){ //Treasure chest opened! Fast forward to special message and then win the game immediately.
			special_surprise();
		}
	}

	void start_state(){
		text.text = "This is a very short text based prison break that you have to complete. " +
					"If, in case you don't want to spend time solving this (it'll barely take 5 minutes, though.) " +
					"you can simply press Enter to head straight to the end.\n\n" +
					"Otherwise, press S to Start.";

		if(Input.GetKeyDown(KeyCode.Return)){
			myState = States.end_state;
		}
		else if(Input.GetKeyDown(KeyCode.S)){
			myState = States.cell_0;
		}
	}

	void cell_0(){
		text.text = "You wake up, tired. Rays of sunlight are creeping in under the door of your cell. Judging by the orange glow of the light " +
					"it must be early, yet. You get up, stretching and look around; there is a mirror on your left, a poster on your right, your bunk that you got off of " +
					"and the door. After just a couple days in here, you know you want to leave here.\n\n" +
					"Press B to look at Bunk, M to look at Mirror, P to look at Poster, and D to check out the Door.";
		if(Input.GetKeyDown(KeyCode.B)){
			myState = States.bunk_0;
		}
		if(Input.GetKeyDown(KeyCode.M)){
			myState = States.mirror;
		}
		if(Input.GetKeyDown(KeyCode.D)){
			myState = States.door_0;
		}
		if(Input.GetKeyDown(KeyCode.P)){
			myState = States.poster;
		}
	}

	void bunk_0(){
		text.text = "There are some dirty sheets lying in a heap on a very hard mattress that could easily pass off as a piece of wood had it not been " +
					"for the stuffing coming out from the torn edges. You cannot believe that you slept on these things. Perks of prison life, eh?\n\n" +
					"Press R to Return to looking around your cell.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_0;
		}
	}

	void door_0(){
		text.text = "The door is locked and very cold. There is a combination lock on the door. Maybe you could unlock it if you could " +
					"see the finger prints on the numberpad? You push the door but it doesn't yield.\n\n" +
					"Press R to go back and look around your cell";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_0;
		}
	}

	void mirror(){
		text.text = "The mirror on the wall is probably the only thing which is not dirty. You look into it, your face looks back at you. " +
					"The mirror is hanging loose, you could take it off the wall.\n\n" +
					"Press T to Take the mirror, or R to go back and look around your cell.";
		if(Input.GetKeyDown(KeyCode.T)){
			hasMirror = true;
			myState = States.cell_1;
		}
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_0;
		}
	}

	void poster(){
		text.text = "You inspect the poster. It was there when you were shifted to this cell. Still, somehow, this is the first time you are actually " +
					"seeing it properly. It shows a gun pointing at the left edge held in a skeletal hand. Nevertheless, something about this poster is intriguing.\n\n" +
					"Press T to Tear the poster off the wall, or R to go back to looking around your cell.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_0;
		}
		if(Input.GetKeyDown(KeyCode.T)){
			myState = States.cell2_0;
		}
	}

	void bunk_1(){
		text.text = "Holding the mirror in your hand doesn't really make the bed look any better. It's still as unkempt as it was.\n\n" +
					"Press R to go back and continue looking around.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_1;
		}
	}

	void cell_1(){
		text.text = "You have the mirror in your hand now. You look around at the bunk, the door and the poster. All sitting there " +
					"as if taunting your inability to escape. You don't want to be stuck here forever.\n\n" +
					"Press B to view Bunk, D to look at the Door and P to view the Poster.";
		if(Input.GetKeyDown(KeyCode.B)){
			myState = States.bunk_1;
		}
		if(Input.GetKeyDown(KeyCode.D)){
			myState = States.door_1;
		}
		if(Input.GetKeyDown(KeyCode.P)){
			myState = States.poster_1;
		}
	}

	void poster_1(){
		text.text = "You inspect the poster. It was there when you were shifted to this cell. Still, somehow, this is the first time you are actually " +
			"seeing it properly. It shows a gun pointing at the left edge held in a skeletal hand. Nevertheless, something about this poster is intriguing.\n\n" +
				"Press T to Tear the poster off the wall, or R to go back to looking around your cell.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_1;
		}
		if(Input.GetKeyDown(KeyCode.T)){
			myState = States.cell2_0;
		}
	}

	void door_1(){
		text.text = "The door is still as firmly locked as before and if possible, even colder. Maybe you could use the mirror to see the fingerprints on the " +
					"lock outside the door and push the keys from back here, accordingly?\n\n" +
					"Press U to Unlock the door, or R to go back to your cell.";
		if(Input.GetKeyDown(KeyCode.U)){
			myState = States.corridor_0;
		}
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_1;
		}
	}

	void cell2_0(){
		text.text = "You are in another room, exactly the same as yours, only scarier. The walls here are stained with what looks a lot like " +
					"it could be blood. There are names and dates scratched on the walls everywhere. No mirrors here, though. Only a bunk and a locked door.\n\n" +
					"Press B to check Bunk, D to try unlocking the door, or R to go back to your own cell";
		if(Input.GetKeyDown(KeyCode.B)){
			myState = States.bunk2_0;
		}
		if(Input.GetKeyDown(KeyCode.D)){
			myState = States.door2_0;
		}
		if(Input.GetKeyDown(KeyCode.R)){
			if(hasMirror == true) {
				myState = States.cell_1;
			}
			else if(hasMirror == false) {
				myState = States.cell_0;
			}
		}
	}

	void bunk2_0(){
		text.text = "You inspect the sheets of the bed and a key falls out of them. Maybe this is the key to the door in one of these cells!\n\n" +
					"Press R to leave key and continue looking around the cell, or press T to take key.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell2_0;
		}
		if(Input.GetKeyDown(KeyCode.T)){
			hasKey = true;
			myState = States.cell2_1;
		}
	}

	void door2_0(){
		text.text = "You push the door, it doesn't budge! You push it harder but it still doesn't move. It's either locked or something is probably stuck on the other side. " +
					"There doesn't seem to be a way out from here.\n\n" + 
					"Press R to go back to looking around the cell.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell2_0;
		}
	}

	void cell2_1(){
		text.text = "This cell is giving you the creeps. There's a bad aura about the place. Perhaps it's the blood stains and the scratches, " +
					"but all you know is that you wanna get the hell out of here ASAP!\n\n" +
					"Press R to go back to your own cell, atleast it feels safe, or Press D to try the door.";
		if(Input.GetKeyDown(KeyCode.R)){
			if(hasMirror == true) {
				myState = States.cell_1;
			}
			else if(hasMirror == false) {
				myState = States.cell_0;
			}
		}
		if(Input.GetKeyDown(KeyCode.D)){
			myState = States.door2_1;
		}
	}

	void door2_1(){
		text.text = "You have a key! Excited you walk over to the door, but the key won't fit. Disheartened you let it go.\n\n" +
					"Press R to go back to looking around the cell.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell2_1;
		}
	}

	void corridor_0(){
		whichCorridor = 0;
		text.text = "You are in a brightly lit corridor, with tiled floors and yellowing walls that you're pretty sure must have been " +
					"white, originally. As your eyes adjust to the sudden flood of light, you take in your surroundings. " +
					"There is a closet at the far end of the corridor and a chest beside it. To your right are the stairs that lead up " +
					"to the concourse and (potentially) your freedom.\n\n" +
					"Press C to check the Closet, Press T to open the Treasure Chest, Press S to climb up the Stairs, Press F to look at the floor, or Press R to return to your cell.";
		if(Input.GetKeyDown(KeyCode.C)){
			myState = States.closet_0;
		}
		if(Input.GetKeyDown(KeyCode.T)){
			if(hasKey == true) {
				myState = States.treasure_chest_1;
			}
			else if(hasKey == false) {
				myState = States.treasure_chest_0;
			}
		}
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_0;
		}
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_1;
		}
		if(Input.GetKeyDown(KeyCode.F)){
			myState = States.floor_0;
		}
	}

	void floor_0(){
		text.text = "You look down and see a hairclip lying on the otherwise clean floor.\n\n" +
					"Press T to take the clip, or R to continue looking around the corridor.";
		if(Input.GetKeyDown (KeyCode.T)){
			myState = States.corridor_1;
		}
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_0;
		}
	}

	void stairs_0(){
		text.text = "You climb up the stairs, placing your steps lightly to avoid creating any sounds. When you reach the top landing " +
					"you see guards sitting around talking to each other, having their morning coffees and teas while " +
					"maintenance workers were passing in and out through the gates, the guards barely noticing them." +
					"Is it worth attempting to flee? No, it's too risky. There are too many guards.\n\n" +
					"Press R to return back to the corrdor.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_0;
		}
	}

	void closet_0(){

		if(hasKey == false){
			text.text = "You walk up to the closet and see a lock dangling from it's doors. If only you had something you could pick the lock with!" +
						"\n\n" +
						"Press R to continue looking around the corridor.";
		}
		else if(hasKey == true) {
			text.text = "You walk up to the closet and see a lock dangling from it's doors. No worries, you have a key! You put the key inside " +
						"the lock and turn it, but it doesn't turn. Maybe this key belongs to some other lock.\n\n" +
						"Press R to continue looking around the corridor.";
		}
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_0;
		}
	}

	void corridor_1(){
		whichCorridor = 1;
		text.text = "You have the clip in your pocket. The closet is on the far end of the corridor as is the treasure chest look alike. " +
					"Something tells you that the chest might not contain anything too exciting, but intuitions can be wrong.\n\n" +
					"Press C to try opening the closet, S to climb up the stairs, T to try to open the Treasure chest, or R to return to your cell.";
		if(Input.GetKeyDown(KeyCode.C)){
			myState = States.closet_1;
		}
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_1;
		}
		if(Input.GetKeyDown(KeyCode.T)){
			if(hasKey == true) {
				myState = States.treasure_chest_1;
			}
			else if(hasKey == false) {
				myState = States.treasure_chest_0;
			}
		}
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_1;
		}
	}

	void stairs_1() {
		text.text = "You climb up the stairs, but halfway through you hear the sounds of guards talking and moving around in the concourse above." +
					"It's probably not a good idea to walk out like this.\n\n" +
					"Press R to return to the corridor.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_1;
		}
	}

	void closet_1(){
		text.text = "You walk up to the closet and see a lock dangling from it's doors. Not a problem, you have a clip and you're great at picking locks!" +
					"You enter the closet and see that there's a maintenance worker's uniform hanging inside.\n\n" +
					"Press C to change into the worker's dress and exit the closet, or R to go back to the corridor in your own clothes.";
		if(Input.GetKeyDown(KeyCode.C)){
			myState = States.corridor_2;
		}
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_1;
		}
	}

	void corridor_2(){
		whichCorridor = 2;
		text.text = "You are dressed as a maintenance worker now. This might make it easier for you to escape unnoticed." +
					"There's the treasure chest on your side, and the stairs leading to the concourse and the courtyard.\n\n" +
					"Press S to climb the stairs, or T to attempt opening the chest.";
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_2;
		}
		if(Input.GetKeyDown(KeyCode.T)){
			if(hasKey == true) {
				myState = States.treasure_chest_1;
			}
			else if(hasKey == false) {
				myState = States.treasure_chest_0;
			}
		}
	}

	void stairs_2(){
		text.text = "You climb up the stairs, confidently, trying to look convincing as a maintenance worker. No one looks up as you pass the table " +
					"with the guards sitting on it, chatting and you try to hide your excitement as you cross the concourse and reach the gates " +
					"leading to the courtyard and your freedom!\n\n" +
					"Press W to Walk out of the prison and complete the game.";
		if(Input.GetKeyDown(KeyCode.W)){
			myState = States.freedom;
		}
	}

	void freedom(){
		text.text = "Congratulations (and thanks!) on completing this game!\n" +
					"Happy birthday! It's so amazing that we've known each other for like 6 years now! Time sure flew by, eh? " +
					"I just wanted to keep in line with my tradition of attempting to pleasantly surprise you with a variety of " +
					"ways to wish you on your special day! :D " +
					"Have an awesome one!\n" +
					"Lots of love and best wishes,\nAkshay!\n" +
					"PS: I want feedback :P I'm still learning this game development thingy! Promise you a 3D game next year :D\n" +
					"PPS: If you want to have another go, just press P.";
		if(Input.GetKeyDown(KeyCode.P)){
			hasKey = false;
			hasMirror = false;
			hasOpenedChest = false;
			whichCorridor = 0;
			myState = States.start_state;
		}
	}

	void end_state(){
		freedom ();
	}

	void treasure_chest_0() {
		text.text = "You walk over to the treasure chest and try to pry it open. It's locked, too. Big surprise. " +
					"You probably need a key for this.\n\n" +
					"Press R to continue looking around the corridor.";
		if(Input.GetKeyDown(KeyCode.R)){
			if(whichCorridor == 0) {
				myState = States.corridor_0;
			}
			else if(whichCorridor == 1){
				myState = States.corridor_1;
			}
			else if(whichCorridor == 2){
				myState = States.corridor_2;
			}
		}
	}

	void treasure_chest_1(){
		text.text = "You walk over to the treasure chest and try to pry it open. It's locked. You take out your key and put it inside the slot " +
					"on the lid. It fits perfectly.\n\n" +
					"Press O to open the treasure chest, or Press R to leave it and continue looking around the corridor";
		if(Input.GetKeyDown(KeyCode.O)){
			myState = States.special_surprise;
		}
		if(Input.GetKeyDown(KeyCode.R)){
			if(whichCorridor == 0) {
				myState = States.corridor_0;
			}
			else if(whichCorridor == 1){
				myState = States.corridor_1;
			}
			else if(whichCorridor == 2){
				myState = States.corridor_2;
			}
		}
	}

	void special_surprise(){
		text.text = "YOU HAVE UNLOCKED A SPECIAL SURPRISE!!!\n" +
					"Since you've unlocked this, the rest of the game will be bypassed and you'll go straight to the final scene, " +
					"where the original birthday wish resides :D\n" +
					"I hope you liked this, weird, geeky nerdy thing :P Have fun, girl, and a happy birthday to you, once again <3\n\n" +
					"Press F to continue...";
		if(Input.GetKeyDown(KeyCode.F)){
			myState = States.freedom;
		}
	}
}
