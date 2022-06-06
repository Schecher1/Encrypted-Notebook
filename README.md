<h1>Encrypted Notebook (written in WPF C#   DOTNET6)</h1>

## Important Info!
This is my first "Big" project in C#. 
So I created this just to learn and because this software surprised me so much. 
I am releasing it so you can use it or if you are also using or learning C#, you can continue to use/develop it. 
But I am not liable if any data stays encrypted forever. Because it is a real encryption without any BackDoor.


## Application description:
This is not a normal notebook/diary, no it is encrypted! 
In addition, you are the own master of your data, because you have to host the database by yourself!
I had an older version of this (meanwhile archive [press here to see](https://github.com/Schecher1/Encrypted-Notebook-MySqlData)) that only ran on RAW MySQL querys, which is everything except nice. 
That's why I decided to switch to EF (Entity Framework) and using DotNET 6. 
Don't forget, all important data is hashed or encrypted, with SHA512 or AES256 (with salt).
And if you are bored with MySQL, you only have to change the NuGet package!

## How to Set-Up the Database:
Don't worry, it's not difficult, thanks of EF it's possible. 
You only have to choose a name (but be careful, take one that does not already exist. 
Otherwise he just copies his data into it and or does not work at all).
Just enter them and press the button. Everything will be automatically set up for you and then you can directly create a user.


## How to Download:
Go to the "Releases" and download any version (for security the latest one). 
Or [press here](https://github.com/Schecher1/Encrypted-Notebook-EntityFramework/releases/download/Encrypted-Notebook/Program.zip) to download if you want the latest one


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
![Server-Login](IMAGES/Version%201.0.0.0/PageServerLogin.PNG)

### Server-Login-OneWayLogin:                                                                                
![Server-Configure](IMAGES/Version%201.0.0.0/PageServerLoginOneWayLogin.PNG)

### Server-Create-OneWayLoginKey:                                                                                   
![Server-Configure](IMAGES/Version%201.0.0.0/PageServerLoginOneWayLoginCreate.PNG)	

### Server-Configure:
-This appears only once when the database is new!                                                                                     <br/>
![Server-Configure](IMAGES/Version%201.0.0.0/PageServerIsNotConfigured.PNG)


### User-Create:
![User-Create](IMAGES/Version%201.0.0.0/PageUserCreate.PNG)


### User-Login:
![User-Login](IMAGES/Version%201.0.0.0/PageUserLogin.PNG)


### User-Home:
![User-Home](IMAGES/Version%201.0.0.0/PageUserHome.PNG)


### Import-Export:
-All or specific notebooks can be exported																								<br/>
-The file is of course also re-encrypted																									<br/>
-DO NOT EDIT THE FILE OR EVERYTHING WILL BE GONE																			<br/>
![Import-Export](IMAGES/Version%201.0.0.0/PageUserNotebookHome.PNG)


### User-Delete:
-Do it carefully! it cannot be undone!																										<br/>
![User-Delete](IMAGES/Version%201.0.0.0/PageUserDelete.PNG)


### Notebook:
-Under the "Create" button, there is a text box where you should enter the name of the new notebook.                                  <br/>
-When you delete a notebook, you must select it from the list.                                                                        <br/>
-THERE IS NO AUTOMATIC SAVE, whenever you want to change your book, save it first.                                                    <br/>
![Notebook](IMAGES/Version%201.0.0.0/PageUserNotebookHome.PNG)


### Database-Tables:
![Database-Tables](IMAGES/Version%201.0.0.0/DatabaseTables.PNG)


### Database-Notebooks:
-The "NULL" means that the notebook is empty                                                                                          <br/>
![Database-Notebooks](IMAGES/Version%201.0.0.0/DatabaseTablesNotebooks.PNG)


### Database-Setting:
![Database-Setting](IMAGES/Version%201.0.0.0/DatabaseTablesSetting.PNG)


### Database-Salt:
![Database-Setting](IMAGES/Version%201.0.0.0/DatabaseTablesSalt.PNG)

*HASH* => Means that there would be the hash. Which I have not shown because otherwise the ASIC table would be broken.
### Database-User:
![Database-User](IMAGES/Version%201.0.0.0/DatabaseTablesUser.PNG)


<h1>CHANGELOG</h1>

## Version 1.0.0.0  (Beta)
-->Each user gets his own salt (generated)<br/>
-->Each user whose password is hashed with SHA-512<br/>
-->Each user's notebook and content is encrypted with AES-256 (with salt)<br/>
-->An automatic Database setup<br/>
-->Anti SQL injection (EntitiyFramework)<br/>
-->A simple blue look<br/>
-->DotNET 6 being used<br/>
-->Is still the beta version, errors may be there<br/>
