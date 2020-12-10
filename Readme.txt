Lawn Mow Project is developed in two parts, backend is in nestjs and frontend is in ASP.NET MVC

-> Steps for run the nestjs code:
1) First of all, need to check some software are installed or not on the machine:
   - NodeJs
   - npm
   - NestJs
2) Open the project.
3) Open the terminal with package.json file path.
4) Enter "npm run start:dev" command on terminal
5) Browse the url "localhost:3000" on browser.


-> Steps for run the ASP.NET MVC code:
1) Open the project.
2) Clean solution and rebuild solution.
3) If you get any error of nuget package then open the .csproj file and check the path of "Package" folder.
4) We need to set API Url in "lawMowAPIUrl" and "weatherAPIKey" in web.config file.
5) Run the code.


-> Weather API implementation:
1) Go to "https://openweathermap.org/" and register yourself.
2) After completing verification process we can logged into "https://openweathermap.org/" website.
3) Go to "My API Keys" section.
4) Here we can generate or use default API key and it will be used to call the API.
5) Copy the API Key and paste in to "weatherAPIKey" in web.config file.
6) For API documentation, Please visit "https://openweathermap.org/api"