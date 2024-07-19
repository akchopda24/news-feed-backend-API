*** Requirement of software ***
1. Visual studio 2022 Community or professional 

2. SQL server 2019 or 2022

*** Project Setup ***
1. Download SQL database bak file from following link
https://github.com/akchopda24/news-feed-backend-API/blob/main/news-feed-db-new.bak

2. Create database in Ms. SQL with below name then right click on it and restore it by above downloaded file
NewsFeedDB

3. Clone .NET Core 8.0 Web API solution by below command from GitBash or any CMD command tool
   git clone https://github.com/akchopda24/news-feed-backend-API.git

4. Change your connection string with your local server name in Web API AppSetting.json file
Current connection string : "Connectionstring": "Server=DESKTOP-RF4H1TG\\SQLEXPRESS;Database=NewsFeedDB;Integrated Security=True;TrustServerCertificate=True;"

replace this name "DESKTOP-RF4H1TG\\SQLEXPRESS" to your SQL server instant name

5. Set Right click on NewsFeed.API solution and set as default in visual studio 2022

6. Run it. It will shown swagger page with API endpoint

