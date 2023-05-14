
using UnityEngine;
using UnityEngine.Events;


public class Gun : MonoBehaviour
{
    public GameObject hitPrefab;

    public GameObject gunfire;

    private AudioSource source;

    public AudioClip shootSound;

    public ParticleSystem smoke;

    public float maxDistance = 100;

    public UnityEvent onShoot;

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
        onShoot.Invoke();

        if (Physics.Raycast(ray, out var hit, maxDistance))
        {

            var health = hit.transform.GetComponent<Health>(); //null
            if (health)
            {
                health.Damage();
            }

            if(!hit.transform.CompareTag("Enemy"))
            {
                var hitObject = Instantiate(hitPrefab, hit.point, Quaternion.Euler(0, 0, 0), hit.transform);

                hitObject.transform.forward = hit.normal;
                hitObject.transform.position += hit.normal * 0.02f;
                var x = 1f / hit.transform.localScale.x;
                var y = 1f / hit.transform.localScale.y;
                var z = 1f / hit.transform.localScale.z;
                hitObject.transform.localScale = new Vector3(x, y, z);

                ParticleSystem smoked = Instantiate(smoke, hit.point, Quaternion.identity);

                smoked.Play();
            }
        }

    }
}
