# ExperimentAPI
REST API with two endpoinds for color and price

Created an API with 2 endpoints (can be easily scalable)
![image](https://github.com/antonpshenai/ExperimentAPI/assets/81904561/85e1ef5b-44ee-4396-b92c-e071b212b8d4)

DB:
![image](https://github.com/antonpshenai/ExperimentAPI/assets/81904561/5225c0b1-7a76-4653-8c6f-4c3669fccfd0)

The decision of such database structure was made due to the ease of adding experiments (with maintaining normalization)
So, if new experiment appear - it is only need to be added to the configuration file with the appropriate name of the experiment (no code change)

Tested system with 1000+ records. Result:
![image](https://github.com/antonpshenai/ExperimentAPI/assets/81904561/bbd2141d-8968-47f8-a5dc-a651368baa6e)
![image](https://github.com/antonpshenai/ExperimentAPI/assets/81904561/c27e3239-7b2e-47a3-93f1-9d5f0c2f3f66)
