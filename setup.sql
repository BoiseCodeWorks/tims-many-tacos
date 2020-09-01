-- CREATE TABLE tacos(
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   price DECIMAL(6,2) NOT NULL,
--   PRIMARY KEY(id)
-- )

-- INSERT INTO tacos(Name, Description, Price)
-- VALUES("The Greatest Taco", "This is the greatest taco description", 9999.99)

-- CREATE TABLE ingredients(
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   kcal INT NOT NULL,
--   PRIMARY KEY(id)
-- )


-- INSERT INTO ingredients(Name, Kcal)
-- VALUES("Cheese", 20)

CREATE TABLE tacoingredients(
  id int AUTO_INCREMENT,
  tacoId int NOT NULL,
  ingredientId int NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY(tacoId)
    REFERENCES tacos(id)
    ON DELETE CASCADE,
  FOREIGN KEY(ingredientId)
    REFERENCES ingredients(id)
    ON DELETE CASCADE
)