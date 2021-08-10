# SynthFinManSystem
Synthentic Financial Manager System For Fraud Transactions

How to run the project:
<br />
*. Clone the repository on you pc
<br />
*. In a instance of sqls server run the db scripts located on SynthFinManSystem/SynthFinManSystem/scripts/
<br />
*. Open the project using visual studio 2019
<br />
*. Open the archive located on SynthFinManSystem/SynthFinManSystem/appsettings.json and change the part:
<br />
  "ConnectionStrings": {
        "SynthFinlMantSystemContext": "Data Source={{sql server host}};Database=SynthFinlMantSystemDb;User id=web;Password=webUser;"
    },
    <br />
    sql server host: you sql server host instance
    <br />
*. Clean and build the project
<br />
*. Run the project usin iis o iis express
<br />
