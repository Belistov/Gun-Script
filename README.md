# Gun-Script
If you want to change the code minimally I reccomedn you use my movement and mouse codes <br>
[Here](https://github.com/Belistov/Gun-Script/tree/main/Extra_Code)<br>

A script I am designing to be versatile and usable with all and any guns without external scripts, except for player movements
<br>
For the code to work propperly please follow these steps.
1. Download/Copy the **gun** code into your unity project
    - [Get the code](https://github.com/Belistov/Gun-Script/blob/main/ShooterCode.cs)<br>
![Gun COde](https://media.discordapp.net/attachments/1014937571253555310/1225393539538485288/image.png?ex=6620f7aa&is=660e82aa&hm=f6e47ed26c11e58b052fc55c1c8427305dbbe8b2488e8fbc447861509ebda623&=&format=webp&quality=lossless&width=423&height=681)
2. Download/Copy the **health** code into your unity project
    - [Get the code](https://github.com/Belistov/Gun-Script/blob/main/health.cs)<br>
    ![Health Code](https://media.discordapp.net/attachments/1014937571253555310/1225403113419313162/image.png?ex=66210095&is=660e8b95&hm=be243527175d80e64974161b8d77a7000457a5ab4c6623c59bc8975527573767&=&format=webp&quality=lossless)
3. Put the **gun code** on your **gun**, and the **health code** on your enemy
4. change some variables in the code itself. for example
   ```cs
   // Asuimng you havent deleted or changed anything in the code this can be found in
   // Line : 12
   
   // My code has mouseLook
   [SerializeField] private mouseLook cam;
   // Your code has something else,
   // this is refering to the code that is attached to the camera
   // Change it to have the same name as that code
   [SerializeField] private <Camer Code> cam;
   // and remember to remove the '<>'
   ```
   ```cs
   // Asuimng you havent deleted or changed anything in the code this can be found in
   // Line : 16 and 20
   
   // Same goes for this part of the code
   // I have PlayerMovement but you have probably something else
   [SerializeField] private PlayerMovement _speed;
   // this is referencing the code that is attached to the player and allows him to move
   // Change it to your player movement code file name
   [SerializeField] private <Code name of player movement> _speed;
   // and remember to remove the '<>'
   ```
5. To set this up use this template foe the ``Hierarchy``
   ```
   Player Folder (Create Empty) [Attach <PlayerMovement.cs> ]
   |- Player Asset 
   |- Main Camera [Attach <mouseLook.cs> ]
   |- |- Weapon Wheel (Create Empty)
   |- |- |- Weapon 1 [Attach <ShooterCode.cs> ]
   |- |- |- Weapon 2 [Attach <ShooterCode.cs> ]
   |- |- |- etc...
   |- Ground Check (Create Empty)
   ```
   ![Image](https://media.discordapp.net/attachments/968661712943337552/1225598275655307274/image.png?ex=6621b657&is=660f4157&hm=5ffb3b337a4df237047110700a7b4ba9816a659dda3d6e53fe4b1c1f521b1a90&=&format=webp&quality=lossless)
   <br>
6. Don't forget to add colliders, rigidbody and the rest ;)
   
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
