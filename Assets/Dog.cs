using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject person;
    public GameObject ball;
    public int distance = 10;

    public class GoToPerson : State {

        Vector3 target;
        Dog dog;

        public override void Enter() {
            dog = owner.GetComponent<Dog>();

            owner.GetComponent<Arrive>().enabled = true;
        }

        public override void Think() {

            if(Vector3.Distance(dog.transform.position, dog.person.transform.position) > dog.distance) {

                target = Camera.main.transform.position + Camera.main.transform.forward * dog.distance;
                target.y = 0;

                owner.GetComponent<Arrive>().targetPosition = target;
            }
        }
    }

    public class FetchBall : State {

    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new GoToPerson());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}