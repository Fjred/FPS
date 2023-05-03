
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject hitPrefab;

    public GameObject gunfire;

    public AudioSource gunshotSound;

    public float maxDistance = 100;

    public float gunfireTime;

    private void Start()
    {

        gunfire.SetActive(false);
    }
    void Update()
    {

        if (Time.time < gunfireTime)
        {
            gunfire.SetActive(true);
        }
        else
        {
            gunfire.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            var ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out var hit, maxDistance))
            {
                
                print(hit.point);

                var hitObject = Instantiate(hitPrefab, hit.point, Quaternion.Euler(0, 0, 0));

                hitObject.transform.forward = hit.normal;
                hitObject.transform.position += hit.normal * 0.02f;

                gunshotSound.Play();

                gunfireTime = Time.time + 0.1f;
                
            }
        }
    }
}
