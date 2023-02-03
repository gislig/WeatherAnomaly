# Weather Storm Anomaly Detector for Iceland
Created by [Gisli Gudmundsson] for project in Reykjavik University.
The group consists of:
* Gisli Gudmundsson
* Einar Már Eggertsson
* Kypler Lloyd Palban Espiritu
## Description
This api collects data from sources and then PowerBI and other toolsets used to analyze data. Currently Iceland has had increased storms in the winter and is extending into the summer. These storms are causing issues such as flooding, landslides, and other issues. The goal is to check if the past heat and current heat has something to do with this.
* Getting data from Vedur.is API
## To Start API
* Make sure that hou have dotnet 7 installed
* Run the following command in the root of the project.
```
dotnet run
```
* You can also go to the root of the solution directory and run the make file by running the following command.
This will run the dotnet watch command.
```
make watch
```
and for building the project
```
make build
```