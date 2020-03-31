-- VIDEOS TABLE

-- CREATE TABLE books (
--     id INT NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     author VARCHAR(255) NOT NULL,
--     isAvailable TINYINT,
--     libraryId INT NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (libraryId)
--         REFERENCES libraries(id)
--         ON DELETE CASCADE
-- )


-- CREATE TABLE libraries (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     location VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )

-- CREATE TABLE authors (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )

-- CREATE TABLE bookauthors (
--     id INT NOT NULL AUTO_INCREMENT,
--     authorId INT NOT NULL,
--     bookId INT NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (authorId)
--         REFERENCES authors(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (bookId)
--         REFERENCES books(id)
--         ON DELETE CASCADE
-- )




-- --NOTE Getting shoes by cart i
SELECT s.* FROM bookauthors ba
INNER JOIN books s ON s.id = ba.bookId
WHERE authorId = 1;