1. Download SQL database bak file from following link
https://github.com/akchopda24/news-feed-backend-API/blob/main/news-feed-db-new.bak

2. Create database in Ms. SQL with below name and right click on it and restore it by above downloaded file
NewsFeedDB

4. Change your connection string with your local server name in Web API AppSetting.json file
Current connection string : "Connectionstring": "Server=DESKTOP-RF4H1TG\\SQLEXPRESS;Database=NewsFeedDB;Integrated Security=True;TrustServerCertificate=True;"

replace this name "DESKTOP-RF4H1TG\\SQLEXPRESS" to your SQL server instant name

4. Set Right click on NewsFeed.API solution and set as default in visual studio 2022

 


