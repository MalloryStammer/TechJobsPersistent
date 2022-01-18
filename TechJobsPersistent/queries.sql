--Part 1
Int Id
Longtext Name
Int EmployerId

--Part 2

SELECT Name
FROM Employers
WHERE location='St. Louis';

--Part 3
SELECT name, description
FROM skills
INNER JOIN jobskills ON skills.Id = jobSkills.SkillId
ORDER BY name;