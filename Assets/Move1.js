#pragma strict

var speed = 5.0;

function Start () {

}

function Update () {
	var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
	var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
	var y = Input.GetAxis("Jump") * Time.deltaTime * speed;
	transform.Translate(x, y, z);
}