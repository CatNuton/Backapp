# FileBackApp

👨‍💻 This app...
---
Automatically copies the specified directory at a user-defined time interval. You can specify the source folder and the location for saving the backups, and the program will take care of regular backups without your constant intervention.

🎮 Made for...
---
Hardcore games with one save file. If your character dies or the game crashes, you can always restore your progress from the last backup. This provides peace of mind and confidence that even the most difficult moments of the game will not lead to the loss of achievements.

<img width="1920" height="1080" alt="489436352-4c257099-b1b2-4cb8-9ba7-ffdc7715f394" src="https://github.com/user-attachments/assets/78f56099-1866-460b-8cb8-6b05fe8de45c" />

$${\color{green}Screenshot \space from \space Hollow \space Knight: \space Silksong \space Gameplay \space - \space The \space First \space 14 \space Minutes \space by \space \color{red}IGN}$$
[Source](https://www.youtube.com/watch?v=BFBOi-rpcFE)

ℹ How to use (GUI)
---
![Screenshot](https://github.com/user-attachments/assets/f55d5f83-f54d-48ed-9d03-8996f9e8efa8)

- Directory - The directory you want to copy
- Copy to - The directory you want to copy your folder to
- Time - The time after which the copy will be created. The first field specifies the time, and the second field specifies the units of measurement (seconds, minutes, hours)
- Overwrite files - indicates whether to overwrite the copied file or create a new copy
- Archive Directory - indicates whether to save files in a .zip archive or in a folder

ℹ How to use (Console)
---
Commands list
```
--directory="DISK:\PATH_TO_YOUR_DIRECTORY\DIRECTORY" --dir="DISK:\PATH_TO_DIRECTORY" --time="TIME" --units="UNITS (S, M, H)" --overwrite="TRUE OR FALSE" --archive="TRUE OR FALSE"
```

Commands can be separated by "-" or "\". Value needs to be written in quotation marks

- Directory - The directory you want to copy
- Dir - The directory you want to copy your folder to
- Time - The time after which the copy will be created. The first field specifies the time, and the second field specifies the units of measurement (seconds, minutes, hours)
- Overwrite - indicates whether to overwrite the copied file or create a new copy
- Archive - indicates whether to save files in a .zip archive or in a folder
