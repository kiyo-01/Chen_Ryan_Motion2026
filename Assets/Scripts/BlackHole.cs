using UnityEngine;

public class BlackHole : MonoBehaviour
{
    //target
    public Player player;

    //black hole settings   
    public float pullRadius = 10f;
    public float maxPullForce = 5f;
    public float eventHorizon = 0.5f;

    void Update()
    {
        //get the offset between the black hole and the player
        Vector3 offset = transform.position - player.transform.position;
        float distance = offset.magnitude;

        //check if the player is within the pull radius
        if (distance < pullRadius)
        {
            //trap if inside event horizon
            if (distance <= eventHorizon)
            {
                //kill player momentum and snap to center
                player.currentVelocity = Vector3.zero;
                player.transform.position = transform.position;

                return; //stop regular pull once trapped
            }
            //calc pure direction towards black hole
            Vector3 pullDir = offset.normalized;

            //calc pull force based on distance (closer = stronger)
            //when dist = pullRadius, force = 0; when dist = 0, force = maxPullForce
            float gravityLevel = 1f - (distance / pullRadius);

            //add gravity vector to player velocity
            Vector3 appForce = pullDir * maxPullForce * gravityLevel;
            player.currentVelocity += appForce * Time.deltaTime;

        }
    }
}
