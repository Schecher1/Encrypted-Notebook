<h1>Encrypted Notebook (written in WPF C#   DOTNET6)</h1>

## Important Info!
This is my first "Big" project in C#. 
So I created this just to learn and because this software surprised me so much. 
I am releasing it so you can use it or if you are also using or learning C#, you can continue to use/develop it. 
But I am not liable if any data stays encrypted forever. Because it is a real encryption without any BackDoor.


## Application description:
This is not a normal notebook/diary, no it is encrypted! 
In addition, you are the own master of your data, because you have to host the database by yourself!
I had an older version of this ( meanwhile archive) that only ran on RAW MySQL querys, which is everything except nice. 
That's why I decided to switch to EF (Entity Framework) and using DotNET 6. 
Don't forget, all important data is hashed or encrypted, with SHA512 or AES256 (with salt).
And if you are bored with MySQL, you only have to change the NuGet package!

## How to Set-Up the Database:
Don't worry, it's not difficult, thanks of EF it's possible. 
You only have to choose a name (but be careful, take one that does not already exist. 
Otherwise he just copies his data into it and or does not work at all).
Just enter them and press the button. Everything will be automatically set up for you and then you can directly create a user.


## How to Download:
Go to the "DOWNLOAD" folder and download any version (for security the latest one). 
Or [press here](https://github.com/Schecher1/Encrypted-Notebook/raw/master/DOWNLOAD/Latest%20Version.zip) to download if you want the latest one


## Features:
✔️Clean and simple UI<br/>
✔️Automatic SetUp<br/>
✔️User friendly / beginner friendly<br/>
✔️Encrypted or hashed<br/>
✔️Anti SQL injection <br/>
                                                                                                             

## Images:
### Server-Login:
-If there is no password just leave it blank (I don't recommend this)                                                                 <br/>
-The "Save" button saves everything except the password, because it will be saved unencrypted in a file (because of the security)     <br/>
![Server-Login](IMAGES/Version%202.2.0.0/ServerLogin.PNG)

### Server-Login-OneWayLogin:                                                                                
![Server-Configure](IMAGES/Version%202.2.0.0/ServerLoginOneWayLogin.PNG)

### Server-Create-OneWayLoginKey:                                                                                   
![Server-Configure](IMAGES/Version%202.2.0.0/ServerCreateOneWayLoginKey.PNG)	

### Server-Configure:
-This appears only once when the database is new!                                                                                     <br/>
![Server-Configure](IMAGES/Version%201.0.0.0/ServerConfigure.PNG)


### User-Create:
![User-Create](IMAGES/Version%201.0.0.0/UserCreate.PNG)


### User-Login:
![User-Login](IMAGES/Version%201.0.0.0/UserLogin.PNG)


### User-Home:
![User-Home](IMAGES/Version%202.1.0.0/UserHomeMenu.PNG)


### Import-Export:
-All or specific notebooks can be exported																								<br/>
-The file is of course also re-encrypted																									<br/>
-DO NOT EDIT THE FILE OR EVERYTHING WILL BE GONE																			<br/>
![Import-Export](IMAGES/Version%202.1.0.0/NotebookExportImport.PNG)


### User-Delete:
-Do it carefully! it cannot be undone!																										<br/>
![User-Delete](IMAGES/Version%202.1.0.0/UserDelete.PNG)


### Notebook:
-Under the "Create" button, there is a text box where you should enter the name of the new notebook.                                  <br/>
-When you delete a notebook, you must select it from the list.                                                                        <br/>
-THERE IS NO AUTOMATIC SAVE, whenever you want to change your book, save it first.                                                    <br/>
![Notebook](IMAGES/Version%202.1.0.0/Notebook.PNG)


### Database-Tables:
![Database-Tables](IMAGES/Version%202.2.0.0/DB-Tables.PNG)


### Database-Notebooks:
-The "NULL" means that the notebook is empty                                                                                          <br/>
![Database-Notebooks](IMAGES/Version%201.1.0.0/DB-Table-Notebooks.PNG)


### Database-Setting:
![Database-Setting](IMAGES/Version%201.1.0.0/DB-Table-Setting.PNG)


### Database-Salt:
![Database-Setting](IMAGES/Version%201.0.0.0/DB-Table-Salt.PNG)


### Database-User:
![Database-User](IMAGES/Version%201.0.0.0/DB-Table-User.PNG)
