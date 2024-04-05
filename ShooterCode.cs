// Code Written by Belistov
// Designed to be a universal gun script

using UnityEngine;
using System.Collections;

public class ShooterCode : MonoBehaviour
{
    [Header("< Main Cam / Player >")]
    [SerializeField] private mouseLook cam;
    private float originalSensitivity;

    [SerializeField] private PlayerMovement _speed;
    private float originalSpeed;

    [SerializeField] private PlayerMovement _SprintSpeed;
    private float originalSprintSpeed;

    [Header("< Gun Settings >")]
    public bool is_auto;
    [Header("")]
    public float damage = 10f;
    public float fireRate = 15f;
    public float impactForce = 10f;
    [Header("")]
    public float aimDist = 30f;
    public float aimSens = 10f;
    public float aimWalkSpeed = 12f;
    public float aimSprintSpeed = 12f;
    public float range = 100f;
    [Header("")]
    public float maxAmmo = 10f;
    public float currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    [Header("< Gun Components >")]
    public GameObject muzzle;
    public Camera fpsCam;
    public AudioSource shoot_SFX;
    public LineRenderer bulletTrail; // Use LineRenderer for the bullet trail
    private Transform gunTransform;
    private Quaternion originalRotation;
    private float nextTimeToFire = 0f;

    void Start()
    {
        shoot_SFX = GetComponent<AudioSource>();
        shoot_SFX.Pause();

        originalSensitivity = cam.mouseSensitivity;
        originalSpeed = _speed.speed;
        originalSprintSpeed = _SprintSpeed.sprintSpeed;
        currentAmmo = maxAmmo;

        gunTransform = transform;
        originalRotation = gunTransform.localRotation;
    }

    void OnEnable()
    {
        isReloading = false;
    }

    void Update()
    {
        if (isReloading)
        {
            StartCoroutine(Reload());
            return;
        }
        if (currentAmmo <= 0 || Input.GetKeyDown("r"))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Aim();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            noAim();
        }

        if (is_auto == true)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
                shoot_SFX.Play(0);
            }
        }
        if (is_auto == false)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
                shoot_SFX.Play(0);
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        float elapsedTime = 0f;
        Quaternion startRotation = gunTransform.localRotation;
        Quaternion targetRotation = originalRotation * Quaternion.Euler(-30f, 0f, 0f);

        while (elapsedTime < reloadTime)
        {
            gunTransform.localRotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / reloadTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        noAim();

        gunTransform.localRotation = originalRotation;

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            healthCode target = hit.transform.GetComponent<healthCode>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            // Set the positions for the LineRenderer (bullet trail)
            bulletTrail.SetPosition(0, muzzle.transform.position);
            bulletTrail.SetPosition(1, hit.point);

            // Optionally add force to a rigidbody
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
        else
        {
            // If the ray doesn't hit anything, set the LineRenderer to a default length
            bulletTrail.SetPosition(0, muzzle.transform.position);
            bulletTrail.SetPosition(1, muzzle.transform.position + fpsCam.transform.forward * range);
        }
    }

    void Aim()
    {
        fpsCam.fieldOfView = aimDist;
        cam.mouseSensitivity = aimSens;
        _speed.speed = aimWalkSpeed;
        _SprintSpeed.sprintSpeed = aimSprintSpeed;
    }

    void noAim()
    {
        fpsCam.fieldOfView = 60;
        cam.mouseSensitivity = originalSensitivity;
        _speed.speed = originalSpeed;
        _SprintSpeed.sprintSpeed = originalSprintSpeed;
    }
}
