# SynthFinManSystem
Synthentic Financial Manager System For Fraud Transactions

How to run the project:

*. Clone the repository on you pc
*. In a instance of sqls server run the db scripts located on SynthFinManSystem/SynthFinManSystem/scripts/
*. Open the project using visual studio 2019
*. Open the archive located on SynthFinManSystem/SynthFinManSystem/appsettings.json and change the part:
  "ConnectionStrings": {
        "SynthFinlMantSystemContext": "Data Source={{sql server host}};Database=SynthFinlMantSystemDb;User id=web;Password=webUser;"
    },
    sql server host: you sql server host instance
*. Clean and build the project
