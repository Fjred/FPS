
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject hitPrefab;

    public GameObject gunfire;

    private AudioSource source;

    public AudioClip shootSound;

    public ParticleSystem smoke;

    public float maxDistance = 100;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

        gunfire.SetActive(false);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void DisableFlashEffect()
    {
        gunfire.SetActive(false);
    }

    void Shoot()
    {
        var cam = Camera.main;

        var ray = new Ray(cam.transform.position, cam.transform.forward);

        gunfire.SetActive(true);

        Invoke("DisableFlashEffect", 0.05f);

        source.pitch = Random.Range(0.8f, 1.2f);

        source.PlayOneShot(shootSound);

        if (Physics.Raycast(ray, out var hit, maxDistance))
        {

            print(hit.point);

            var hitObject = Instantiate(hitPrefab, hit.point, Quaternion.Euler(0, 0, 0));

            hitObject.transform.forward = hit.normal;
            hitObject.transform.position += hit.normal * 0.02f;

            ParticleSystem smoked = Instantiate(smoke, hit.point, Quaternion.identity);

            smoked.Play();
        }

    }
}
