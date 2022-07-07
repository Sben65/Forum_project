-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema forum_api_db
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema forum_api_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `forum_api_db` DEFAULT CHARACTER SET utf8 ;
USE `forum_api_db` ;

-- -----------------------------------------------------
-- Table `forum_api_db`.`Topic`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `forum_api_db`.`Topic` (
  `id` INT NOT NULL,
  `date_creation` DATE NULL,
  `titre` VARCHAR(150) NULL,
  `createur` VARCHAR(50) NULL,
  `date_modification` DATE NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `forum_api_db`.`Comment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `forum_api_db`.`Comment` (
  `id` INT NOT NULL,
  `derniere_modification` DATE NULL,
  `createur` VARCHAR(50) NULL,
  `contenue` VARCHAR(256) NULL,
  `Topic_idTopic` INT NOT NULL,
  `date_creation` DATE NULL,
  PRIMARY KEY (`id`, `Topic_idTopic`),
  INDEX `fk_Comment_Topic_idx` (`Topic_idTopic` ASC) VISIBLE,
  CONSTRAINT `fk_Comment_Topic`
    FOREIGN KEY (`Topic_idTopic`)
    REFERENCES `forum_api_db`.`Topic` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
