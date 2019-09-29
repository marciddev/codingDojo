SELECT users.first_name, users.last_name, user2.first_name AS friend_first_name, user2.last_name AS friend_last_name FROM users
LEFT JOIN friendships ON friendships.user_id = users.id
LEFT JOIN users AS user2 ON friendships.friend_id = user2.id; 
-- 1.Return all users who are friends with Kermit, make sure their names are displayed in results.
SELECT users.first_name, users.last_name, user2.first_name AS friend_first_name, user2.last_name AS friend_last_name FROM users -- 
LEFT JOIN friendships ON friendships.user_id = users.id 
LEFT JOIN users AS user2 ON friendships.friend_id = user2.id 
WHERE users.first_name LIKE "Kermit";
-- 2.Return the count of all friendships
SELECT COUNT(friendships.id) FROM friendships;
-- 3. Find out who has the most friends and return the count of their friends.
SELECT first_name, COUNT(user_id) FROM friendships
LEFT JOIN users ON users.id = friendships.user_id
WHERE user_id = 1 AND users.first_name LIKE "Amy";
-- 4. Create a new user and make them friends with Eli Byers, Kermit The Frog, and Marky Mark
-- INSERT INTO friendships(id, user_id, friend_id, created_at, updated_at ) 
-- VALUES (8, 6, 5, NOW(), NOW());
-- 5. Return the friends of Eli in alphabetical order
SELECT users.first_name, users.last_name, user2.first_name AS 'friend first name', user2.last_name AS 'friend last name' FROM users
LEFT JOIN friendships ON friendships.user_id = users.id 
LEFT JOIN users AS user2 ON friendships.friend_id = user2.id 
WHERE users.first_name LIKE "Eli"
ORDER BY users.first_name ASC;
-- 6. Remove Marky Mark from Eli’s friends.
DELETE FROM friendships 
WHERE friend_id = 4 AND friend_id = 5 AND user_id = 2;

SELECT users.first_name, users.last_name, user2.first_name AS friend_first_name, user2.last_name AS friend_last_name FROM users
LEFT JOIN friendships ON friendships.user_id = users.id
LEFT JOIN users AS user2 ON friendships.friend_id = user2.id; 
