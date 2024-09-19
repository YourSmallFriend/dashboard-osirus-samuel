-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 19, 2024 at 02:33 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `schoolvoortgang`
--

-- --------------------------------------------------------

--
-- Table structure for table `docenten`
--

CREATE TABLE `docenten` (
  `Docent_ID` int(11) NOT NULL,
  `Naam` varchar(100) NOT NULL,
  `Wachtwoord` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `docenten`
--

INSERT INTO `docenten` (`Docent_ID`, `Naam`, `Wachtwoord`) VALUES
(1, 'Mevrouw de Vries', 'docent123'),
(2, 'Meneer Jansen', 'docentengels'),
(3, 'Mevrouw Bakker', 'docentnederlands');

-- --------------------------------------------------------

--
-- Table structure for table `examens`
--

CREATE TABLE `examens` (
  `Examen_ID` int(11) NOT NULL,
  `Vak_ID` int(11) DEFAULT NULL,
  `Datum` date NOT NULL,
  `Beschrijving` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `examens`
--

INSERT INTO `examens` (`Examen_ID`, `Vak_ID`, `Datum`, `Beschrijving`) VALUES
(1, 1, '2024-09-19', 'Rekenen 3F'),
(2, 2, '2024-09-19', 'Engels Lezen'),
(3, 2, '2024-09-19', 'Engels Luisteren'),
(4, 3, '2024-09-19', 'Nederlands Schrijven');

-- --------------------------------------------------------

--
-- Table structure for table `klas`
--

CREATE TABLE `klas` (
  `Klas_ID` int(11) NOT NULL,
  `Naam` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `klas`
--

INSERT INTO `klas` (`Klas_ID`, `Naam`) VALUES
(1, 'Klas A');

-- --------------------------------------------------------

--
-- Table structure for table `studenten`
--

CREATE TABLE `studenten` (
  `Student_ID` int(11) NOT NULL,
  `Naam` varchar(100) NOT NULL,
  `Wachtwoord` varchar(255) NOT NULL,
  `Klas_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `studenten`
--

INSERT INTO `studenten` (`Student_ID`, `Naam`, `Wachtwoord`, `Klas_ID`) VALUES
(1, 'Jan', '1234', 1),
(2, 'Lisa', 'lisa123', 1),
(3, 'Tom', 'tom123', 1),
(4, 'Sara', 'sara123', 1);

-- --------------------------------------------------------

--
-- Table structure for table `vakken`
--

CREATE TABLE `vakken` (
  `Vak_ID` int(11) NOT NULL,
  `Naam` varchar(100) NOT NULL,
  `Beschrijving` text DEFAULT NULL,
  `Docent_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `vakken`
--

INSERT INTO `vakken` (`Vak_ID`, `Naam`, `Beschrijving`, `Docent_ID`) VALUES
(1, 'Rekenen', 'Basis wiskunde', 1),
(2, 'Engels', 'Engelse taal en literatuur', 2),
(3, 'Nederlands', 'Nederlandse taalvaardigheid', 3);

-- --------------------------------------------------------

--
-- Table structure for table `voortgang`
--

CREATE TABLE `voortgang` (
  `Student_ID` int(11) NOT NULL,
  `Vak_ID` int(11) NOT NULL,
  `Examen_ID` int(11) NOT NULL,
  `Cijfer` decimal(3,1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `voortgang`
--

INSERT INTO `voortgang` (`Student_ID`, `Vak_ID`, `Examen_ID`, `Cijfer`) VALUES
(1, 1, 1, 8.5),
(1, 2, 2, 7.0),
(1, 2, 3, 7.5),
(1, 3, 4, 6.5),
(2, 1, 1, 9.0),
(2, 2, 2, 8.0),
(2, 2, 3, 8.5),
(2, 3, 4, 7.0),
(3, 1, 1, 6.5),
(3, 2, 2, 5.5),
(3, 2, 3, 6.0),
(3, 3, 4, 6.0),
(4, 1, 1, 7.5),
(4, 2, 2, 8.5),
(4, 2, 3, 8.0),
(4, 3, 4, 7.5);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `docenten`
--
ALTER TABLE `docenten`
  ADD PRIMARY KEY (`Docent_ID`);

--
-- Indexes for table `examens`
--
ALTER TABLE `examens`
  ADD PRIMARY KEY (`Examen_ID`),
  ADD KEY `Vak_ID` (`Vak_ID`);

--
-- Indexes for table `klas`
--
ALTER TABLE `klas`
  ADD PRIMARY KEY (`Klas_ID`);

--
-- Indexes for table `studenten`
--
ALTER TABLE `studenten`
  ADD PRIMARY KEY (`Student_ID`),
  ADD KEY `Klas_ID` (`Klas_ID`);

--
-- Indexes for table `vakken`
--
ALTER TABLE `vakken`
  ADD PRIMARY KEY (`Vak_ID`),
  ADD KEY `Docent_ID` (`Docent_ID`);

--
-- Indexes for table `voortgang`
--
ALTER TABLE `voortgang`
  ADD PRIMARY KEY (`Student_ID`,`Vak_ID`,`Examen_ID`),
  ADD KEY `Vak_ID` (`Vak_ID`),
  ADD KEY `Examen_ID` (`Examen_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `docenten`
--
ALTER TABLE `docenten`
  MODIFY `Docent_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `examens`
--
ALTER TABLE `examens`
  MODIFY `Examen_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `klas`
--
ALTER TABLE `klas`
  MODIFY `Klas_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `studenten`
--
ALTER TABLE `studenten`
  MODIFY `Student_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `vakken`
--
ALTER TABLE `vakken`
  MODIFY `Vak_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `examens`
--
ALTER TABLE `examens`
  ADD CONSTRAINT `examens_ibfk_1` FOREIGN KEY (`Vak_ID`) REFERENCES `vakken` (`Vak_ID`);

--
-- Constraints for table `studenten`
--
ALTER TABLE `studenten`
  ADD CONSTRAINT `studenten_ibfk_1` FOREIGN KEY (`Klas_ID`) REFERENCES `klas` (`Klas_ID`);

--
-- Constraints for table `vakken`
--
ALTER TABLE `vakken`
  ADD CONSTRAINT `vakken_ibfk_1` FOREIGN KEY (`Docent_ID`) REFERENCES `docenten` (`Docent_ID`);

--
-- Constraints for table `voortgang`
--
ALTER TABLE `voortgang`
  ADD CONSTRAINT `voortgang_ibfk_1` FOREIGN KEY (`Student_ID`) REFERENCES `studenten` (`Student_ID`),
  ADD CONSTRAINT `voortgang_ibfk_2` FOREIGN KEY (`Vak_ID`) REFERENCES `vakken` (`Vak_ID`),
  ADD CONSTRAINT `voortgang_ibfk_3` FOREIGN KEY (`Examen_ID`) REFERENCES `examens` (`Examen_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
