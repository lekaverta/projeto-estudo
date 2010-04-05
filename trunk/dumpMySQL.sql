-- MySQL dump 10.13  Distrib 5.1.44, for Win64 (unknown)
--
-- Host: localhost    Database: mysqlgenerico
-- ------------------------------------------------------
-- Server version	5.1.44-community

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `mysqlgenerico`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `mysqlgenerico` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `mysqlgenerico`;

--
-- Table structure for table `tbalbums`
--

DROP TABLE IF EXISTS `tbalbums`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbalbums` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `artista_id` int(10) unsigned NOT NULL,
  `titulo` varchar(512) NOT NULL,
  `ano_lancamento` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbalbums`
--

LOCK TABLES `tbalbums` WRITE;
/*!40000 ALTER TABLE `tbalbums` DISABLE KEYS */;
INSERT INTO `tbalbums` VALUES (1,1,'Ventura',2010),(2,1,'Bloco Do EU Sozinho',2010),(3,1,'4',2010);
/*!40000 ALTER TABLE `tbalbums` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbartistas`
--

DROP TABLE IF EXISTS `tbartistas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbartistas` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `titulo` varchar(512) NOT NULL,
  `biografia` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbartistas`
--

LOCK TABLES `tbartistas` WRITE;
/*!40000 ALTER TABLE `tbartistas` DISABLE KEYS */;
INSERT INTO `tbartistas` VALUES (1,'Los Hermanos','-');
/*!40000 ALTER TABLE `tbartistas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbmusicas`
--

DROP TABLE IF EXISTS `tbmusicas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbmusicas` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `artista_id` int(10) unsigned NOT NULL,
  `album_id` int(10) unsigned NOT NULL,
  `titulo` varchar(512) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbmusicas`
--

LOCK TABLES `tbmusicas` WRITE;
/*!40000 ALTER TABLE `tbmusicas` DISABLE KEYS */;
INSERT INTO `tbmusicas` VALUES (1,1,1,'Samba a Dois'),(2,1,1,'Um Par'),(3,1,2,'Pois É'),(4,1,1,'Tá Bom'),(5,1,3,'Horizonte Distante');
/*!40000 ALTER TABLE `tbmusicas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2010-04-05 13:24:38
