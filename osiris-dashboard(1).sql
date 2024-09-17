-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 17, 2024 at 05:22 PM
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
-- Database: `osiris-dashboard`
--

-- --------------------------------------------------------

--
-- Table structure for table `examens`
--

CREATE TABLE `examens` (
  `Examen_ID` int(128) NOT NULL,
  `Examen_Naam` text NOT NULL,
  `Vak_ID` int(24) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `examens`
--

INSERT INTO `examens` (`Examen_ID`, `Examen_Naam`, `Vak_ID`) VALUES
(4, 'Rekenen 3F', 1);

-- --------------------------------------------------------

--
-- Table structure for table `results`
--

CREATE TABLE `results` (
  `Result_ID` int(128) NOT NULL,
  `Student_ID` int(128) NOT NULL,
  `Examen_ID` int(128) NOT NULL,
  `Result` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `vakken`
--

CREATE TABLE `vakken` (
  `Vak_ID` int(24) NOT NULL,
  `Vak_Naam` text NOT NULL,
  `Vak_Result` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `vakken`
--

INSERT INTO `vakken` (`Vak_ID`, `Vak_Naam`, `Vak_Result`) VALUES
(1, 'Rekenen', ''),
(2, 'Engels', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `examens`
--
ALTER TABLE `examens`
  ADD PRIMARY KEY (`Examen_ID`),
  ADD KEY `Vak_ID_Examen` (`Vak_ID`);

--
-- Indexes for table `results`
--
ALTER TABLE `results`
  ADD PRIMARY KEY (`Result_ID`),
  ADD KEY `Student_ID_Results` (`Student_ID`),
  ADD KEY `Examen_ID_Results` (`Examen_ID`);

--
-- Indexes for table `vakken`
--
ALTER TABLE `vakken`
  ADD PRIMARY KEY (`Vak_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `examens`
--
ALTER TABLE `examens`
  MODIFY `Examen_ID` int(128) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `results`
--
ALTER TABLE `results`
  MODIFY `Result_ID` int(128) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `vakken`
--
ALTER TABLE `vakken`
  MODIFY `Vak_ID` int(24) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `examens`
--
ALTER TABLE `examens`
  ADD CONSTRAINT `Vak_ID_Examen` FOREIGN KEY (`Vak_ID`) REFERENCES `vakken` (`Vak_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `results`
--
ALTER TABLE `results`
  ADD CONSTRAINT `Examen_ID_Results` FOREIGN KEY (`Examen_ID`) REFERENCES `examens` (`Examen_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Student_ID_Results` FOREIGN KEY (`Student_ID`) REFERENCES `studenten` (`Student_ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
