
# Menu Permissions: Chillisoft Assessment

## Requirements

Operating system
```
Windows 
```

Shell
```
Command Prompt
```

Runtime
```
DotNet 8.0 
```
## Usage

Navigate to the .\menupermissions\bin\Debug\net8.0 folder and run the following command using Command Prompt (you may need to build the app if the folder does not exist using dotnet build in Command Prompt)

```
menupermissions.exe users.txt menus.txt > output1.json
```

To execute a larger dataset of 200 menu items and 10000 users, within the same folder execute the following command in Command Prompt

```
menupermissions.exe usersbig.txt menusbig.txt > output2.json
```


## Features

- Different Design Patterns in use (Strategy, Command)
- Dependency Injection
- Test (R&D) code

