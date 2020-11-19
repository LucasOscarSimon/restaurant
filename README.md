# Restaurant
Restaurant Order App

# Backend Architecture Layers
 - Restaurant.API
    - It contains the Restfull services.
 - Restaurant.Application
    - The bussiness logic of the application.
 - Restaurant.Core 
    - It contains the base Entity and Repository base interface.
 - Restaurant.Infra.Data
    - EF logic.
 - Restaurant.Domain 
    - Domain logic of the application.

# Ef Core will create automatically the database and seed the data into the DB.

# Problem: 
Create a WebApi application for a restaurant. The API will receive an input of the dishes in interger values 
and it should return an output with the description of the dishes.

# Design patterns used in this demo:
Factory & Template Method.

# Prerequisites: 
Net Core Sdk 3.1
Docker

# IMPORTANT: The db will be running inside a docker container

# Next you'll find the steps for running the app within a docker container

# In order to run the application you need to
1) Go to the docker-compose.yml directory (the same as sln file) with your terminal.
2) Run the command "docker-compose up". It will start downloading all the necessary packages.
3) It will try to run the application but it will probably fail due to the Server IP Address of the ConnectionString in the appsettings.json file.

# To solve this problem you need to get the Gateway Address of docker container and paste it in the appsettings.json file.

# How to get the Gateway Address
1) In your terminal type the following command: docker ps and it will list all docker containers 
2) Copy the container Id or Name of the DB container
3) Type the following command
  Windows: 
    --> docker inspect <name_or_id_of_your_container> | Select-String -Pattern "Gateway"
  Linux: 
    --> docker inspect <name_or_id_of_your_container> | grep Gateway
4) Copy the Gateway address and paste it in the Server option of the connectionString.

  "DefaultConnection": "Server=<Gateway>;Database=Restaurant; UID=xxx; PWD=xxx"
5) Run the app.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# Run the application by using Kestrel server

First you need to be running the DB from a Sql Server Docker Container, for doing that you can execute the "docker-compose up" command and it will create the DB for you. 
It will create also the image and container for running the API, to avoid that just delete the restaurantapi part from the docker-compose.yml file.

1) In the Server option of the connectionString type db 
  "DefaultConnection": "Server=db;Database=Restaurant; UID=xxx; PWD=xxx"
2) Run the app.


