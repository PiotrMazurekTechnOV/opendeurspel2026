#table users aanmaken:
CREATE TABLE users(
id INT Primary Key Auto_Increment,
nameGuardian VARCHAR(50),
nameChild VARCHAR(50),
email VARCHAR(100) UNIQUE,
code INT UNIQUE,
createdAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

#table locations aanmaken:
CREATE TABLE locations(
id INT Primary Key Auto_Increment,
number INT UNIQUE,
localName char(60)
);

#table questions aanmaken:
CREATE TABLE questions(
id INT Primary Key Auto_Increment,
text char(150),
location_number INT,
FOREIGN KEY (location_number) REFERENCES locations(number)
);

#table answers aanmaken:
CREATE TABLE answers(
id INT Primary Key Auto_Increment,
text char(150),
correct BOOLEAN DEFAULT false,
question_id INT NOT NULL,
FOREIGN KEY (question_id) REFERENCES questions(id)
);

#table scores aanmaken:
CREATE TABLE scores (
    id INT AUTO_INCREMENT PRIMARY KEY,
	user_id INT NOT NULL,
    question_id INT NOT NULL,
	status BOOLEAN NOT NULL DEFAULT 0,
	created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
	FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
	FOREIGN KEY (question_id) REFERENCES questions(id) ON DELETE CASCADE
);

#create trigger for random code
DELIMITER $$
CREATE TRIGGER before_insert_users
BEFORE INSERT ON users
FOR EACH ROW
BEGIN
  DECLARE done INT DEFAULT 0;
  WHILE done = 0 DO
    SET NEW.code = FLOOR(100 + RAND() * 900);
    IF NOT EXISTS (
      SELECT 1 FROM users WHERE code = NEW.code) 
      THEN
      SET done = 1;
    END IF;
  END WHILE;
END$$
DELIMITER ;