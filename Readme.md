<h2> General info </h2>

<p> Project runs at localhost:7000. To change this behaviour go to apsettings.json in properties folder. Swagger page are located at https://localhost:7000/swagger/</p>

<p> Auth page are located at https://localhost:7000/api/JWTCreator/{username} </p>

<p> To create post, put, delete requests you need to authorize: go to https://localhost:7000/api/JWTCreator/{username} Then Copy jwt token and insert it in request headers like "Authorization": "Bearer {your token without this brackets}". Or click on button with "lock" icon in swagger page and insert there your token like this: "{your token without this brackets}"  </p>



<h2> How to run </h2>

<p> To run this project, you need to clone this repo. Start Library.API application. Then Swagger page must appear. If it isn't - go to https://localhost:7000/swagger/. </p>

<p> To create post, put, delete requests you need to authorize: go to https://localhost:7000/login/{username} Then Copy jwt token and insert it in request headers like "Authorization": "Bearer {your token without this brackets}" </p>
