-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: beltdb
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `meetups`
--

DROP TABLE IF EXISTS `meetups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `meetups` (
  `MeetUpId` int NOT NULL AUTO_INCREMENT,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DateTime` datetime(6) NOT NULL,
  `Duration` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) NOT NULL,
  `UserId` int NOT NULL,
  PRIMARY KEY (`MeetUpId`),
  KEY `IX_MeetUps_UserId` (`UserId`),
  CONSTRAINT `FK_MeetUps_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `meetups`
--

LOCK TABLES `meetups` WRITE;
/*!40000 ALTER TABLE `meetups` DISABLE KEYS */;
INSERT INTO `meetups` VALUES (1,'Lake Havaso Roadtrip','Going to swim and have a couple of beers.','2022-05-18 13:00:00.000000','4 hours','2022-04-22 13:02:22.576160','2022-04-22 13:02:22.576210',1),(3,'Malibu Dinner','Dinner at a beach bar.','2023-01-22 14:15:00.000000','2 hours','2022-04-22 14:15:30.317517','2022-04-22 14:15:30.317580',3),(4,'Sea World','Sea world with the kids.','2024-01-22 14:15:00.000000','6 hours','2022-04-22 14:17:52.404067','2022-04-22 14:17:52.404138',3),(5,'Drake Concert (Tomorrow)','Drake concert...........','2022-04-23 14:19:00.000000','1 Day','2022-04-22 14:19:45.563060','2022-04-22 14:19:45.563066',4),(6,'Drake Concert (2025)','2025','2025-01-22 14:20:00.000000','1 Day','2022-04-22 14:20:24.666436','2022-04-22 14:20:24.666440',4),(7,'Between 2024 and 2025','A.','2024-12-22 14:28:00.000000','2 Minutes','2022-04-22 14:28:55.714059','2022-04-22 14:28:55.714078',1);
/*!40000 ALTER TABLE `meetups` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-22 14:36:29
