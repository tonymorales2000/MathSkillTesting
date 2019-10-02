# MathSkillTesting

Your task is to create a REST API using asp.net core to generate random math equations every 2 minutes.

For example, http://your-url/api/math should generate a json response (such as 17 + 3.1 / 2.5 – 7.8) in the body.

If I refresh the page it should still provide the same json response. After 2 minutes (or less if the initial request was between the two minutes)  a new equation will be generated from the same url.

The number of operators can be between 1 and 10. Numbers should be in the range from -1000 to 1000 (including 0) and equation should be valid.
