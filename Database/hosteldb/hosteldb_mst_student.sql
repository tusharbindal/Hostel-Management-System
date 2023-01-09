-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: hosteldb
-- ------------------------------------------------------
-- Server version	5.7.9-log

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
-- Table structure for table `mst_student`
--

DROP TABLE IF EXISTS `mst_student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mst_student` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mobile` varchar(10) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `father_name` varchar(70) DEFAULT NULL,
  `mother_name` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `address` varchar(450) DEFAULT NULL,
  `collage` varchar(45) DEFAULT NULL,
  `id_proof` varchar(45) DEFAULT NULL,
  `roomNo` int(11) DEFAULT NULL,
  `living` varchar(45) DEFAULT 'Yes',
  PRIMARY KEY (`id`),
  KEY `roomNo_idx` (`roomNo`),
  CONSTRAINT `roomNo` FOREIGN KEY (`roomNo`) REFERENCES `mst_addrooms` (`roomNo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mst_student`
--

LOCK TABLES `mst_student` WRITE;
/*!40000 ALTER TABLE `mst_student` DISABLE KEYS */;
INSERT INTO `mst_student` VALUES (1,'97','w','w','w','e','r','r','r',100,'No'),(2,'9720961324','Tushar Bindal','Mr. Ravindra Kumar','Mrs. Mithlesh Bindal','tusharbindal297@gmail.com','Agra','Gla University','123',102,'No');
/*!40000 ALTER TABLE `mst_student` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-02 13:39:11
