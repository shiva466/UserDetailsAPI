create database UserDetails;
use UserDetails;
CREATE TABLE `User` (
  `userId` INT AUTO_INCREMENT PRIMARY KEY,
  `name` VARCHAR(255),
  `dob` DATE,
  `location` VARCHAR(255),
  `isActive` INT DEFAULT 1
);
INSERT INTO `User` (`name`, `dob`, `location`)
VALUES
  ('John Doe', '1990-05-15', 'New York'),
  ('Jane Smith', '1985-09-28', 'London'),
  ('Michael Johnson', '1992-02-10', 'Los Angeles'),
  ('Emily Davis', '1998-11-03', 'Paris'),
  ('David Brown', '1994-07-22', 'Tokyo'),
  ('Sophia Wilson', '1991-04-18', 'Berlin'),
  ('James Taylor', '1987-12-11', 'Sydney'),
  ('Olivia Clark', '1996-08-26', 'Toronto'),
  ('Benjamin Anderson', '1993-03-07', 'Mumbai'),
  ('Amma Rodriguez', '1989-01-31', 'Tokyo'),
  ('Jyothi Smith', '1985-09-28', 'Tokyo'),
  ('Michael Jonson', '1992-02-10', 'Los Tokyo'),
  ('Maily Davis', '1998-11-03', 'Paris'),
  ('Germy Brown', '1994-07-22', 'Tokyo');
  
  select * from user;
