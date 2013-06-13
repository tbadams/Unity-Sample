var collisionSoundPrefab : GameObject;
var triggerMagnitude : float = 2;
var attachToMe : boolean = true;
 
function OnCollisionEnter( collision : Collision ) 
{
    if (collision.relativeVelocity.magnitude > triggerMagnitude)
    {
        var o : GameObject = Instantiate(collisionSoundPrefab, this.transform.position, this.transform.rotation);
        if(attachToMe) {
            o.transform.parent = transform;
        }   
    }
}