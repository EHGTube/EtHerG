# EtHerG

To Do : 

5. Automatically send last Values to Embed on startup
6. Add failure proofing on function startups (all params set for embed? all for Modbus? for influx? ) 
7. Fix Login / Logout
8. Maybe figure out why GainY only works up to ~73? Or why Gain doesnt work anymore after ~70? 
9. Add Color Options for everything (LineDiagX, LineDiagY, Scatterlines, Alarm1, Alarm2)
10. Add Options to display Scatterpoints or Lines
11. Add Internationalization
12. Fix Sending InfluxDB Alarm2 ?


Regarding InfluxDB:

Saving Changed Parameters works
It will set Alarm1 to True when the Alarm is active. 
For some reason Alarm2 will not be send. 