# Fleet Manegment System

## Requirements

* .net 8.0 or later 
* leatest ANGULAR version 
* FPro reference in all projects in the soulution 

## Demo Video

Click the link below to play the demo video:

https://youtu.be/Jgt5kz8P6h4

## How to run FMS

* After cloning the repository open your VS 2022 
* Open Fleet-Management-System\Services\General\DatabaseConnection.cs
* You can find the copy of the Database in https://drive.google.com/file/d/1AAAxvQsyC3aanQNhYHC8_tvhWMAnfnuL/view?usp=drive_link
* Adjust the connection string in Fleet-Manegment-System\Fleet-Manegment-System\Services\General\DatabaseConnection.cs with your DB info as :
```bash
_connectionString = "Host=localhost; Port=5432; Database=DatabaseName; Username=UrUsername; Password=UrPassword";
```
* Run The server (Make sure to run this project):

![image](https://github.com/aboodjallad/Fleet-Manegment-System/assets/67801795/89336937-6f04-4827-946a-6fed49b85013)

* then Open the termenal and make sure your on **\Fleet-Manegment-System\clientside**

* Run the ANGULAR server using this command :
```bash 
ng serve
``` 

* Open this URL in your browser : http://localhost:4200  OR http://localhost:4200/home




