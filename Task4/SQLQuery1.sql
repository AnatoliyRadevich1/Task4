CREATE TABLE clients
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	name VARCHAR (255) NOT NULL,
	email VARCHAR (255) NOT NULL UNIQUE,
	registration DATE NOT NULL, 
	last_visit DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	is_online BIT NULL
);

INSERT INTO clients (name, email)
VALUES
('Ludwig van Beethoven', 'LvB@tut.by'),
('Johann Sebastian Bach', 'JSB@tut.by'),
('Wolfgang Amadeus Mozart', 'WAM@tut.by'),
('Pyotr Ilyich Tchaikovsky', 'PIT@tut.by'),
('Giuseppe Fortunino Francesco Verdi', 'GFFV@tut.by')