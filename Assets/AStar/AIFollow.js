var moveSpeed = 3;
var rotationSpeed = 3;
var myTransform : Transform;
var distance = 2;
var distanceAttack = .5;

var player : Transform;
var target : Transform;
var AIAnimation : Animator;

function Awake() {
 	myTransform = transform;
}
 
function Start() {
 	target = GameObject.FindWithTag("Player").transform;

	AIAnimation = gameObject.GetComponent(Animator);
}
 
function Update () {
	var distance_one = Vector3.Distance(target.transform.position, transform.position);

	if(distance_one < distance){
 		if(distance_one > distanceAttack) {
			transform.LookAt(Vector3(target.position.x, transform.position.y, target.position.z));
			myTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
 			
 			AIAnimation.Play("Walk");
 		}
	}
 
	if(Vector3.Distance(transform.position, player.position) < distanceAttack){
		transform.LookAt(Vector3(target.position.x, transform.position.y, target.position.z));
		moveSpeed = 0;
		AIAnimation.Play("Lumbering");
	}
	else{
		moveSpeed = 0;
		AIAnimation.Play("Idle");
	}

	/*if(distance_one > distance){
		transform.LookAt(Vector3(target.position.x, transform.position.y, target.position.z));
		myTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}
	else{
		transform.LookAt(Vector3(target.position.x, transform.position.y, target.position.z));
	}*/
	
}