SELECT countries.name AS 'country', languages.language, languages.percentage
FROM languages
JOIN countries ON languages.country_id = countries.id 
WHERE language = "Slovene"
ORDER BY percentage DESC;

SELECT COUNT(*) AS cities, countries.name AS 'country name'
FROM cities
JOIN countries ON cities.country_id = countries.id
GROUP BY countries.name
ORDER BY COUNT(*) DESC;

SELECT cities.name AS city, cities.population
FROM cities
JOIN countries ON countries.id = cities.country_id
WHERE countries.name LIKE "Mexico" AND cities.population > 500000
ORDER BY cities.population DESC;

SELECT countries.name AS country, languages.language, languages.percentage
FROM languages
JOIN countries ON languages.country_id = countries.id
WHERE languages.percentage > 89
ORDER BY languages.percentage DESC;

SELECT countries.name, countries.surface_area, countries.population
FROM countries
WHERE countries.surface_area < 501 AND countries.population > 100000;

SELECT countries.name, countries.government_form, countries.capital,countries.life_expectancy
FROM countries
WHERE countries.government_form LIKE "Constitutional Monarchy" 
AND countries.capital > 200
AND countries.life_expectancy > 75;

SELECT countries.name AS country, cities.name AS city, cities.district AS district, cities.population AS population
FROM cities
JOIN countries ON countries.id = cities.country_id
WHERE cities.district LIKE "Buenos Aires"
AND cities.population > 500000;


SELECT countries.region, COUNT(*)
FROM countries
GROUP BY countries.region
ORDER BY COUNT(*) DESC;

