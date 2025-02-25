-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: project_office
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `ClientID` int NOT NULL AUTO_INCREMENT,
  `ClientTypeID` int NOT NULL,
  `ClientOrgTypeID` varchar(4) DEFAULT NULL,
  `ClientName` varchar(256) NOT NULL,
  `ClientAddress` varchar(256) NOT NULL,
  `ClientBankAccount` varchar(20) NOT NULL,
  `ClientBank` varchar(256) NOT NULL,
  `ClientPhone` varchar(11) DEFAULT NULL,
  `ClientEmail` varchar(256) DEFAULT NULL,
  `MarkedToDelete` tinyint DEFAULT NULL,
  `ClientBirthDate` date DEFAULT NULL,
  `ClientPassDepartment` varchar(150) DEFAULT NULL,
  `ClientPassDepartmentCode` int DEFAULT NULL COMMENT 'Max size 6',
  `ClientPassSerias` int DEFAULT NULL COMMENT 'Max size 4',
  `ClientPassNumber` int DEFAULT NULL COMMENT 'Max size 6',
  `ClientOrgINN` varchar(10) DEFAULT NULL COMMENT 'Max size 6',
  `ClientOrgKPP` varchar(9) DEFAULT NULL,
  `ClientOrgOGRN` varchar(13) DEFAULT NULL,
  `ClientOrgBIK` varchar(9) DEFAULT NULL,
  `ClientPhoto` blob,
  PRIMARY KEY (`ClientID`),
  UNIQUE KEY `ClientBankAccount_UNIQUE` (`ClientBankAccount`),
  KEY `clienttype_ref_k_idx` (`ClientTypeID`),
  KEY `organitationtype_ref_k_idx` (`ClientOrgTypeID`),
  CONSTRAINT `clienttype_ref_k` FOREIGN KEY (`ClientTypeID`) REFERENCES `clienttype` (`ClientTypeID`),
  CONSTRAINT `organitationtype_ref_k` FOREIGN KEY (`ClientOrgTypeID`) REFERENCES `organitationtype` (`OrganitationTypeName`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (1,1,NULL,'Филатов Климент Никифорович','Россия, г. Москва, Советский пер., 6, корп. 7, кв. 184','42001978970646979544','Красноярский филиал АО Ингосстрах Банк','77463082198','Kliment20@msn.com',NULL,'1977-08-04','Отделом УФМС России по г. Сыктывкар',300148,4714,318232,NULL,NULL,NULL,NULL,NULL),(2,1,NULL,'Фомичева Рада Ивановна','Россия, г. Москва, Советский пер., 77, корп. 2, кв. 187','40702810339132568218','УФК по Астраханской области','79431494486',NULL,NULL,'1974-10-27','Отделом УФМС России по г. Астрахань',230167,9696,799287,NULL,NULL,NULL,NULL,NULL),(3,2,'ООО','Пространство','420179, г. Казань, ул. Набережная, 10, оф. 65','40702810332175076544','ЧЕЛЯБИНСКИЙ ФИЛИАЛ АО ЮНИКРЕДИТ БАНКА','71567388645','spacecompany.ogr@gmail.com',NULL,NULL,NULL,NULL,NULL,NULL,'0434673496','141404962','9113671240069','047501982',NULL),(4,2,'ООО','Железный результат','445409, г. Тольятти, ул. Набережная, 42, оф. 85','40702810669782192755','ЯРОСЛАВСКИЙ РФ АО \"РОССЕЛЬХОЗБАНК\"','74474753481','ironresult@ironcom.ru',NULL,NULL,NULL,NULL,NULL,NULL,'0348887960','762649481','7066395845630','047888717',NULL),(5,2,'АО','Первый товар','125618, г. Москва, ул. Гоголя, 31, оф. 27','40702810585753686532','АО \"АБ \"РОССИЯ\"','76907875657','perviitovar_123@yandex.ru',NULL,NULL,NULL,NULL,NULL,NULL,'7425725366','365101815','6160365265109','044030861',NULL),(6,2,'ПАО','Территория','426695, г. Ижевск, ул. Подгорная, 32, оф. 54','40702810983480850904','Московский филиал ПАО \"МЕТКОМБАНК\"','78866879391','terraorg@space.com',NULL,NULL,NULL,NULL,NULL,NULL,'5074072256','675649319','2177525273847','044525200',NULL),(7,2,'ПАО','Астрономическая глава','450019, г. Уфа, ул. Горная, 48, оф. 59','40702810831149971961','Филиал №11 АО МОСОБЛБАНК','74417892951','ast0nomic.glava@yahoo.com',NULL,NULL,NULL,NULL,NULL,NULL,'0773376402','074036431','8103689924100','043207757',NULL),(8,2,'АО','Громадная слава','190395, г. Санкт-Петербург, ул. Молодежная, 42, оф. 28','40702810011815804323','КУ КБ \"ТРАНСНАЦИОНАЛЬНЫЙ БАНК\" (ООО)-ГК \"АСВ\"','72734826137','gigantslava.org@company.com',NULL,NULL,NULL,NULL,NULL,NULL,'1395121420','470523230','8027752332171','044525374',NULL),(9,2,'ПАО','Полное образование','443461, г. Самара, ул. Речная, 25, оф. 98','40702810411964651221','НКО \"РКЦ ДВ\" (АО)','72963605546','polnoeobrazovanie.edu@edu.ru',NULL,NULL,NULL,NULL,NULL,NULL,'1758792689','350602313','7040515612757','040507707',NULL),(10,2,'ООО','Республика','454698, г. Челябинск, ул. Интернациональная, 17, оф. 49','40702810152981499289','ПАО \"БЫСТРОБАНК\"','78676381915','repspublicka.ogr.1294@yandex.ru',NULL,NULL,NULL,NULL,NULL,NULL,'3268454606','142248806','1202367582988','049401814',NULL),(11,2,'ООО','Подлинный специалист','630827, г. Новосибирск, ул. Коммунистическая, 38, оф. 20','40702810956498483775','АО АКБ \"МЕЖДУНАРОДНЫЙ ФИНАНСОВЫЙ КЛУБ\"','74042021539','fullrightmaster546@org.com',NULL,NULL,NULL,NULL,NULL,NULL,'6448825140','567329115','9135009484414','044525632',NULL),(12,1,NULL,'Горбунов Тарас Кириллович','Россия, г. Москва, Молодежный пер., 75, корп. 8, кв. 88','40702810225876834014','АО \"Экспобанк\"','74951074923','Taras152@yandex.ru',NULL,'1991-10-01','ОУФМС России по гор. Ульяновск',336013,7709,195014,NULL,NULL,NULL,NULL,NULL),(13,2,'АО','Ответ','394423, г. Воронеж, ул. Калинина, 40, оф. 100','40702810217856117103','КУ КБ \"ЕВРОСТАНДАРТ\" (ООО) - ГК \"АСВ\"','75884365830','responseao96@mail.ru',NULL,NULL,NULL,NULL,NULL,NULL,'8667634230','375834100','7106580022311','044525433',NULL);
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clienttype`
--

DROP TABLE IF EXISTS `clienttype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clienttype` (
  `ClientTypeID` int NOT NULL AUTO_INCREMENT,
  `ClientTypeName` varchar(15) NOT NULL,
  PRIMARY KEY (`ClientTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clienttype`
--

LOCK TABLES `clienttype` WRITE;
/*!40000 ALTER TABLE `clienttype` DISABLE KEYS */;
INSERT INTO `clienttype` VALUES (1,'Физическое'),(2,'Юридическое');
/*!40000 ALTER TABLE `clienttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `control_point_to_subtask`
--

DROP TABLE IF EXISTS `control_point_to_subtask`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `control_point_to_subtask` (
  `ProjectID` int NOT NULL,
  `StageID` int NOT NULL,
  `SubtaskID` int NOT NULL,
  `ControlPointID` int NOT NULL,
  PRIMARY KEY (`ProjectID`,`StageID`,`SubtaskID`,`ControlPointID`),
  KEY `cntrpnt_sbtsk_stage_ref_k_idx` (`StageID`),
  KEY `cntrpnt_sbtsk_subtask_ref_k_idx` (`SubtaskID`),
  KEY `controlpoint_ref_k_idx` (`ControlPointID`),
  CONSTRAINT `cntrpnt_sbtsk_project_ref_k` FOREIGN KEY (`ProjectID`) REFERENCES `subtask_in_project_stage` (`ProjectID`),
  CONSTRAINT `cntrpnt_sbtsk_stage_ref_k` FOREIGN KEY (`StageID`) REFERENCES `subtask_in_project_stage` (`StageID`),
  CONSTRAINT `cntrpnt_sbtsk_subtask_ref_k` FOREIGN KEY (`SubtaskID`) REFERENCES `subtask_in_project_stage` (`SubtaskID`),
  CONSTRAINT `controlpoint_ref_k` FOREIGN KEY (`ControlPointID`) REFERENCES `controlpoint` (`ControlPointID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `control_point_to_subtask`
--

LOCK TABLES `control_point_to_subtask` WRITE;
/*!40000 ALTER TABLE `control_point_to_subtask` DISABLE KEYS */;
INSERT INTO `control_point_to_subtask` VALUES (1,1,1,1),(1,1,2,2),(1,1,3,3),(1,1,4,4),(4,1,1,19),(4,1,2,20),(4,1,3,21),(4,1,4,22),(5,1,2,35),(5,1,3,36),(1,2,5,7),(1,2,6,5),(1,2,7,6),(1,2,8,8),(1,2,8,9),(4,2,6,23),(4,2,7,24),(4,2,8,25),(4,2,8,26),(4,2,8,27),(5,2,8,37),(5,2,8,38),(5,2,8,39),(5,2,8,40),(1,3,9,10),(1,3,10,11),(4,3,10,29),(4,3,11,28),(4,3,11,30),(5,3,9,42),(5,3,9,43),(5,3,10,41),(1,4,12,12),(1,4,12,13),(1,4,12,14),(2,4,12,15),(2,4,12,16),(2,4,12,17),(2,4,12,18),(4,4,12,31),(4,4,12,32),(4,4,12,33),(4,4,12,34),(5,4,12,44),(5,4,12,45),(5,4,12,46),(5,4,12,47);
/*!40000 ALTER TABLE `control_point_to_subtask` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `controlpoint`
--

DROP TABLE IF EXISTS `controlpoint`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `controlpoint` (
  `ControlPointID` int NOT NULL AUTO_INCREMENT,
  `ControlPointAuthorID` int NOT NULL,
  `StatusID` int NOT NULL,
  `ControlPointTitle` varchar(100) DEFAULT NULL,
  `ControlPointDescription` varchar(256) DEFAULT NULL,
  `ControlPointDateTime` varchar(45) NOT NULL,
  PRIMARY KEY (`ControlPointID`,`ControlPointDateTime`),
  KEY `status_ref_k_idx` (`StatusID`),
  CONSTRAINT `controlpoint_status_ref_k` FOREIGN KEY (`StatusID`) REFERENCES `status` (`StatusID`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `controlpoint`
--

LOCK TABLES `controlpoint` WRITE;
/*!40000 ALTER TABLE `controlpoint` DISABLE KEYS */;
INSERT INTO `controlpoint` VALUES (1,13,5,'Предметная область изучена',NULL,'2024-07-05 10:30'),(2,9,5,'Техническое задание подготовлено',NULL,'2024-07-09 12:06'),(3,12,5,'Диаграммы использования и деятельности построены',NULL,'2024-07-10 09:17'),(4,9,5,'Прототип готов',NULL,'2024-07-15 15:28'),(5,13,5,'База данных создана',NULL,'2024-07-16 11:57'),(6,13,5,'Данные подготовлены и вставлены в базу',NULL,'2024-07-16 16:42'),(7,12,5,'Дизайны подготовлены',NULL,'2024-07-19 17:04'),(8,9,2,'Реализованы функции вывода данных и взаимодействия с ними',NULL,'2024-07-22 12:32'),(9,12,5,'Функции реализованы',NULL,'2024-07-25 13:34'),(10,9,5,'Вроде работает, работает хорошо',NULL,'2024-07-27 12:23'),(11,12,5,'Функции отлажены',NULL,'2024-07-26 09:17'),(12,12,2,' Работа над руководством',NULL,'2024-07-28 15:06'),(13,9,2,'Работа над руководством 2. Близимся к завершению',NULL,'2024-07-30 08:56'),(14,13,5,'Руководство готово',NULL,'2024-08-01 12:42'),(15,11,2,'Изучаем предоставленную программу',NULL,'2024-07-16 13:05'),(16,18,2,'Пишем руководство пользователя',NULL,'2024-07-20 16:22'),(17,11,2,'Финальные штрихи',NULL,'2024-07-24 09:59'),(18,11,5,'Закончили руководство',NULL,'2024-07-25 14:47'),(19,18,5,'Изучили предметную область',NULL,'2024-08-03 16:23'),(20,11,5,'',NULL,'2024-08-05 10:58'),(21,9,5,NULL,NULL,'2024-08-06 17:16'),(22,12,5,NULL,NULL,'2024-08-08 16:49'),(23,9,5,NULL,NULL,'2024-08-09 10:21'),(24,12,5,NULL,NULL,'2024-08-13 15:47'),(25,11,2,'Работа над функционалом',NULL,'2024-08-14 16:12'),(26,18,2,'Работа над функционалом 2',NULL,'2024-08-24 15:07'),(27,12,5,'Функционал готов',NULL,'2024-08-30 13:19'),(28,9,2,'Тестим границы',NULL,'2024-09-01 12:23'),(29,18,5,'Модули протестированы',NULL,'2024-09-02 15:27'),(30,9,5,'Завершил тестирование',NULL,'2024-09-03 17:53'),(31,18,2,'Готовим документ',NULL,'2024-09-04 15:11'),(32,12,2,NULL,NULL,'2024-09-06 13:19'),(33,11,2,'Заканчиваем подготовку руководства',NULL,'2024-09-07 17:22'),(34,9,5,'Руководство готово',NULL,'2024-09-08 11:15'),(35,13,5,'ТЗ готово',NULL,'2024-08-10 11:50'),(36,13,5,'Диаграммы построил',NULL,'2024-08-12 09:11'),(37,13,2,'Приступаю к реализации',NULL,'2024-08-12 12:15'),(38,13,2,NULL,NULL,'2024-08-20 16:17'),(39,13,2,NULL,NULL,'2024-08-21 14:28'),(40,13,5,'Завершил работу над функционалом',NULL,'2024-08-22 13:51'),(41,13,5,'Модули протестированы',NULL,'2024-08-24 09:18'),(42,13,2,'Оптимизирую производительность',NULL,'2024-08-24 10:22'),(43,13,5,NULL,NULL,'2024-09-02 17:17'),(44,13,2,'Документирование',NULL,'2024-09-03 09:15'),(45,13,2,NULL,NULL,'2024-09-14 15:46'),(46,13,2,'Скоро закончу',NULL,'2024-09-17 12:02'),(47,13,5,'Руководство подготовлено',NULL,'2024-09-19 14:32');
/*!40000 ALTER TABLE `controlpoint` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventjournal`
--

DROP TABLE IF EXISTS `eventjournal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventjournal` (
  `EventID` int NOT NULL AUTO_INCREMENT,
  `EventTypeID` int NOT NULL,
  `UserID` int NOT NULL,
  `EventDateTime` datetime NOT NULL,
  PRIMARY KEY (`EventID`),
  KEY `eventtype_ref_k_idx` (`EventTypeID`),
  KEY `user_ref_k_idx` (`UserID`),
  CONSTRAINT `eventtype_ref_k` FOREIGN KEY (`EventTypeID`) REFERENCES `eventtype` (`EventTypeID`),
  CONSTRAINT `user_ref_k` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventjournal`
--

LOCK TABLES `eventjournal` WRITE;
/*!40000 ALTER TABLE `eventjournal` DISABLE KEYS */;
/*!40000 ALTER TABLE `eventjournal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventtype`
--

DROP TABLE IF EXISTS `eventtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventtype` (
  `EventTypeID` int NOT NULL AUTO_INCREMENT,
  `EventTypeName` varchar(30) NOT NULL,
  PRIMARY KEY (`EventTypeID`),
  UNIQUE KEY `EventTypeName_UNIQUE` (`EventTypeName`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventtype`
--

LOCK TABLES `eventtype` WRITE;
/*!40000 ALTER TABLE `eventtype` DISABLE KEYS */;
INSERT INTO `eventtype` VALUES (1,'авторизовался'),(5,'вышел из системы'),(6,'вышел по тайм-ауту'),(3,'изменил объект'),(2,'создал объект'),(4,'удалил объект');
/*!40000 ALTER TABLE `eventtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organitationtype`
--

DROP TABLE IF EXISTS `organitationtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organitationtype` (
  `OrganitationTypeName` varchar(4) NOT NULL,
  `OrganitationTypeDescription` varchar(45) NOT NULL,
  PRIMARY KEY (`OrganitationTypeName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organitationtype`
--

LOCK TABLES `organitationtype` WRITE;
/*!40000 ALTER TABLE `organitationtype` DISABLE KEYS */;
INSERT INTO `organitationtype` VALUES ('АО','Акционерное общество'),('ЗАО','Закрытое акционерное общество'),('ИП','Индивидуальный предприниматель'),('КТ','Командное товарищество'),('ОАО','Открытое акционерное общество'),('ООО','Общество с ограниченной ответственностью'),('ПАО','Публичное акционерное общество'),('ПК','Производственный кооператив'),('ПТ','Полное товарищество');
/*!40000 ALTER TABLE `organitationtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project` (
  `ProjectID` int NOT NULL AUTO_INCREMENT,
  `ProjectStatusID` int NOT NULL,
  `ProjectCustomerID` int NOT NULL,
  `ProjectCreatorID` int NOT NULL,
  `ProjectTitle` varchar(256) NOT NULL,
  `ProjectStartDate` date NOT NULL,
  `ProjectPlanEndDate` date DEFAULT NULL,
  `ProjectFactEndDate` date DEFAULT NULL,
  `ProjectCoefficient` varchar(4) NOT NULL DEFAULT '0',
  `MarkedToDelete` tinyint DEFAULT NULL,
  `ProjectCost` double NOT NULL,
  `ProjectMoneyReturn` double DEFAULT '0',
  PRIMARY KEY (`ProjectID`),
  KEY `client_ref_k_idx` (`ProjectCustomerID`),
  KEY `creator_ref_k_idx` (`ProjectCreatorID`),
  KEY `project_status_ref_k_idx` (`ProjectStatusID`),
  CONSTRAINT `client_ref_k` FOREIGN KEY (`ProjectCustomerID`) REFERENCES `client` (`ClientID`),
  CONSTRAINT `creator_ref_k` FOREIGN KEY (`ProjectCreatorID`) REFERENCES `user` (`UserID`),
  CONSTRAINT `project_status_ref_k` FOREIGN KEY (`ProjectStatusID`) REFERENCES `status` (`StatusID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project`
--

LOCK TABLES `project` WRITE;
/*!40000 ALTER TABLE `project` DISABLE KEYS */;
INSERT INTO `project` VALUES (1,5,4,10,'Проект 1: Разработать АИС для хранения и управления информацией об радиооборудовании','2024-07-04','2024-08-02',NULL,'0',NULL,98351,0),(2,5,3,16,'Проект 2: Разработать документацию к приложению Пространство.Net','2024-07-16','2024-07-26',NULL,'0',NULL,24509,0),(3,6,1,14,'Разработка мессенджера','2024-07-19','2024-09-17',NULL,'-100',NULL,201649,201649),(4,5,6,10,'Разработка АИС хранения операций купли-продажи домов','2024-08-03','2024-08-25','2024-09-09','-5',NULL,101593,5079.65),(5,5,2,10,'Разработка валидатора данных в таблицах Excel по задаваемому шаблону','2024-08-08','2024-09-20',NULL,'0',NULL,97359,NULL),(6,6,9,14,'Разработка CRM-системы','2024-08-09','2024-11-17',NULL,'-100',NULL,312506,312506),(7,6,7,14,'Разработка дизайна АИС маганиза телескопов','2024-09-18','2024-09-30',NULL,'0',NULL,35961,NULL);
/*!40000 ALTER TABLE `project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `specialization`
--

DROP TABLE IF EXISTS `specialization`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `specialization` (
  `SpecializationID` int NOT NULL AUTO_INCREMENT,
  `SpecializationTitle` varchar(45) NOT NULL,
  PRIMARY KEY (`SpecializationID`),
  UNIQUE KEY `SpecializationTitle_UNIQUE` (`SpecializationTitle`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `specialization`
--

LOCK TABLES `specialization` WRITE;
/*!40000 ALTER TABLE `specialization` DISABLE KEYS */;
INSERT INTO `specialization` VALUES (10,'Back-end разработчик'),(9,'Front-end разработчик'),(4,'QA-инженер'),(5,'QA-тестировщик'),(14,'UX-дизайнер'),(13,'UX-тестировщик'),(1,'Администратор баз данных'),(2,'Аналитик'),(7,'Архитектор программного обеспечения'),(12,'Контент-менеджер'),(3,'Менеджер'),(0,'Не определена'),(11,'Программист'),(8,'Разработчик баз данных'),(6,'Системный администратоор');
/*!40000 ALTER TABLE `specialization` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stage`
--

DROP TABLE IF EXISTS `stage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stage` (
  `StageID` int NOT NULL AUTO_INCREMENT,
  `StageTitle` varchar(60) NOT NULL,
  PRIMARY KEY (`StageID`),
  UNIQUE KEY `StageTitle_UNIQUE` (`StageTitle`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stage`
--

LOCK TABLES `stage` WRITE;
/*!40000 ALTER TABLE `stage` DISABLE KEYS */;
INSERT INTO `stage` VALUES (4,'Документирование'),(1,'Проектирование'),(2,'Реализация'),(3,'Тестирование');
/*!40000 ALTER TABLE `stage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stage_in_project`
--

DROP TABLE IF EXISTS `stage_in_project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stage_in_project` (
  `ProjectID` int NOT NULL,
  `StageID` int NOT NULL,
  PRIMARY KEY (`ProjectID`,`StageID`),
  KEY `stproj_stage_ref_k_idx` (`StageID`),
  CONSTRAINT `stproj_project_ref_k` FOREIGN KEY (`ProjectID`) REFERENCES `project` (`ProjectID`),
  CONSTRAINT `stproj_stage_ref_k` FOREIGN KEY (`StageID`) REFERENCES `stage` (`StageID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stage_in_project`
--

LOCK TABLES `stage_in_project` WRITE;
/*!40000 ALTER TABLE `stage_in_project` DISABLE KEYS */;
INSERT INTO `stage_in_project` VALUES (1,1),(4,1),(5,1),(1,2),(4,2),(5,2),(1,3),(4,3),(5,3),(1,4),(2,4),(4,4),(5,4);
/*!40000 ALTER TABLE `stage_in_project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  `StatusID` int NOT NULL AUTO_INCREMENT,
  `StatusTitle` varchar(100) NOT NULL,
  PRIMARY KEY (`StatusID`),
  UNIQUE KEY `StatusTitle_UNIQUE` (`StatusTitle`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status`
--

LOCK TABLES `status` WRITE;
/*!40000 ALTER TABLE `status` DISABLE KEYS */;
INSERT INTO `status` VALUES (2,'В работе'),(5,'Завершено'),(1,'Новый'),(6,'Отклонён'),(4,'Подготовка к завершению'),(3,'Согласование');
/*!40000 ALTER TABLE `status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subtask`
--

DROP TABLE IF EXISTS `subtask`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subtask` (
  `SubtaskID` int NOT NULL AUTO_INCREMENT,
  `SubtaskTitle` varchar(50) NOT NULL,
  PRIMARY KEY (`SubtaskID`),
  UNIQUE KEY `SubtaskTitle_UNIQUE` (`SubtaskTitle`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subtask`
--

LOCK TABLES `subtask` WRITE;
/*!40000 ALTER TABLE `subtask` DISABLE KEYS */;
INSERT INTO `subtask` VALUES (1,'Изучение предметной области'),(10,'Модульное тестирование'),(7,'Наполнение базы данных тестовыми данными'),(3,'Построение диаграмм работы программмы'),(9,'Проверка производительности программы'),(6,'Разработка базы данных'),(5,'Разработка дизайнов окон'),(12,'Разработка руководства пользователя'),(2,'Разработка технического задания'),(8,'Реализация заданных функций'),(4,'Создание прототипа приложения'),(11,'Тестирование граничными данными');
/*!40000 ALTER TABLE `subtask` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subtask_in_project_stage`
--

DROP TABLE IF EXISTS `subtask_in_project_stage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subtask_in_project_stage` (
  `ProjectID` int NOT NULL,
  `StageID` int NOT NULL,
  `SubtaskID` int NOT NULL,
  `SubtaskDescription` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`ProjectID`,`StageID`,`SubtaskID`),
  KEY `subtsk_stgproj_stage_ref_k_idx` (`StageID`),
  KEY `subtask_ref_k_idx` (`SubtaskID`),
  CONSTRAINT `subtask_ref_k` FOREIGN KEY (`SubtaskID`) REFERENCES `subtask` (`SubtaskID`),
  CONSTRAINT `subtsk_stgproj_project_ref_k` FOREIGN KEY (`ProjectID`) REFERENCES `stage_in_project` (`ProjectID`),
  CONSTRAINT `subtsk_stgproj_stage_ref_k` FOREIGN KEY (`StageID`) REFERENCES `stage_in_project` (`StageID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subtask_in_project_stage`
--

LOCK TABLES `subtask_in_project_stage` WRITE;
/*!40000 ALTER TABLE `subtask_in_project_stage` DISABLE KEYS */;
INSERT INTO `subtask_in_project_stage` VALUES (1,1,1,NULL),(1,1,2,NULL),(1,1,3,NULL),(1,1,4,NULL),(1,2,5,NULL),(1,2,6,NULL),(1,2,7,NULL),(1,2,8,NULL),(1,3,9,NULL),(1,3,10,NULL),(1,4,12,NULL),(2,4,12,NULL),(4,1,1,NULL),(4,1,2,NULL),(4,1,3,NULL),(4,1,4,NULL),(4,2,5,NULL),(4,2,6,NULL),(4,2,7,NULL),(4,2,8,NULL),(4,3,10,NULL),(4,3,11,NULL),(4,4,12,NULL),(5,1,2,NULL),(5,1,3,NULL),(5,1,12,NULL),(5,2,8,NULL),(5,3,9,NULL),(5,3,10,NULL),(5,4,12,NULL);
/*!40000 ALTER TABLE `subtask_in_project_stage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `UserModeID` int NOT NULL,
  `UserSpecialization` int DEFAULT NULL,
  `UserSurname` varchar(60) NOT NULL,
  `UserName` varchar(45) NOT NULL,
  `UserPatronymic` varchar(50) DEFAULT NULL,
  `UserLogin` varchar(100) NOT NULL,
  `UserPassword` varchar(128) NOT NULL,
  `UserPhoto` blob,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `UserLogin_UNIQUE` (`UserLogin`),
  KEY `usermode_ref_k_idx` (`UserModeID`),
  KEY `specialization_ref_k_idx` (`UserSpecialization`),
  CONSTRAINT `specialization_ref_k` FOREIGN KEY (`UserSpecialization`) REFERENCES `specialization` (`SpecializationID`),
  CONSTRAINT `usermode_ref_k` FOREIGN KEY (`UserModeID`) REFERENCES `usermode` (`UserModeID`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (9,3,8,'Аксенова','Нинель','Натановна','admi1_nW9nROn','3657c8b2441df7a617d74ca6db6921ebd7502c08dd489bdb6b0b5ca06ade150de563c0f941dced7fabf3b44518a77a22162971ea6ac39f6a4ef6fdfd915f443c',NULL),(10,2,3,'Королев','Игорь','Алексеевич','8q@NJX5R','56a83f23adbcb123a490ea61de1fc30292f21d2a22fa6b521b03cce0c3158079f2a71b3cfb480710c70b5716b73a4b693ff70011b36af5866a1442b1bfa047d7',NULL),(11,3,11,'Стрелков','Конон','Эдгардович','l$C3Z3da','44fd5df9c491fb201f933ff5c510f37c3d43ec0dc24bf5f8f10581223d84b645b7dc980841204c965b007afc49ca93172962f55cc7a6bf66c60949e30ebe1326',NULL),(12,3,14,'Моисеев','Трофим','Дмитриевич','ueB~J5mk','41da80ad8c95ba2f6c4e0c9e08d46229234ade51821989348950ad10b8e3050df86671898153cebeab51a7b74862a6c7397b0eff827a7c1d2517d9bf42fdf175',NULL),(13,3,5,'Суворов','Плов','Борисович','employee','ada3197469dbc37df5789eda636a6c4c24f4cf368ec089f640c7981b2a450fe9be9a0d6896ec5714cb00a1e1b63571f34e9d63c5845b165211fcdab83651f2a5',NULL),(14,2,3,'Кудрявцева','Ирина','Рудольфовна','manager','5fc2ca6f085919f2f77626f1e280fab9cc92b4edc9edc53ac6eee3f72c5c508e869ee9d67a96d63986d14c1c2b82c35ff5f31494bea831015424f59c96fff664',NULL),(15,1,0,'Беляев','Самуил','Марсович','admin','c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec',NULL),(16,2,8,'Гусева','Антонина','Анатольевна','FJ=tgA28','fb41e73b5cc558f657b069f5318d60e6337e91652921197b15c9fe5f01236ecaf52bef4bfad87a073c9a9d744438635adb7d570f62cb5b7739c7143a4d8fcd61',NULL),(17,1,0,'Горшков','Виссарион','Трифонович','bgm[Bbgq','00f714c3440d09eee348978a9d215fe1dfff02ce5e92b606f91ee096498cd26560d7773de74b45550b405d9e07844d21ee3e0c9d8703da348588c6a433686114',NULL),(18,3,10,'Терентьев','Кир','Дмитриевич','g-p4PKlJ','82e70aa1823eaa4be4d0f2a9ae27684b656bff6d5a7ce45a6df9165375e6c54b5183d7b573ab064a275a43b5f5a29473c01ff710615fcb6a35ffa36113711d72',NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usermode`
--

DROP TABLE IF EXISTS `usermode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usermode` (
  `UserModeID` int NOT NULL AUTO_INCREMENT,
  `UserModeTitle` varchar(13) NOT NULL,
  PRIMARY KEY (`UserModeID`),
  UNIQUE KEY `UserModeTitle_UNIQUE` (`UserModeTitle`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usermode`
--

LOCK TABLES `usermode` WRITE;
/*!40000 ALTER TABLE `usermode` DISABLE KEYS */;
INSERT INTO `usermode` VALUES (1,'Администратор'),(2,'Менеджер'),(3,'Сотрудник');
/*!40000 ALTER TABLE `usermode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userproject`
--

DROP TABLE IF EXISTS `userproject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userproject` (
  `UserID` int NOT NULL,
  `ProjectID` int NOT NULL,
  `IsResponsible` tinyint DEFAULT '0',
  PRIMARY KEY (`UserID`,`ProjectID`),
  KEY `project_ref_k_idx` (`ProjectID`),
  CONSTRAINT `userproj_project_ref_k` FOREIGN KEY (`ProjectID`) REFERENCES `project` (`ProjectID`),
  CONSTRAINT `userproj_user_ref_k` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userproject`
--

LOCK TABLES `userproject` WRITE;
/*!40000 ALTER TABLE `userproject` DISABLE KEYS */;
INSERT INTO `userproject` VALUES (9,1,0),(9,4,0),(11,2,1),(11,4,0),(12,1,0),(12,4,0),(13,1,1),(13,5,1),(18,2,0),(18,4,1);
/*!40000 ALTER TABLE `userproject` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-02-26  0:07:43
