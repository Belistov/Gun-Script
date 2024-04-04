# Gun-Script
A script I am designing to be versatile and usable with all and any guns without external scripts, except for player movements
<br>
For the code to work propperly please follow these steps.
1. Download/Copy the **gun** code into your unity project
    - [Get the code](https://github.com/Belistov/Gun-Script/blob/main/ShooterCode.cs)<br>
![Gun COde](https://media.discordapp.net/attachments/1014937571253555310/1225393539538485288/image.png?ex=6620f7aa&is=660e82aa&hm=f6e47ed26c11e58b052fc55c1c8427305dbbe8b2488e8fbc447861509ebda623&=&format=webp&quality=lossless&width=423&height=681)
2. Download/Copy the **health** code into your unity project
    - [Get the code](https://github.com/Belistov/Gun-Script/blob/main/health.cs)
3. Put the **gun code** on your **gun**, and the **health code** on your enemy
4. change some variables in the code itself. for example
   ```cs
   // My code has mouseLook
    [SerializeField] private mouseLook cam;
   // Your code has something else,
   // this is refering to the code that is attached to the camera
   // Change it to have the same name as that code
   [SerializeField] private <Camer Code> cam;
   ```
## Log 1. June 2023
I started working on this code as a project for my friend who just got into unity C# developing, the code has so far worked really well and I pulled an allnighter working on it... <br>
Added
- muzzle
- shoot_SFX
- maxAmmo
- currentAmmo
- reloadTime
- range
- aimSprintSpeed
- aimWalkSpeed
- aimSens
- aimDist
- impactForce
- fireRate
- damage
- is_auto
  
## Log 2. December 2023
I forgot about this code until now, my pc has been showing signs of failure and I want to save the code just to be sure, I will continue developing it. Now I am working on simple reaload animations and sounds... <br>
Working on
- Reaload animations
- Reaload SFX
- Shotgun mode
- Burst mode
- Explosive bullets
- Bullet Trails
- Bullet Hit Marks
- Current Amo Display on screan
