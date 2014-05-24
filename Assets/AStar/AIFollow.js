var target : Transform;
var moveSpeed = 3;
var rotationSpeed = 3;
var myTransform : Transform;
var distance = 1;
var player : Transform;

function Awake() {
 	myTransform = transform;
}
 
function Start() {
 	target = GameObject.FindWithTag("Player").transform;
}
 
function Update () {
	var distance_one = Vector3.Distance(target.transform.position, transform.position);

	if(distance_one > distance){
		transform.LookAt(Vector3(target.position.x, transform.position.y, target.position.z));
		myTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}
	else{
		transform.LookAt(Vector3(target.position.x, transform.position.y, target.position.z));
	}
	
}
// 	if(Vector3.Distance(transform.position, player.position) < distance){
// 		if(Vector3.Distance(transform.position, player.position) > distanceAttack){
// 			moveSpeed = 2;
// 			animation.Play("walk");
// 			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
// 			Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
// 			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
//}
// 
//if(Vector3.Distance(transform.position, player.position) < distanceAttack){
//	moveSpeed = 0;
//	animation.Play("attack");
//	}
//}
//
//else{
//	moveSpeed = 0;
//	animation.CrossFade("idle");
//	}
//}